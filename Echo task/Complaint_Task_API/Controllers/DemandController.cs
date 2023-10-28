using Compliants_Task_Domain.common;
using Compliants_Task_Domain.Entities;
using Compliants_Task_Service.Svc_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Complaint_Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandController : ControllerBase
    {
        private readonly IDemandSvc _Demand;
        private readonly IConfiguration _Configuration;

        public DemandController(IDemandSvc demand, IConfiguration configuration)
        {
            _Demand = demand;
            _Configuration = configuration;
        }

        [HttpPost]
        [Route("AddDemand")]
        public Task<ReturnResult> Add([FromBody] Demand Request)
        {
            return _Demand.Add(Request);
        }

        [HttpGet]
        [Route("GetAllDemands")]
        public Task<ReturnResult> GetAll()
        {
            return _Demand.GetDataList();
        }

        [HttpGet]
        [Route("GetDemand/{Id}")]
        public Task<ReturnResult> GetById(Guid Id)
        {
            return _Demand.GetDataRecord(Id);
        }

        [HttpPost]
        [Route("DeleteDemand/{Id}")]
        public Task<ReturnResult> Delete(Guid Id)
        {
            return _Demand.Delete(Id);
        }

        [HttpPost]
        [Route("UpdateDemand")]
        public Task<ReturnResult> Update([FromBody] Demand request)
        {
            return _Demand.Update(request.Id, request);
        }

    }
}
