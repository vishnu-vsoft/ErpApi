using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string LeadStatus { get; set;}
        [Required]
        public string LeadFeasibility {  get; set;}  
        
        public string? Remarks { get; set;}
    }
}
