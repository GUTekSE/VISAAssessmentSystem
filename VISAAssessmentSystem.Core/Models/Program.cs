using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISAAssessmentSystem.Core.Models
{
    public class Program: BaseEntity
    {
        [DisplayName("Program Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProgramId { get; set; }

        [DisplayName("Program Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        public int SchoolId { get; set; } //FK

        public virtual School Schools { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
