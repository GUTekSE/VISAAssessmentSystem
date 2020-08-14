using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VISAAssessmentSystem.Core.Models;

namespace VISAAssessmentSystem.Core.ViewModels
{
    public class ContractViewModel
    {
        public Contract Contract { get; set; }

        public Client Client { get; set; }

        public Program Program { get; set; }

        public IEnumerable<Program> Programs { get; set; }

    }
}
