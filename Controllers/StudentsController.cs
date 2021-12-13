using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleASP.Models;

namespace SampleASP.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var student = new Student{
                StudentID = 1,
                FirstName = "Erick",
                LastName = "Kurniawan",
                EnrollmentDate = DateTime.Now
            };

            ViewData["username"] = "ekurniawan";
            ViewBag.Role = "admin";

            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}