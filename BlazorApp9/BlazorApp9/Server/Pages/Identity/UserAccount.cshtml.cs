using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp9.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorApp9.Server.Pages
{
    public class UserAccountModel : PageModel
    {
        public UserManager<ApplicationUser> userManager;
        public UserAccountModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public ApplicationUser CurrentUser { get; set; }
        public async Task OnGetAsync()
        {
            CurrentUser = await userManager.GetUserAsync(User);
        }
        public async Task OnPostAsync()
        {

        }
    }
}
