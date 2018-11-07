using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain.Account;
using System.Threading.Tasks;

namespace StoreOfBuild.Data.Identity
{
    public class Authentication : IAuthentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public Authentication(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            //var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            var user = await _userManager.FindByEmailAsync(email);
            var bool_password = await _userManager.CheckPasswordAsync(user, password);

            var result = SignInResult.Failed;

            if (bool_password)
            {
                await _signInManager.SignInAsync(user,  false);
                result = SignInResult.Success;
            }
            return result.Succeeded;
        }


    }
}
