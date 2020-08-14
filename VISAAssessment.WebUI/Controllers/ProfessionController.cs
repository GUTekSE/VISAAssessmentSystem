using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VISAAssessmentSystem.Core.Contracts;
using VISAAssessmentSystem.Core.Models;

namespace VISAAssessment.WebUI.Controllers
{
    public class ProfessionController : Controller
    {
        IRepository<Profession> context;

        public ProfessionController(IRepository<Profession> ProfessionContext)
        {
            this.context = ProfessionContext;
        }
        // GET: Profession
        public ActionResult Index()
        {
            List<Profession> profession = context.Collection().ToList();
            return View(profession);
        }

        public ActionResult Create()
        {
            Profession profession = new Profession();
            return View(profession);
        }

        [HttpPost]
        public ActionResult Create(Profession profession)
        {

            if (!ModelState.IsValid)
            {
                return View(profession);
            }
            else
            {
                int Id = context.FindMaxProfessionId();
                profession.ProfessionId = Id;

                context.Insert(profession);
                context.Commit();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(int Id)
        {

            Profession profession = context.FindIntId(Id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(profession);
            }
        }

        [HttpPost]
        public ActionResult Edit(Profession profession, int Id)
        {

            Profession professionToEdit = context.FindIntId(Id);
            if (professionToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(professionToEdit);
                }
                else
                {
                    professionToEdit.Name = profession.Name;
                    context.Commit();

                    return RedirectToAction("Index");
                }

            }
        }

        public ActionResult Delete(int Id)
        {
            Profession professionToDelete = context.FindIntId(Id);
            if (professionToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(professionToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            Profession professionToDelete = context.FindIntId(Id);
            if (professionToDelete == null)
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