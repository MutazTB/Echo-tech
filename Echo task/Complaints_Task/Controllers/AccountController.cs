using Compliants_Task_Domain.DTOs;
using Compliants_Task_Service.Svc_Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Complaints_Task.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserSvc _userSvc;
        public AccountController(IUserSvc userSvc)
        {
            _userSvc = userSvc;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegister viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _userSvc.Register(viewModel);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

            return View("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _userSvc.Login(viewModel);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _userSvc.Logout();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login");
        }
    }
}
