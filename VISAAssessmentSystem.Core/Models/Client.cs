using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISAAssessmentSystem.Core.Models
{
     public class Client : BaseEntity
        {
            public string UserId { get; set; }

            [DisplayName("Client ID")]
            public string Id { get; set; }

            [DisplayName("Full Name")]
            public string Name { get; set; }
            public string Gender { get; set; }

            [DisplayName("Email Address")]
            public string Email { get; set; }

            [DisplayName("Mobile No 1")]
            public string MobileNo1 { get; set; }

            [DisplayName("Mobile No 2")]
            public string MobileNo2 { get; set; }

            [DisplayName("Marital Status")]
            public string MaritalStatus { get; set; }
            public int Age { get; set; }

            [DisplayName("No Of Children")]
            public int NoOfChildren { get; set; }
            public string Profession { get; set; }
            public string Course { get; set; }

            [DisplayName("Year Graduated")]
            public string YearGraduated { get; set; }
            public string Degree { get; set; }

            [DisplayName("Degree Status")]
            public string DegreeStatus { get; set; }

            [DisplayName("Degree Result")]
            public string DegreeResult { get; set; }

            [DisplayName("Present Job")]
            public string PresentJob { get; set; }

            [DisplayName("Year of Experience")]
            public int YearExperience { get; set; }

            [DisplayName("Present Address 1")]
            public string PresentAddress1 { get; set; }

            [DisplayName("Present Address 2")]
            public string PresentAddress2 { get; set; }

            [DisplayName("Phil. Address 1")]
            public string PhilAddress1 { get; set; }

            [DisplayName("Phil. Address 2")]
            public string PhilAddress2 { get; set; }

         public virtual ICollection<Contract> Contracts { get; set; }
    }
}
