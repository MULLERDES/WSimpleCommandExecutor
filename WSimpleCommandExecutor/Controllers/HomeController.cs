using Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSimpleCommandExecutor.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRunner<ITask> _runner;
        public HomeController(ITaskRunner<ITask> tr)
        {
            _runner = tr;
        }

        private object UID
        {
            get
            {
                return Session["UID"];
            }
        }
         
        public ActionResult Index()
        {
           
            var task = _runner.GetBytKey(UID);
            if (task != null&&task?.TaskStatus!= Status.created)
            {
                return RedirectToAction("ShowPrcess");
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetStatus()
        {
            var task = _runner.GetBytKey(UID);
            return Json(new
            {
                taskExists = task!=null,
                status = task?.TaskStatus,
                percentage = task?.Percentage
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ShowPrcess()
        {
            
            return View();
        }
        public ActionResult About()
        {
            _runner.PushAndRun(UID);
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}