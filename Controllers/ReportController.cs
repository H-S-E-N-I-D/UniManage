using Microsoft.AspNetCore.Mvc;
using UniManage.Models;
using UniManage.Services;

namespace UniManage.Controllers
{
    public class ReportController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ICourseService _courseService;


        public ReportController(IDepartmentService departmentService, ICourseService courseService)
        {
            _departmentService = departmentService
                ?? throw new ArgumentNullException(nameof(departmentService));
            _courseService = courseService
            ?? throw new ArgumentNullException(nameof(courseService));
            _courseService = courseService;
        }


        // GET: CourseController1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentPerformance()
        {
            return View();
        }

        public ActionResult CoursePerformance()
        {
            return View();
        }
        public ActionResult ModulePerformance()
        {
            return View();
        }
        public ActionResult LecturerPerformance()
        {
            return View();
        }
        public ActionResult LecturerWorkload()
        {
            return View();
        }
        public ActionResult CoursePopularity()
        {
            return View();
        }
        public ActionResult SystemAuditLog()
        {
            return View();
        }
        public ActionResult SystemPerformance()
        {
            return View();
        }
        public ActionResult StudentGrading()
        {
            return View();
        }

        
        // POST: CourseController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
