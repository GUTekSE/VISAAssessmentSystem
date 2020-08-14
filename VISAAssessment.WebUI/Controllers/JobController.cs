using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VISAAssessmentSystem.Core.Contracts;
using VISAAssessmentSystem.Core.Models;

namespace VISAAssessment.WebUI.Controllers
{
    public class JobController : Controller
    {
        IRepository<Job> context;

        public JobController(IRepository<Job> jobContext)
        {
            this.context = jobContext;
        }
        // GET: Job
        public ActionResult Index()
        {
            List<Job> jobs = context.Collection().ToList();
            return View(jobs);
        }

        public ActionResult Create()
        {
            Job job = new Job();
            return View(job);
        }

        [HttpPost]
        public ActionResult Create(Job job)
        {

            if (!ModelState.IsValid)
            {
                return View(job);
            }
            else
            {
                int Id = context.FindMaxJobId();
                job.JobId = Id;

                context.Insert(job);
                context.Commit();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(int Id)
        {

            Job job = context.FindIntId(Id);
            if (job == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(job);
            }
        }

        [HttpPost]
        public ActionResult Edit(Job job, int Id)
        {

            Job jobToEdit = context.FindIntId(Id);
            if (jobToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(jobToEdit);
                }
                else
                {
                    jobToEdit.Name = job.Name;
                    context.Commit();

                    return RedirectToAction("Index");
                }

            }
        }

        public ActionResult Delete(int Id)
        {
            Job jobToDelete = context.FindIntId(Id);
            if (jobToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(jobToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            Job jobToDelete = context.FindIntId(Id);
            if (jobToDelete == null)
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