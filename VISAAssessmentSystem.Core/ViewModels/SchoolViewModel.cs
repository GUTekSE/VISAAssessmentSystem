using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VISAAssessmentSystem.Core.Models;

namespace VISAAssessmentSystem.Core.ViewModels
{
    public class SchoolViewModel
    {
        public School School { get; set; }
        public Country Country { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}
