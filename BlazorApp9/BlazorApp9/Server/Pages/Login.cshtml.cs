using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorApp9.Server.Pages
{
    public class LoginModel : PageModel
    {
        public string returnUrl { get; set; }
        public string message { get; set; }
        public void OnGet(string returnUrl, [FromQuery] string message)
        {
            this.returnUrl = returnUrl;
            this.message = message;
        }
    }
}
