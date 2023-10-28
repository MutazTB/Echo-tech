using Compliants_Task_Domain.common;
using Compliants_Task_Domain.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Domain.Refit
{
    public interface IDemandAPI
    {
        [Get("/GetAllDemands")]
        Task<ReturnResult> GetAllDemand();

        [Get("/GetDemand/{Id}")]
        Task<ReturnResult> GatDemand(Guid Id);

        [Post("/AddDemand")]
        Task<ReturnResult> Add([Body] Demand request);

        [Post("/UpdateDemand")]
        Task<ReturnResult> Update(Guid Id, [Body] Demand request);

        [Post("/DeleteDemand")]
        Task<ReturnResult> Delete(Guid Id);
    }
}
