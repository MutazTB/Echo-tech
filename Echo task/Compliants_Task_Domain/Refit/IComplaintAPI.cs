using Compliants_Task_Domain.common;
using Compliants_Task_Domain.DTOs;
using Compliants_Task_Domain.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Domain.Refit
{
    public interface IComplaintAPI
    {
        [Get("/GetAllComplaints")]
        Task<ReturnResult> GetAllComplaints();

        [Get("/GetComplaint/{Id}")]
        Task<ReturnResult> GatComplaint(Guid Id);

        [Post("/AddComplaint")]
        Task<ReturnResult> Add([Body] ComplaintDto request);

        [Post("/UpdateComplaint/{Id}")]
        Task<ReturnResult> Update(Guid Id, [Body] ComplaintDto request);

        [Post("/DeleteComplaint")]
        Task<ReturnResult> Delete(Guid Id);

        [Post("/RejectComplaint")]
        Task<ReturnResult> Reject(Guid Id);

        [Post("/ApproveComplaint")]
        Task<ReturnResult> Approve(Guid Id);
    }
}
