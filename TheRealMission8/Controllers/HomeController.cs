using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TheRealMission8.Models;

namespace TheRealMission8.Controllers
{
    private TaskContext _taskContext { get; set; }
    public class HomeController : Controller
    {


        public HomeController(TaskContext tasksub)
        {
            _taskContext = tasksub;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Quadrants()
        {
            var quad = _taskContext.Responses
                    .Include(x => x.Category)
                    .ToList();
            return View(quad);
        }
        [HttpGet]
        public IActionResult Task ()
        {
            ViewBag.Categories = _taskContext.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Task (TaskResponse tr)
        {
            if (ModelState.IsValid)
            {
                _taskContext.Add(tr);
                _taskContext.SaveChanges();
                return View("Quadrants", tr);
            }
            else
            {
                ViewBag.Categories = _taskContext.Categories.ToList();
                return View(tr)
            }
        }
    
        [HttpGet]
        public IActionResult Edit (int TaskId)
        {
            ViewBag.Categories = _taskContext.Categoris.ToList();
            var task = _taskContext.Responses.Single(x => x.TaskId == TaskId);
        }
        [HttpPost]
        public IActionResult Edit(update)
        {
            if (ModelState.IsValid)
            {
                _taskContext.Update(update);
                _taskContext.SaveChanges();

                return RedirectToAction("Quadrants");
            }
            else
            {
                ViewBag.Categories = _taskContext.Categories.ToList();
                return View("Task", update);
            }
        }
        [HttpGet]
        public IActionResult Delete(int TaskId)
        {
            var movie = _taskContext.Responses.Single(x => x.MovieId == TaskId);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            _taskContext.Responses.Remove(tr);
            _taskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }



    }
}
