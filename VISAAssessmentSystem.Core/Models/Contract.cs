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
    public class Contract: BaseEntity
    {
        [DisplayName("Contract No")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContractNo { get; set; }

        [DisplayName("Contract Date")]
        public DateTime ContractDate { get; set; }

        [DisplayName("Target Date")]
        public DateTime TargetDate { get; set; }

        [DisplayName("Contract Fee")]
        public Decimal ContractFee { get; set; }

        [DisplayName("Training Fee")]
        public Decimal TrainingFee { get; set; }

        [DisplayName("Show Money")]
        public Decimal ShowMoney { get; set; }

        [DisplayName("School Deposit")]
        public Decimal SchoolDeposit { get; set; }

        [DisplayName("File Review")]
        public Decimal FileReview { get; set; }

        [DisplayName("Other Payments")]
        public Decimal OtherPayment { get; set; }

        public string Currency { get; set; }

        //[ForeignKey("Client")]
        public string Id { get; set; }

        public virtual Client Clients { get; set; }

        //[ForeignKey("Program")]
        public int ProgramId { get; set; }
        public virtual Program Programs { get; set; }

    }
}
