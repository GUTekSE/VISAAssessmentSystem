using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VISAAssessmentSystem.Core.Contracts;
using VISAAssessmentSystem.Core.Models;

namespace VISAAssessment.WebUI.Controllers
{
    public class CourseController : Controller
    {
        IRepository<Course> context;

        public CourseController(IRepository<Course> courseContext)
        {
            this.context = courseContext;
        }

        // GET: Course
        public ActionResult Index()
        {
            List<Course> courses = context.Collection().ToList();
            return View(courses);
        }

        public ActionResult Create()
        {
            Course course = new Course();
            return View(course);
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {

            if (!ModelState.IsValid)
            {
                return View(course);
            }
            else
            {
                int Id = context.FindMaxCourseId();
                course.CourseId = Id;

                context.Insert(course);
                context.Commit();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(int Id)
        {

            Course course = context.FindIntId(Id);
            if (course == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(course);
            }
        }

        [HttpPost]
        public ActionResult Edit(Course course, int Id)
        {

            Course courseToEdit = context.FindIntId(Id);
            if (courseToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(courseToEdit);
                }
                else
                {
                    courseToEdit.Name = course.Name;
                    context.Commit();

                    return RedirectToAction("Index");
                }

            }
        }

        public ActionResult Delete(int Id)
        {
            Course courseToDelete = context.FindIntId(Id);
            if (courseToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(courseToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            Course courseToDelete = context.FindIntId(Id);
            if (courseToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.DeleteIntId(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}