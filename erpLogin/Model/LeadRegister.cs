using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace erpLogin.Model
{
    public class LeadRegister
    {
        public string? Id { get; set; }
        [Required]
        public string LeadName { get; set; }
        [Required]
        public string LeadMobileNo { get; set; }
        [Required]
        public string Location { get; set; }
        public string? LeadAddress {get; set;}
        public string? LeadEmail { get; set;}
        [Required]
        public string HighLevelRequirement { get; set;}
        
        public string? LeadStatus { get; set;}
        
        public string? LeadFeasibility {  get; set;}  
        
        public string? Remarks { get; set;}

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDate { get; set; }
    }
}
