using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tenant.Repositories
{
    public class Gender
    {
        [Key]
        [Required]
        public int GenderId { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
    }
}
