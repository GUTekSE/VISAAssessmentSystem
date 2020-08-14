using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VISAAssessmentSystem.Core.Models;

namespace VISAAssessmentSystem.Core.ViewModels
{
    public class ProgramViewModel
    {
        public Program Program { get; set; }

        public School School { get; set; }

        public IEnumerable<School> Schools { get; set; }
    }
}
