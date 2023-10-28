using Compliants_Task_Domain.Base.Interfaces;
using Compliants_Task_Domain.common;
using Compliants_Task_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Service.Svc_Interface
{
    public interface IDemandSvc : IBaseSvc<Demand>
    {
        Task<ReturnResult> GetDemandByComplaintId(Guid ComplaintId);
    }
}
