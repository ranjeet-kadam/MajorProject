using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace EChallan.Web.Models
{
        [Table(name: "PaymentMethods")]
        public class PaymentMethod
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "Payment Method ID")]
            public int PaymentMethodId { get; set; }

            [Required(ErrorMessage = "{0} Should be Mentioned")]
            [StringLength(50)]
            [MinLength(2, ErrorMessage = "{0} Should Be Valid")]
            [MaxLength(50, ErrorMessage = "{0} Should Be Valid")]
            [Display(Name = "Payment Method")]
            public string PaymentMethodName { get; set; }

            [Required]
            [DefaultValue(true)]
            [Display(Name = "Method Enabled")]
            public bool MethodEnabled { get; set; }

            public int Price { get; set; }
            [ForeignKey(nameof(PaymentMethod.Price))]
            public ChallanDetails ChallanDetails { get; set; }

       

    }
}
