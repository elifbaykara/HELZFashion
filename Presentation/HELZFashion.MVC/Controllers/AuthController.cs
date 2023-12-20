using HELZFashion.Domain.Identity;
using HELZFashion.MVC.ModelViews;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Resend;
using System;
using System.Web;

namespace HELZFashion.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IToastNotification _toastNotification;
        private readonly SignInManager<User> _signInManager;
        private readonly IResend _resend;
        private readonly IWebHostEnvironment _environment;
        public AuthController(UserManager<User> userManager, IToastNotification toastNotification, SignInManager<User> signInManager, IResend resend, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _toastNotification = toastNotification;
            _signInManager = signInManager;
            _resend = resend;
            _environment = environment;

        }

        [HttpGet]
        public IActionResult Register()
        {
            var registerViewModel = new AuthRegisterViewModel();

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(AuthRegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var userId = Guid.NewGuid();

            var user = new User()
            {
                Id = userId,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Username,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                BirthDate = registerViewModel.BirthDate.ToUniversalTime(),
                Gender = registerViewModel.Gender,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = userId.ToString(),
            };

            var identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }

            _toastNotification.AddSuccessToastMessage("Kayıt oluşturuldu");

            // Building the button's URL
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user); // token, UserId

            token = HttpUtility.UrlEncode(token);

            var buttonLink = $"https://localhost:7194/Auth/VerifyEmail?email={user.Email}&token={token}";

            //

            var wwwRootPath = _environment.WebRootPath;

            var fullPathToHtml = Path.Combine(wwwRootPath, "email-templates", "verify-email.html");

            var htmlText = await System.IO.File.ReadAllTextAsync(fullPathToHtml);
            var title = "HELZFashion Mail Verification";

            // Title
            htmlText = htmlText.Replace("{{Title}}", title);


            // Description
            htmlText = htmlText.Replace("{{Description}}",
                "We are delighted that you have joined us! 😍  \n Please activate your account by clicking the button below to confirm your email address. \u2193 ");

            htmlText = htmlText.Replace("{{ButtonLink}}", buttonLink);

            htmlText = htmlText.Replace("{{ButtonText}}", "Verify");

            var message = new EmailMessage();
            message.From = "HELZFashion@zahidedusgun.com.tr";
            message.To.Add(user.Email);
            message.Subject = title;
            message.HtmlBody = htmlText;

            await _resend.EmailSendAsync(message);

            return RedirectToAction(nameof(Login));
        }


        [HttpGet] // localhost:7206/Auth/VerifyEmail?email=alpertunga@gmail.com&token=gkomaskdlqwenmjasksdaasdadasd
        public async Task<IActionResult> VerifyEmailAsync(string email, string token)
        {

            var user = await _userManager.FindByEmailAsync(email);

            var identityResult = await _userManager.ConfirmEmailAsync(user, token);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                _toastNotification.AddErrorToastMessage("We unfortunately couldn't verify your email.");

                return View();
            }


            _toastNotification.AddSuccessToastMessage("You've successfully verified your email address.");

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginViewModel = new AuthLoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(AuthLoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user is null)
            {
                _toastNotification.AddErrorToastMessage("Email ya da şifre hatalı");

                return View(loginViewModel);
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, true);

            if (!loginResult.Succeeded)
            {
                _toastNotification.AddErrorToastMessage("Email ya da şifre hatalı");

                return View(loginViewModel);
            }

            _toastNotification.AddSuccessToastMessage($"Başarıyla giriş yapıldı.Hoş geldin {user.UserName}");

            return RedirectToAction("Index","Home");
        }
    }
}
