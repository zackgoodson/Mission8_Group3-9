﻿using Microsoft.AspNetCore.Mvc;
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
                    .Where(x => x.Completed == false)
                    .ToList();

            return View(quad);
        }
        [HttpGet]
        public IActionResult Task ()
        {
            ViewBag.Categories = taskContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Task (TaskResponse tr)
        {
            if (ModelState.IsValid)
            {
                taskContext.Add(tr);
                taskContext.SaveChanges();

                return View("Quadrants");
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
        [HttpGet]
        public IActionResult Delete(int TaskId)
        {
            var task = taskContext.Responses.Single(x => x.TaskID == TaskId);

            return View(task);
        }
        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            taskContext.Responses.Remove(tr);
            taskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
