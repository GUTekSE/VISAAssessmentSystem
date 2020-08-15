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
    public class Job: BaseEntity
    {
        [DisplayName("Type No")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeNo { get; set; }

        [DisplayName("Type Name")]
        public string Name { get; set; }
    }
}
