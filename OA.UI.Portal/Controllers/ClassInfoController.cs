using OA.BLL;
using OA.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UI.Portal.Controllers
{
    public class ClassInfoController : Controller
    {
        // GET: ClassInfo
        ClassInfoService service = new ClassInfoService();
        public ActionResult Index()
        {
            ViewData.Model = service.ShowData();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            ClassInfo klass = new ClassInfo() { ClassName = collection["ClassName"] };
            service.Add(klass);
            return RedirectToAction("Index");
        }
    }
}