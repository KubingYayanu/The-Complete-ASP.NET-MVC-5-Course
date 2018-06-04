using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Services;

namespace Vidly.Controllers.Api
{
    public class JwtAudienceController : ApiController
    {
        private AudiencesStore audiencesStore;

        public JwtAudienceController()
        {
            audiencesStore = new AudiencesStore();
        }

        /// <summary>
        /// 增加Resource Server(Audience)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddAudience(JwtAudienceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JwtAudience newAudience = audiencesStore.AddAudience(dto.Name);

            return Ok(newAudience);
        }
    }
}
