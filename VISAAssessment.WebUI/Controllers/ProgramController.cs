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
    public class ProgramController : Controller
    {
        IRepository<Program> context;
        IRepository<School> schools;
        public ProgramController(IRepository<Program> programContext, IRepository<School> schoolContext)
        {
            this.context = programContext;
            this.schools = schoolContext;
        }
        // GET: Program
        public ActionResult Index()
        {

            List<Program> Programs = context.Collection().ToList();
            List<School> Schools = schools.Collection().ToList();

            var tableJoinList = from t1 in Programs
                             join t2 in Schools on t1.SchoolId equals t2.SchoolId
                             select new ProgramViewModel
                             {
                                 Program = t1,
                                 School = t2
                             };

            return View(tableJoinList);
        }
        public ActionResult Create()
        {
            ProgramViewModel viewModel = new ProgramViewModel();

            viewModel.Program = new Program();
            viewModel.Schools = schools.Collection();
            return View(viewModel);
        }

        [HttpPost]
        //public ActionResult Create(School school, HttpPostedFileBase file)
        public ActionResult Create(Program program)
        {
            if (!ModelState.IsValid)
            {
                return View(program);
            }
            else
            {

                //if (file != null)
                //{
                //    product.Image = product.Id + Path.GetExtension(file.FileName);
                //    file.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                //}
                int Id = context.FindMaxProgramId();
                program.ProgramId = Id;

                context.Insert(program);
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(int Id)
        {
            Program program = context.FindIntId(Id);
            if (program == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProgramViewModel viewModel = new ProgramViewModel();
                viewModel.Program = program;
                viewModel.Schools = schools.Collection();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Program program, int id)
        {

            Program programToEdit = context.FindIntId(id);
            if (programToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(program);
                }
                else
                {
                    programToEdit.Name = program.Name;
                    programToEdit.Description = program.Description;
                    programToEdit.SchoolId = program.SchoolId;
                    context.Commit();

                    return RedirectToAction("Index");
                }

            }
        }

        public ActionResult Delete(int Id)
        {
            Program program = context.FindIntId(Id);
            if (program  == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProgramViewModel viewModel = new ProgramViewModel();
                viewModel.Program = program;
                viewModel.Schools = schools.Collection();

                return View(viewModel);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            Program programToDelete = context.FindIntId(Id);

            if (programToDelete == null)
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