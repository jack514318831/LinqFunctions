using OA.BLL;
using OA.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UI.Portal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        UserInfoService userService = new UserInfoService();
        public ActionResult Index()
        {
            ViewData.Model =  userService.ShowData();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            UserInfoSet user = new UserInfoSet() { UserName = collection["UserName"], Email = collection["Email"], UserAge = Int16.Parse(collection["UserAge"]), ClassInfoClassId = int.Parse(collection["ClassInfoClassId"])  };
            userService.Add(user);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            ViewData.Model = userService.GetItemById(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            UserInfoSet user = new UserInfoSet() { UserId = int.Parse( collection["UserId"]), UserName = collection["UserName"] };
            userService.Delete(user);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            ViewData.Model = userService.GetItemById(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            UserInfoSet user = new UserInfoSet() { UserId = int.Parse(collection["UserId"]), UserName = collection["UserName"],
                                                   Email = collection["Email"], UserAge= Int16.Parse(collection["UserAge"]), ClassInfoClassId= int.Parse(collection["ClassInfoClassId"]) };
            userService.Edit(user);
            return RedirectToAction("Index");
        }
    }
}