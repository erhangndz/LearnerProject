﻿using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CourseRegisterController : Controller
    {
      LearnerContext context = new LearnerContext();

        [HttpGet]
        public ActionResult Index()
        {
            var courseList = context.Courses.ToList();

            List<SelectListItem> courses = (from x in courseList
                                            select new SelectListItem
                                            {
                                                Text = x.CourseName,
                                                Value = x.CourseId.ToString()
                                            }).ToList();

            ViewBag.course = courses;
            return View();
        }

        [HttpPost]
        public ActionResult Index(CourseRegister courseRegister)
        {
            string student = Session["studentName"].ToString();
            courseRegister.StudentId= context.Students.Where(x=>x.NameSurname==student).Select(x=>x.StudentId).FirstOrDefault();
            context.CourseRegisters.Add(courseRegister);
            context.SaveChanges();

            return RedirectToAction("Index", "StudentCourse");
        }
    }
}