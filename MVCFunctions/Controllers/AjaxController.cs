using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVCFunctions.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTime()
        {
            Thread.Sleep(2000);
            return Content(DateTime.Now.ToString());
        }
    }
}