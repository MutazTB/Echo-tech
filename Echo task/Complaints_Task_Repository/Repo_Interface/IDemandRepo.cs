using Compliants_Task_Domain.Base.Interfaces;
using Compliants_Task_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complaints_Task_Repository.Repo_Interface
{
    public interface IDemandRepo : IBaseRepo<Demand>
    {
        Task<List<Demand>> GetDemandByComplaintId(Guid ComplaintId);
    }
}
