using MVCFunctions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFunctions.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        UserInfoDBContainer dbcontext = new UserInfoDBContainer();
        public ActionResult Index()
        {
            ViewData.Model = dbcontext.UserInfoSet.AsEnumerable();
            return View();
        }

        #region PageIndex
        [HttpPost]
        public ActionResult Index(string txtPageIndex)
        {
            int pageSize = 2;
            int pageIndex = int.Parse(txtPageIndex);

            ViewData.Model = dbcontext.UserInfoSet.AsEnumerable().OrderBy(u => u.UserId).Skip(pageSize * (pageIndex - 1)).Take(pageSize);

            return View();
        } 
        #endregion

        public ActionResult Create()
        {
            ViewData.Model = new UserInfo() { UserName = "New", ClassInfoClassId = 1, UserAge = 20 };
            return View();
        }

        #region Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            UserInfo user = new UserInfo() { UserName = collection["UserName"], UserAge = Int16.Parse(collection["UserAge"].ToString()) };
            dbcontext.UserInfoSet.Add(user);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        public ActionResult Delete(int id, string name)
        {
            UserInfo user = new UserInfo() { UserId = id, UserName = name };
            ViewData.Model = user;
            return View();
        }

        #region Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            UserInfo user = new UserInfo() { UserId = id, UserName = "" };
            dbcontext.UserInfoSet.Attach(user);
            dbcontext.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        public ActionResult Edit(int id, string name)
        {
            UserInfo user = new UserInfo() { UserId = id, UserName = name };
            ViewData.Model = user;
            return View();
        }

        #region Edit
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            UserInfo user = new UserInfo() { UserId = int.Parse(collection["UserId"]), UserName = collection["UserName"], UserAge = Int16.Parse(collection["UserAge"]),
                                             ClassInfoClassId = int.Parse(collection["ClassInfoClassId"]), Email = collection["Email"]  };
            dbcontext.UserInfoSet.Attach(user);
            dbcontext.Entry(user).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}