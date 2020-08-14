using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace VISAAssessmentSystem.Core.Models
{
    public class Country: BaseEntity
    {
        
        [DisplayName("Country Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }

        [DisplayName("Country Name")]
        public string Name { get; set; }

        public virtual ICollection<School> Schools { get; set; }
    }
}
