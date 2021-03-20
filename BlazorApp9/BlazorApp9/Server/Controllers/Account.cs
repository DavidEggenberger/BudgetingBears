using BlazorApp9.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorApp9.Server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        public Account(SignInManager<ApplicationUser> _signInManager, UserManager<ApplicationUser> userManager)
        {
            this._signInManager = _signInManager;
            this._userManager = userManager;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin([FromForm] string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        [HttpPost("ExternalRegister")]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalRegister([FromForm] string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action(nameof(ExternalRegisterCallback), "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect($"Login?returnUrl{returnUrl}&message=Login Attempt Failed");
            }
        }
        [HttpGet("ExternalRegisterCallback")]
        public async Task<IActionResult> ExternalRegisterCallback(string returnUrl = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if(info is not null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = info.Principal.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Email)?.Value,
                    UserName = info.Principal.Identity.Name
                };
                user.Email ??= "github@email.com";
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);
                    return LocalRedirect(returnUrl);
                }
            }
            return Redirect("/Register");
        }
    }
}
