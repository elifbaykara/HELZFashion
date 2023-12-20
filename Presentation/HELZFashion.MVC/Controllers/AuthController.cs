using HELZFashion.Domain.Identity;
using HELZFashion.MVC.ModelViews;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace HELZFashion.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IToastNotification _toastNotification;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, IToastNotification toastNotification, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _toastNotification = toastNotification;
            _signInManager = signInManager;
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

            return RedirectToAction(nameof(Login));
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
