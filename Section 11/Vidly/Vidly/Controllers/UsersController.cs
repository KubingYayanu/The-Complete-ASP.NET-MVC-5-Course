using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class UsersController : Controller
    {
        #region Property

        private ApplicationDbContext _context;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null && HttpContext == null)
                {
                    return new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
                }
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        #endregion

        #region Constructor/Destructor

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion

        #region Action

        [HttpGet]
        public ActionResult Index()
        {
            //if (User.IsInRole(RoleName.Admin))
            return View("List");
            //return View("ReadOnlyList");
        }

        [HttpGet]
        public ActionResult New()
        {
            var viewModel = new UserFormViewModel();

            return View("UserForm", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var userInDB = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDB == null)
                return HttpNotFound();

            var viewModel = new UserFormViewModel(userInDB);

            return View("UserForm", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Save(UserFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("UserForm", model);
            }

            if (string.IsNullOrWhiteSpace(model.Id))
            {
                #region Create new user

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Phone = model.Phone,
                    DrivingLicense = model.DrivingLicense
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    AddErrors(result);
                    return View("UserForm", model);
                }

                #endregion
            }
            else
            {
                #region Update user

                var userInDb = await UserManager.FindByIdAsync(model.Id);

                if (userInDb == null)
                {
                    return View("UserForm", model);
                }

                userInDb.Phone = model.Phone;
                userInDb.DrivingLicense = model.DrivingLicense;

                if (!string.IsNullOrWhiteSpace(model.Password))
                    userInDb.PasswordHash = UserManager.PasswordHasher.HashPassword(model.Password);

                var result = await UserManager.UpdateAsync(userInDb);

                if (!result.Succeeded)
                {
                    AddErrors(result);
                    return View("UserForm", model);
                }

                #endregion
            }

            return RedirectToAction("Index", "Users");
        }

        #endregion

        #region Private method

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #endregion
    }
}