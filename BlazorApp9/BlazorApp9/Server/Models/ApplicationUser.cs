using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp9.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ImageUrl { get; set; }
    }
}
