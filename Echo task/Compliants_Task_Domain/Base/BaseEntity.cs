using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Domain.Base
{
    public class BaseEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifyBy { get; set; }

        public DateTime ModifyOn { get; set; }

        public bool IsDeleted { get; set; }

    }
}
