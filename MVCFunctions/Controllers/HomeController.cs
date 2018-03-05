using MVCFunctions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFunctions.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            #region Weak Datatype
            //DropdownList
            ViewData["CityList"] = new List<SelectListItem>() {
                new SelectListItem(){ Selected=true, Text= "Bonn", Value ="1" },
                new SelectListItem(){ Selected= false, Text = "Köln", Value="2"}
            };
            ViewData["Person"] = new PersonInfo() { PersonID = 1, PersonName = "jack" };
            #endregion

            #region Stengh Datatype
            ViewData.Model = new PersonInfo() { PersonID = 2, PersonName = "He" };
            #endregion
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}