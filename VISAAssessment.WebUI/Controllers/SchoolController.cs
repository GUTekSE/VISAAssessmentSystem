using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VISAAssessmentSystem.Core.Contracts;
using VISAAssessmentSystem.Core.Models;
using VISAAssessmentSystem.Core.ViewModels;

namespace VISAAssessment.WebUI.Controllers
{
    public class SchoolController : Controller
    {

        IRepository<School> context;
        IRepository<Country> countries;

        public SchoolController(IRepository<School> schoolContext, IRepository<Country> countryContext)
        {
            this.context = schoolContext;
            this.countries = countryContext;
        }

        
        // GET: School
        public ActionResult Index()
        {

            List<School> Schools = context.Collection().ToList();
            List<Country> Countries = countries.Collection().ToList();

            var tableJoinList = from t1 in Schools
                             join t2 in Countries on t1.CountryId equals t2.CountryId
                             select new SchoolViewModel
                             {
                                 School = t1,
                                 Country = t2
                             };

            return View(tableJoinList);
        }   
        public ActionResult Create()
        {
            SchoolViewModel viewModel = new SchoolViewModel();

            viewModel.School = new School();
            viewModel.Countries = countries.Collection();
            return View(viewModel);
        }

        [HttpPost]
        //public ActionResult Create(School school, HttpPostedFileBase file)
        public ActionResult Create(School school)
        {
            if (!ModelState.IsValid)
            {
                return View(school);
            }
            else
            {

                //if (file != null)
                //{
                //    product.Image = product.Id + Path.GetExtension(file.FileName);
                //    file.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                //}
                int Id = context.FindMaxSchoolId();
                school.SchoolId = Id;

                context.Insert(school);
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(int Id)
        {
            School school = context.FindIntId(Id);
            if (school == null)
            {
                return HttpNotFound();
            }
            else
            {
                SchoolViewModel viewModel = new SchoolViewModel();
                viewModel.School = school;
                viewModel.Countries = countries.Collection();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(School school, int id)
        {

            School schoolToEdit = context.FindIntId(id);
            if (schoolToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(school);
                }
                else
                {
                    schoolToEdit.Name = school.Name;
                    schoolToEdit.Description = school.Description;
                    schoolToEdit.Manager = school.Manager;
                    //schoolToEdit.Date = school.Date;
                    schoolToEdit.ContactNo = school.ContactNo;
                    schoolToEdit.CountryId = school.CountryId;
                    context.Commit();

                    return RedirectToAction("Index");
                }

            }
        }

        public ActionResult Delete(int Id) 
        {
            School school = context.FindIntId(Id);
            if (school == null)
            {
                return HttpNotFound();
            }
            else 
            {
                SchoolViewModel viewModel = new SchoolViewModel();
                viewModel.School = school;
                viewModel.Countries = countries.Collection();

                return View(viewModel);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            School schoolToDelete = context.FindIntId(Id);

            if (schoolToDelete == null)
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