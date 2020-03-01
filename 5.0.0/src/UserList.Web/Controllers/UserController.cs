using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UserList.DbModels;
using UserList.Models;
using UserList.Services;
using UserList.Web.Models;

namespace UserList.Web.Controllers
{
    public class UserController : UserListControllerBase
    {
        private IUserServices _services;
      public UserController(IUserServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {         

            return View();
        }
        [HttpPost]
        public JsonResult Add(UserLIstViewModel UserLIstViewModel)
        {
            
           
           _services.AddUsers(new UserLIstModel()
           {
               Name = UserLIstViewModel.Name,
               Surname = UserLIstViewModel.Surname,
               personalnumber = UserLIstViewModel.personalnumber,
               DateOfBirth = UserLIstViewModel.DateOfBirth,
               Nationaly = UserLIstViewModel.Nationaly,
               Phone = UserLIstViewModel.Phone,
               PayrollCurrency= UserLIstViewModel.PayrollCurrency,
               Salary= UserLIstViewModel.Salary


           });
            //var result = _services.AddUsers(UserLIstViewModel);




            return Json(true);
        }


               
        public IActionResult UserList(UserLIstModel userLIstModel)
        {
            var result = _services.GetUser(userLIstModel);


            return View(result);
        }

        public IActionResult Edit(int Id )
        {
            var result = _services.Edit(Id);
           

            return View(result);
        }
        [HttpPost]
        public JsonResult Edit(UserLIstModel userLIstModel)
        {
            var result = _services.Edit(userLIstModel);

            return Json(result);
        }
        public IActionResult Delete(int id)
        {
            var result = _services.Delete(id);
            if (result==true)
            {
                return RedirectToAction("./UserList");
            }
            else
            {
                ViewBag.HtmlOutput = "<HTML><div>ტექნიკური ხარვეზია !</div></HTML>";

               return RedirectToAction("./UserList");
            }
        }

    }
}