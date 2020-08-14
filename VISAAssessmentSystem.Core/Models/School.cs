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
    public class School: BaseEntity
    {
        [DisplayName("School Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SchoolId { get; set; }

        [DisplayName("School Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manager { get; set; }
        public string ContactNo { get; set; }

        public string Date { get; set; }

        public int CountryId { get; set; } //FK

        public virtual Country Countries { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }

}
