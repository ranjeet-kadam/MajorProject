using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EChallan.Web.Models;

namespace EChallan.Web.Models
{
    [Table(name: "ChallaDetails")]
    public class ChallanDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CDID { get; set; }

        [Required(ErrorMessage ="{0} is an required field")]
        [Display(Name = "Fine")]
        public int Price { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage ="Date is required")]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; } = DateTime.Now;

        public int CID { get; set; }

        [ForeignKey(nameof(ChallanDetails.CID))]
        public ChallaNumberDetail ChallaNumberDetail { get; set; }

        public int IID { get; set; }

        [ForeignKey(nameof(ChallanDetails.IID))]
        public Issue Issue { get; set; }

        public ICollection<PaymentMethod> PaymentMethods{ get; set; }

    }
}
