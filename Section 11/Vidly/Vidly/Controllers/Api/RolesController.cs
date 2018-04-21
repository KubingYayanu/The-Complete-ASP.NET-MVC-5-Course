using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RolesController : ApiController
    {
        #region Property

        private ApplicationDbContext _context;

        #endregion

        #region Constructor/Destructor

        public RolesController()
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
        public IHttpActionResult GetRoles(string query = null)
        {
            var rolesQuery = _context.Roles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
                rolesQuery = rolesQuery.Where(r => r.Name.Contains(query));
            
            var roleDtos = rolesQuery
                .ToList()
                .Select(Mapper.Map<IdentityRole, RoleDto>);

            return Ok(roleDtos);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateNewRole(RoleDto roleDto)
        {
            if (string.IsNullOrWhiteSpace(roleDto.Name))
            {
                return BadRequest("Invalid Role Name.");
            }

            var roleStore = new RoleStore<IdentityRole>(_context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var role = new IdentityRole(roleDto.Name);
            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return InternalServerError(new Exception("Create Role failed."));
            }

            roleDto.Id = role.Id;

            var url = HttpContext.Current.Request.Url;

            return Created(new Uri(url.Scheme + "://" + url.Authority + "/" + "Roles"), roleDto);
        }

        #endregion
    }
}
