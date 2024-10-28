using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string username, string password) // 
             {
            _logger.LogInformation("Login attempt for user: {Username}", username);

            // Validate the username and password (this is just a simple example)
            if (username == "admin" && password == "password")
            {
                _logger.LogInformation("User {Username} authenticated successfully.", username);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);
               
                return RedirectToPage("/WeatherForecastPage");
            }

            _logger.LogWarning("Invalid login attempt for user: {Username}", username);
            return Page();
        }
    }
}
