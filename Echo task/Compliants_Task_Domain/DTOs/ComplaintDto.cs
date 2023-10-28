using Compliants_Task_Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Domain.DTOs
{
    public class ComplaintDto
    {
        public Guid Id { get; set; }
        
        public string UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public IFormFile UserIdentity { get; set; }

        public List<Demand> Demands { get; set; }
    }
}
