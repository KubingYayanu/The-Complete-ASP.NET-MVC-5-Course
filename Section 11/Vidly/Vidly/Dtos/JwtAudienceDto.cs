using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class JwtAudienceDto
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}