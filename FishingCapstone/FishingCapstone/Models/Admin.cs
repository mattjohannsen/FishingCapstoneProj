using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [Display(Name = "First Name")]
        public string AdminFirst { get; set; }
        [Display(Name = "Last Name")]
        public string AdminLast { get; set; }
    }
}
