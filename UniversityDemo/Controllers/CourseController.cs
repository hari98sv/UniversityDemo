using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UniversityDemo.Application.Interfaces;
using UniversityDemo.Application.ViewModels;
using UniversityDemo.Domain.Models;

namespace UniversityDemo.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CourseController(ICourseService courseService, IWebHostEnvironment webHostEnvironment)
        {
            _courseService = courseService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            CourseViewModel model = _courseService.GetCourses();
            return base.View(model);
        }
        
        public IActionResult CreateEdit()
        {
            return base.View();
        }
        
        public IActionResult Delete(int id)
        {
            _courseService.DeleteCourse(id);
            return Ok(new { success = true });
        }
        
        public IActionResult Edit(int id)
        {
            CourseViewModel course = null;

            try
            {
                course = _courseService.GetCourseById(id);
            }
            catch (Exception)
            {
            }

            if (course == null || course.Id < 1)
            {
                return NotFound(); // Handle not found case
            }

            var model = new CourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                ImageUri = course.ImageUri
            };

            return View("CreateEdit", model); // Redirect to the form view with data
        }

        public IActionResult CreateEditForm(CourseViewModel model)
        {
            if (model == null) 
            {
                return BadRequest();
            }

            if (model.Id < 1)
            {
                // Create new record
                _courseService.Create(model);
            }
            else
            {
                // Update existing records
                _courseService.Update(model);
            }

            return RedirectToAction("Index");
        }
    }
}
