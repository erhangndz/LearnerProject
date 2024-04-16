﻿using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminDashboardController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            ViewBag.v1 = context.Courses.Count();
            ViewBag.v2 = context.Categories.Count();
            ViewBag.v3 = context.Classrooms.Count();
            ViewBag.v4 = context.Students.Count();
            ViewBag.v5 = context.Courses.OrderByDescending(x => x.Price).Select(x => x.CourseName).FirstOrDefault();
            ViewBag.v6 = context.Courses.Where(x => x.Category.CategoryName == "Kodlama").Count();
            ViewBag.v7 = context.Reviews.OrderByDescending(x=>x.ReviewValue).Select(x=>x.Course.CourseName).FirstOrDefault();
            return View();
        }
    }
}