using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System.Web.Mvc;
using System.Web.Security;

namespace Padaria.Web.Controllers
{
    public class LoginController : Controller
    {
        private LoginRepository _loginRepository = null;
        //private UserRepository _userRepository = null;
        private const bool Exists = true;
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login ,string ReturnUrl)
        {
            InstantiateLoginRepository();
            if (!ModelState.IsValid) { return View(login); }
            if (_loginRepository.Log(login) == Exists)
            {
                FormsAuthentication.SetAuthCookie(login.UserName, false);
                if (Url.IsLocalUrl(ReturnUrl)
                          && ReturnUrl.Length > 1
                          && ReturnUrl.StartsWith("/")
                          && !ReturnUrl.StartsWith("//")
                          && !ReturnUrl.StartsWith("/\\"))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("List", "Category");
                }
            }
            else
            {
                ModelState.AddModelError("erroLogin", "Login: " + login.UserName + " not localized");
            }
            return View(login);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        private void InstantiateLoginRepository()
        {
            _loginRepository = new LoginRepository();
        }
    }
}