using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using VISAAssessmentSystem.Core.Contracts;
using VISAAssessmentSystem.Core.Models;

namespace VISAAssessment.WebUI.Controllers
{
   
    public class CountryController : Controller
    {

        IRepository<Country> context;

        //Constructor
        public CountryController(IRepository<Country> countryContext)
        {
            context = countryContext;
        }

        // GET: Country
        public ActionResult Index()
        {
            List<Country> countries = context.Collection().ToList();
            return View(countries);
        }

        public ActionResult Create()
        {
            Country country = new Country();
            return View(country);
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {

            if (!ModelState.IsValid) 
            {
                return View(country);
            }
            else
            {
                int Id = context.FindMaxCountryId();
                country.CountryId = Id;

                context.Insert(country);
                context.Commit();
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Edit(int Id)
        {
            
            Country country = context.FindIntId(Id);
            if (country == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(country);
            }
        }

        [HttpPost]
        public ActionResult Edit(Country country, int Id)
        {

            Country countryToEdit = context.FindIntId(Id);
            if (countryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(country);
                }
                else
                {
                    countryToEdit.Name = country.Name;
                    context.Commit();

                    return RedirectToAction("Index");
                }
                
            }
        }

        
        public ActionResult Delete(int Id)
        {
            Country countryToDelete = context.FindIntId(Id);
            if (countryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(countryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            Country countryToDelete = context.FindIntId(Id);
            if (countryToDelete == null)
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