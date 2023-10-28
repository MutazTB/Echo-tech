using Compliants_Task_Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Domain.Entities
{
    public class Demand : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string ComplaintDemand { get; set; }
        
        [Required]
        [ForeignKey("Complaint")]
        public Guid Complaint_Id { get; set; }

        public Complaint Complaint { get; set; }
    }
}
