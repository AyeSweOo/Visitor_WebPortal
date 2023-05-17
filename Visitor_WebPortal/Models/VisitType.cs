using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Visitor_WebPortal.Models
{
    public class VisitType
    {
        public int VisitTypeId { get; set; }
        [Display(Name = "Visit Type")]
        public string VisitTypeName { get; set; }

        public virtual ICollection<Visitor> Visitor { get; set; }
    }
}
