using AutoMapper;
using Compliants_Task_Domain.common;
using Compliants_Task_Domain.DTOs;
using Compliants_Task_Domain.Entities;
using Compliants_Task_Service.Svc_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Complaint_Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintSvc _Complaint; 
        private readonly IConfiguration _Configuration;
        private readonly IMapper _mapper;

        public ComplaintController (IComplaintSvc complaint, IConfiguration configuration, IMapper mapper)
        {
            _Complaint = complaint;
            _Configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddComplaint")]
        public Task<ReturnResult> Add([FromBody] ComplaintDto Request)
        {            
            Complaint complaint = new Complaint();
            complaint = _mapper.Map<Complaint>(Request);
            ReturnResult returnResult = new ReturnResult();
            return _Complaint.Add(complaint);
        }

        [HttpGet]
        [Route("GetAllComplaints")]
        public Task<ReturnResult> GetAll()
        {
            return _Complaint.GetDataList();
        }

        [HttpGet]
        [Route("GetComplaint/{Id}")]
        public Task<ReturnResult> GetById(Guid Id)
        {
            return _Complaint.GetDataRecord(Id);
        }

        [HttpPost]
        [Route("DeleteComplaint/{Id}")]
        public Task<ReturnResult> Delete(Guid Id)
        {
            return _Complaint.Delete(Id);
        }

        [HttpPost]
        [Route("UpdateComplaint/{Id}")]
        public Task<ReturnResult> Update(Guid Id, [FromBody] ComplaintDto request)
        {
            Complaint complaint = new Complaint();
            complaint = _mapper.Map<Complaint>(Request);
            ReturnResult returnResult = new ReturnResult();
            return _Complaint.Update(Id, complaint);
        }

        [HttpPost]
        [Route("RejectComplaint/{Id}")]
        public Task<ReturnResult> Reject(Guid Id)
        {
            return _Complaint.Reject(Id);
        }

        [HttpPost]
        [Route("ApproveComplaint/{Id}")]
        public Task<ReturnResult> Approve(Guid Id)
        {
            return _Complaint.Approve(Id);
        }

    }
}
