using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheRealMission8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace TheRealMission8.Controllers
{

    
    public class HomeController : Controller
    {
        private TaskContext taskContext { get; set; }
        public HomeController(TaskContext tasksub)
        {
            taskContext = tasksub;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Quadrants ()
        {
            var quad = taskContext.Responses
                    .Include(x => x.Category) 
                    .Where(x => x.Completed == false) // Filters to only output tasks that are not yet complete
                    .ToList();

            return View(quad);
        }

        // Returns Task page to allow for a new task to be inputted
        [HttpGet]
        public IActionResult Task ()
        {
            ViewBag.Categories = taskContext.Categories.ToList();

            return View();
        }

        // For submitting a new task
        [HttpPost]
        public IActionResult Task (TaskResponse tr)
        {
            if (ModelState.IsValid)
            {
                taskContext.Add(tr);
                taskContext.SaveChanges();

                return RedirectToAction("Quadrants");
            }
            else
            {
                ViewBag.Categories = taskContext.Categories.ToList();

                return View(tr);
            }
        }
    

        [HttpGet]
        public IActionResult Edit (int TaskId)
        {
            ViewBag.Categories = taskContext.Categories.ToList();
            var task = taskContext.Responses.Single(x => x.TaskID == TaskId);

            return View("Task", task);
        }
        [HttpPost]
        public IActionResult Edit (TaskResponse update)
        {   
            // Checks to make sure edits are in-line with form requirements, else returns the same page 
            if (ModelState.IsValid)
            {
                taskContext.Update(update);
                taskContext.SaveChanges();

                return RedirectToAction("Quadrants");
            }
            else
            {
                ViewBag.Categories = taskContext.Categories.ToList();
                return View("Task", update);
            }
        }

        // Gets delete page to confirm the user really wants to delete the task
        [HttpGet]
        public IActionResult Delete(int TaskId)
        {
            var task = taskContext.Responses.Single(x => x.TaskID == TaskId);

            return View(task);
        }

        // Removes the task from the database
        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            taskContext.Responses.Remove(tr);
            taskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
