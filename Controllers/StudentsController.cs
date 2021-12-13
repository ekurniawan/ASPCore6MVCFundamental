using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleASP.DAL;
using SampleASP.Models;

namespace SampleASP.Controllers
{
    public class StudentsController : Controller
    {
        private ILogger<StudentsController> _logger;
        private IStudentDAL _studentDAL;

        public StudentsController(ILogger<StudentsController> logger,
            IStudentDAL studentDAL)
        {
            _logger = logger;
            _studentDAL = studentDAL;
        }

        public IActionResult Index()
        {
            var student = new Student{
                StudentID = "778898",
                FirstName = "Erick",
                LastName = "Kurniawan",
                EnrollmentDate = DateTime.Now
            };

            List<string> lstHobby = new List<string>{
                "Sepedaan","Game","Baca Buku"
            };

            ViewData["lsthobby"] = lstHobby;
            ViewData["username"] = "ekurniawan";
            ViewBag.Aturan = "admin";

            return View(student);
        }

        public IActionResult GetStudents(){
            var models = _studentDAL.GetAll();
            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}