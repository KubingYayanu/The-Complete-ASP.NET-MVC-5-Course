using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class RoleDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}