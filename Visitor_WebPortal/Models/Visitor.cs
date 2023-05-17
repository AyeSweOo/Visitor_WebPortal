using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Visitor_WebPortal.Helper;

namespace Visitor_WebPortal.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name"), Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }
        [Display(Name = "Visit Type"), Required(ErrorMessage = "This field is required.")]
        public int VisitTypeId { get; set; }
        [Display(Name = "Is Foreigner")]
        public Boolean IsForeigner { get; set; }
        [Display(Name = "Company Name"), Required(ErrorMessage = "This field is required.")]
        public string CompanyName { get; set; }
        [Display(Name = "Mobile Phone"), Required(ErrorMessage = "This is required.")]
        public string MobilePhone { get; set; }
        [Display(Name = "Bussiness Email"), Required(ErrorMessage = "This is required.")]
        public string Email { get; set; }
        public string Designation { get; set; }
        [Display(Name = "License Plate"), Required(ErrorMessage = "This is required.")]
        public string LicensePlate { get; set; }
        [Display(Name = "NRIC/FIN Number"), Required(ErrorMessage = "This is required.")]
        public string NRIC { get; set; }
        [Display(Name = "1. Are you currently under a Quarantine order,Stay-Home notice?"), Required(ErrorMessage = "This field is required.")]
        public bool Quarantine { get; set; }
        [Display(Name = "2. Have you had close contact with a confirmed Covid-19 case in the past 14 days?"), Required(ErrorMessage = "This field is required.")]
        public bool Contact_CovidCase { get; set; }
        [Display(Name = "3. Do you have any fever or flu-like Symptoms?"), Required(ErrorMessage = "This field is required.")]
        public bool Symptoms { get; set; }

        [Display(Name = "By completing this online form,I acknowledge and consent to the collection,use,and disclosure of my personal data for security verification,access control and safety purposes")]
        [MustBeTrue(ErrorMessage = "You have to tick this checkbox.")]
        public Boolean Acknowledge { get; set; }
        public virtual VisitType VisitType { get; set; }

        //  public virtual VisitType visitType { get; set; }
    }
}
