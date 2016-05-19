using Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSimpleCommandExecutor.Models;

namespace WSimpleCommandExecutor.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRunner<ITask> _runner;
        public HomeController(ITaskRunner<ITask> tr)
        {
            _runner = tr;
        }

        private object UID => Session["UID"];

        [HttpGet]
        public ActionResult ReadyToStart()
        {
            var task = _runner.GetBytKey(UID);
            if (task != null)
            {
                //exists for this session
                if (task.TaskStatus != Status.running)
                {
                    //ready to start
                    return View();
                }
                //else task.Start();

                return RedirectToAction("ShowProces");
            }
            return View();
        }

        [HttpPost]
        public ActionResult ReadyToStart(StartTaskViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
                
            var task = _runner.GetBytKey(UID);
            if (task != null)
            {
                //exists for this session
                if (task.TaskStatus != Status.running)
                {
                    task.Start(new Params() { Name = model.Name, Parameters = model.Params});
                }
            }
            else
            {
                //create new task
                
                _runner.PushAndRun(UID, new Params() { Name = model.Name, Parameters = model.Params});
            }
            return RedirectToAction("ShowProces");
        }


        [HttpGet]
        public JsonResult GetStatus()
        {
            var task = _runner.GetBytKey(UID);
            return Json(new
            {
                taskExists = task!=null,
                status = task?.TaskStatus.ToString(),
                percentage = task?.Percentage,
                rawdata = task?.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ShowProces()
        {
            
            return View();
        }

        
        public ActionResult BreakCurrrentSessionTask()
        {
            var task = _runner.GetBytKey(UID);
            if (task != null)
            {
                _runner.Terminate(UID);
                //return RedirectToAction(nameof(ReadyToStart));
            }
            return RedirectToAction(nameof(ReadyToStart));
        }
    }
}