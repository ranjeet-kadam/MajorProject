using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using EChallan.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace EChallan.Web.Models
{
    
    [Table(name: "ChallaNumberDetails")]
    public class ChallaNumberDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CID { get; set; }

        [Required(ErrorMessage ="It's An Required Field")]
        [Display(Name ="Challan Number")]
        public string ChallanNumber { get; set; }

        [Required(ErrorMessage = "It's An Required Field")]
        [Display(Name = "Vehical Number")]
        public string VehicalNumber { get; set; }

        public ICollection<ChallanDetails> ChallanDetails { get; set; }

    }
}
