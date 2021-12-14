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
            var models = _studentDAL.GetAll();
            return View(models);
        }

        public IActionResult Details(string id)
        {
            var model = _studentDAL.GetById(id);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            try
            {
                _studentDAL.Insert(student);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["pesanerror"] = 
                    $"<span class='alert alert-danger'>Error: {ex.Message}</span>";
                return View();
            }
        }

        public IActionResult Edit(string id)
        {
            var model = _studentDAL.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            try
            {
                _studentDAL.Update(student);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["pesanerror"] = $"<span class='alert alert-danger'>{ex.Message}</span>";
                return View();
            }
        }

        public IActionResult Delete(string id)
        {
            var model = _studentDAL.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string id)
        {
            try
            {
                _studentDAL.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["pesanerror"] = ex.Message;
                var model = _studentDAL.GetById(id);
                return View(model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}