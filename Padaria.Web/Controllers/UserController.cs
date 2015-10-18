using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using Padaria.Web.Models;
using System;
using System.Web.Mvc;

namespace Padaria.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private PermissionRepository InstantiatePermissionRepository { get; } = new PermissionRepository();
        private UserRepository InstantiateUserRepository { get; } = new UserRepository();
        private const bool Valid = true;
        private const int Success = 1;
        [HttpGet]
        public ActionResult List() => View(InstantiateUserRepository.GetAlls());
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Create()
        {
            var permissionRepository = InstantiatePermissionRepository;
            UserViewModel userViewModel = new UserViewModel
            {
                Permission = GetPermissionLoaded(InstantiatePermissionRepository)
            };
            return View(userViewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(UserViewModel userViewModel)
        {
            userViewModel.Users.LastAccess = DateTime.Now;
            if (Request.IsAjaxRequest() && ModelState.IsValid == Valid)
            {               
                return ModelState.IsValid && InstantiateUserRepository.Creates(user: userViewModel.Users) == Success ? 
                     Json(new { result = userViewModel.Users.UserID, JsonRequestBehavior.AllowGet } ):
                     Json(new { result = 0, JsonRequestBehavior.AllowGet });
            }
            else
            {              
                if (ModelState.IsValid == Valid && InstantiateUserRepository.Creates(user: userViewModel.Users) == Success)
                {
                    return RedirectToAction(nameof(this.List));
                }
                return View(GetUserViewFill(userViewModel.Users));
            }

        }
        [HttpGet]
        public ActionResult Delete([Bind(Include = "userID")]int userID)
        {
            Users user = InstantiateUserRepository.GetByIDs(userID);
            if (user != null)
            {
                user.ConPassWord = user.PassWord;
                return View(GetUserViewFill(user));
            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserViewModel userViewModel)
        {

            if (ModelState.IsValid == Valid)
            {

                switch (InstantiateUserRepository.Deletes(userViewModel.Users))
                {
                    case Success:
                        return RedirectToAction(nameof(this.List));
                }
            }
            return View(GetUserViewFill(userViewModel.Users));
        }
        [HttpGet]
        public ActionResult Edit(int userID)
        {
            Users user = InstantiateUserRepository.GetByIDs(userID);
            if (user != null)
            {
                user.ConPassWord = user.PassWord;
                return View(GetUserViewFill(user));
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid == Valid)
            {
                switch (InstantiateUserRepository.Updates(userViewModel.Users))
                {
                    case Success:
                        return RedirectToAction(nameof(this.List));
                }
            }
            return View(GetUserViewFill(userViewModel.Users));
        }
        [HttpGet]
        public ActionResult Details(int userID)
        {
            Users user = InstantiateUserRepository.GetByIDs(userID);
            if (user != null)
            {
                return View(GetUserViewFill(user));
            }
            return HttpNotFound();
        }
        public UserViewModel GetUserViewFill(Users user)
        {
            UserViewModel userViewModel = new UserViewModel
            {
                Users = user,
                Permission = GetPermissionLoaded(InstantiatePermissionRepository, user.PermissionID)
            };
            return userViewModel;
        }
        private static SelectList GetPermissionLoaded(PermissionRepository permissionRepository, int permissionID = 0)
        {
            return new SelectList(permissionRepository.GetAlls(), dataTextField: nameof(PermissionViewModel.Name), dataValueField: nameof(PermissionViewModel.PermissionID), selectedValue: permissionID);
        }


    }
}