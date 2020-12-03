using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTTP5101Assignment3.Models;

namespace HTTP5101Assignment3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET : /Teacher/List
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }
        // GET : /Teacher/Show
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            ViewBag.Teacher = controller.FindTeacher(id);
            ClassDataController ClassController = new ClassDataController();
            ViewBag.Class = ClassController.FindTeacherClass(id);
            return View();
        }
        // POST : /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");

        }

        public ActionResult Add()
        {
            TeacherDataController controller = new TeacherDataController();

            return View();
        }
    }
}