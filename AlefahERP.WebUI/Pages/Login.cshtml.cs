using AlefahERP.Services;
using AlefahERP.WebUI.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AlefahERP.WebUI.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class LoginModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;
        private CustomAuthService auth;
        public LoginModel(IUnitOfWork unitOfWork, CustomAuthService auth)
        {
            this.unitOfWork = unitOfWork;
            this.auth = auth;
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var userName = Request.Form["Username"].ToString();
            var password = Request.Form["Password"].ToString();


            var user = this.unitOfWork.Users.Users.GetAll(x => x.Mobile == userName && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                auth.Users.Clear(); 
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("UserID", user.UserID.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, user.FullName));
                claims.Add(new Claim("Mobile", user.Mobile));
                claims.Add(new Claim("Password", user.Password));
                claims.Add(new Claim(ClaimTypes.Role, user.UserRoleCode));


                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                auth.Users.Add("Users--x", claimsPrincipal);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return Redirect("/Index");
            }
            else
            {
                return Redirect("/");
            }
        }

        //public void OnPost()
        //{

        //    string stri = "";

        //}
        public void OnGet()
        {


        }
    }
}
