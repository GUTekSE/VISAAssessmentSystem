using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using VISAAssessmentSystem.Core.Contracts;
using VISAAssessmentSystem.Core.Models;
using VISAAssessmentSystem.Core.ViewModels;

namespace VISAAssessment.WebUI.Controllers
{
    public class ClientManagerController : Controller
    {
        IRepository<Client> context;
        IRepository<Contract> Dbcontracts;
        IRepository<Program> Dbprograms;
        //Constructor
        public ClientManagerController(IRepository<Client> clientContext, IRepository<Contract> contractContext, IRepository<Program> programContext)
        {
            this.context = clientContext;
            this.Dbcontracts = contractContext;
            this.Dbprograms = programContext;
        }

        // GET: ClientManager
        public ActionResult Index()
        {
            List<Client> clients = context.Collection().ToList();
            return View(clients);
        }

        public ActionResult Create()
        {
            Client client = new Client();
            return View(client);
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {

            if (!ModelState.IsValid)
            {
                return View(client);
            }
            else
            {


                //string recordNo = context.FindMaxClientID();
                //client.RecordNo = recordNo;
                string Id = context.FindMaxClientID();
                client.Id = Id;

                context.Insert(client);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(String Id)
        {
            Client clientToView = context.FindStringId(Id);
            if (clientToView == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(clientToView);
            }
        }

        public ActionResult Edit(String Id)
        {
            Client client = context.FindStringId(Id);
            if (client == null)
            {
                return HttpNotFound();
            }
            else
            {
                //ClientManagerViewModel viewModel = new ClientManagerViewModel();
                //viewModel.Client = client;

                //return View(viewModel);
                return View(client);
            }
        }

        [HttpPost]
        public ActionResult Edit(Client client, string Id)
        {
            Client clientToEdit = context.FindStringId(Id);
            if (clientToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(client);
                }
                else
                {
                    clientToEdit.Name = client.Name;
                    clientToEdit.Gender = client.Gender;
                    clientToEdit.Email = client.Email;
                    clientToEdit.MobileNo1 = client.MobileNo1;
                    clientToEdit.MobileNo2 = client.MobileNo2;
                    clientToEdit.MaritalStatus = client.MaritalStatus;
                    clientToEdit.Age = client.Age;
                    clientToEdit.NoOfChildren = client.NoOfChildren;
                    clientToEdit.Profession = client.Profession;
                    clientToEdit.Course = client.Course;
                    clientToEdit.YearGraduated = client.YearGraduated;
                    clientToEdit.Degree = client.Degree;
                    clientToEdit.DegreeStatus = client.DegreeStatus;
                    clientToEdit.DegreeResult = client.DegreeResult;
                    clientToEdit.PresentJob = client.PresentJob;
                    clientToEdit.YearExperience = client.YearExperience;
                    clientToEdit.PresentAddress1 = client.PresentAddress1;
                    clientToEdit.PresentAddress2 = client.PresentAddress2;
                    clientToEdit.PhilAddress1 = client.PhilAddress1;
                    clientToEdit.PhilAddress2 = client.PhilAddress2;

                    context.Commit();
                    return RedirectToAction("Index");
                }
            }

        }

        public ActionResult Delete(string Id)
        {
            Client clientToDelete = context.FindStringId(Id);
            if (clientToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(clientToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Client clientToDelete = context.FindStringId(Id);
            if (clientToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.DeleteStringId(Id);
                context.Commit();
                return RedirectToAction("Index");
            }

        }

        public ActionResult AddContract(String Id)
        {

            int contractNo = FindContract(Id);

            if (contractNo > 0)
            {
                return RedirectToAction("EditContract",  new { Id = contractNo });
            }
            else
            {

                Client client = context.FindStringId(Id);
                if (client == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.Id = Id;
                    ContractViewModel viewModel = new ContractViewModel();

                    viewModel.Contract = new Contract();
                    viewModel.Programs = Dbprograms.Collection();
                    return View(viewModel);
                }
            }
            
        }

        [HttpPost]
        public ActionResult AddContract(Contract contract, string Id)
        {
            if (!ModelState.IsValid)
            {
                return View(contract);
            }
            else
            {

                int ContractNo = context.FindMaxContractNo();

                contract.ContractNo = ContractNo;
                contract.Id = Id;

                Dbcontracts.Insert(contract);
                Dbcontracts.Commit();

                return RedirectToAction("Index");
            }

        }

        
        public ActionResult EditContract(int Id)
        {
            Contract contract = Dbcontracts.FindIntId(Id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            else
            {
                ContractViewModel viewModel = new ContractViewModel();
                //viewModel.Contract.ContractNo = contract.ContractNo;
                //viewModel.Contract.ContractDate = contract.ContractDate;
                //viewModel.Contract.TargetDate = contract.TargetDate;
                //viewModel.Contract.ContractFee = contract.ContractFee;
                //viewModel.Contract.TrainingFee = contract.TrainingFee;
                //viewModel.Contract.ShowMoney = contract.ShowMoney;
                //viewModel.Contract.SchoolDeposit = contract.SchoolDeposit;
                //viewModel.Contract.FileReview = contract.FileReview;
                //viewModel.Contract.OtherPayment = contract.OtherPayment;
                //viewModel.Contract.Currency = contract.Currency;
                //viewModel.Contract.ProgramId = contract.ProgramId;

                viewModel.Contract = contract;
                viewModel.Programs = Dbprograms.Collection();

                return View(viewModel);
            }

        }

        [HttpPost]
        public ActionResult EditContract(Contract contract, int Id)
        {
            Contract contractToEdit = Dbcontracts.FindIntId(Id);
            if (contractToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(contract);
                }
                else
                {
                    //contractToEdit.ContractNo = contract.ContractNo;
                    contractToEdit.ContractDate = contract.ContractDate;
                    contractToEdit.TargetDate = contract.TargetDate;
                    contractToEdit.ContractFee = contract.ContractFee;
                    contractToEdit.TrainingFee = contract.TrainingFee;
                    contractToEdit.FileReview = contract.FileReview;
                    contractToEdit.ShowMoney = contract.ShowMoney;
                    contractToEdit.SchoolDeposit = contract.SchoolDeposit;
                    contractToEdit.OtherPayment = contract.OtherPayment;
                    contractToEdit.Currency = contract.Currency;
                    contractToEdit.ProgramId = contract.ProgramId;
                    contractToEdit.Id = contract.Id;

                    Dbcontracts.Commit();
                    return RedirectToAction("Details",  new { id = contract.Id });
                    
                }
            }

        }

        private int FindContract(string Id) 
        {
            int contractNo = Dbcontracts.FindClientContractNo(Id);
            
            return contractNo;
            
        }
    }
}