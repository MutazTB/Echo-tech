using Compliants_Task_Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Domain.Entities
{
    public class Complaint : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string UserId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set;}

        [Required]
        public int Status { get; set; }
        
        [AllowNull]
        public string UserIdentity { get; set; }

        //public List<Demand> Demands { get; set; }
    }
}
