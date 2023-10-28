using Complaints_Task_Repository.Repo_Implementation;
using Complaints_Task_Repository.Repo_Interface;
using Compliants_Task_Domain.Base;
using Compliants_Task_Domain.common;
using Compliants_Task_Domain.Entities;
using Compliants_Task_Service.Svc_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Service.Svc_Implementation
{
    public class DemandSvc : IDemandSvc
    {
        private IDemandRepo _DemandRepo;

        public DemandSvc(IDemandRepo demandRepo) 
        {
            _DemandRepo = demandRepo;
        }

        public async Task<ReturnResult> Add(Demand REQ)
        {
            int result = 0;
            try
            {
                if (!IsValid(REQ))
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Error.ToString(),
                        Code = "900",
                        Data = null,
                        Message = "Please check your data..!"
                    };
                }
                else
                {
                    result = await _DemandRepo.Add(REQ);
                    if (result > 0)
                    {
                        return new ReturnResult
                        {
                            Status = Enums.ResultStatus.Success.ToString(),
                            Code = "200",
                            Data = REQ,
                            Message = "Your Demands added successfully, please wait our response"
                        };
                    }
                    else
                    {
                        return new ReturnResult
                        {
                            Status = Enums.ResultStatus.Error.ToString(),
                            Code = "900",
                            Data = null,
                            Message = "Somthing went wrong...! \n Please try again later"
                        };
                    }
                }
            }
            catch (Exception)
            {
                return new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = null,
                    Message = "Somthing went wrong...! \n Please try again later"
                };
            }
        }

        public async Task<ReturnResult> Delete(Guid REQ)
        {
            int result = 0;
            Demand demand = new Demand();
            try
            {
                demand = await _DemandRepo.GetDataRecord(REQ);
                if (demand != null)
                {
                    demand.ModifyOn = DateTime.Now;
                    demand.IsDeleted = true;
                    result = await _DemandRepo.Delete(demand);
                }
                if (result > 0)
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Success.ToString(),
                        Code = "200",
                        Data = REQ,
                        Message = "Your Demand deleted successfully...!"
                    };
                }
                else
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Error.ToString(),
                        Code = "900",
                        Data = null,
                        Message = "Somthing went wrong...! \n Please try again later"
                    };
                }
            }
            catch (Exception)
            {
                return new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = null,
                    Message = "Somthing went wrong...! \n Please try again later"
                };
            }
        }

        public async Task<ReturnResult> GetDataList()
        {
            List<Demand> demands = new List<Demand>();
            try
            {
                demands = (List<Demand>)await _DemandRepo.GetDataList();
                if (demands == null)
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Error.ToString(),
                        Code = "900",
                        Data = null,
                        Message = "Somthing went wrong...! \n Please try again later"
                    };
                }
                else
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Success.ToString(),
                        Code = "200",
                        Data = demands,
                        Message = ""
                    };
                }
            }
            catch (Exception)
            {
                return new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = null,
                    Message = "Somthing went wrong...! \n Please try again later"
                };
            }
        }

        public async Task<ReturnResult> GetDataRecord(Guid REQ)
        {
            Demand demand = new Demand();
            try
            {
                demand = await _DemandRepo.GetDataRecord(REQ);
                if (demand == null)
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Error.ToString(),
                        Code = "900",
                        Data = null,
                        Message = "Somthing went wrong...! \n Please try again later"
                    };
                }
                else
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Success.ToString(),
                        Code = "200",
                        Data = demand,
                        Message = ""
                    };
                }
            }
            catch (Exception)
            {
                return new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = null,
                    Message = "Somthing went wrong...! \n Please try again later"
                };
            }
        }

        public async Task<ReturnResult> GetDemandByComplaintId(Guid complaintId)
        {
            List<Demand> demands = new List<Demand>();
            try
            {
                demands = await _DemandRepo.GetDemandByComplaintId(complaintId);
                if (demands == null)
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Error.ToString(),
                        Code = "900",
                        Data = new List<Demand>(),
                        Message = "No demands for this complaint..!"
                    };
                }
                else
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Success.ToString(),
                        Code = "200",
                        Data = demands,
                        Message = ""
                    };
                }
            }
            catch (Exception)
            {
                return new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = new List<Demand>(),
                    Message = "Somthing went wrong...! \n Please try again later"
                };
            }
        }

        public bool IsValid(Demand REQ)
        {
            if (REQ == null)
            {
                return false;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(REQ.ComplaintDemand))
                {
                    return false;
                }
                else if (REQ.Complaint_Id == Guid.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<ReturnResult> Update(Guid Id, Demand REQ)
        {
            int result = 0;
            try
            {
                if (!IsValid(REQ))
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Error.ToString(),
                        Code = "900",
                        Data = null,
                        Message = "Please check your data..!"
                    };
                }
                else
                {
                    result = await _DemandRepo.Update(Id, REQ);
                    if (result > 0)
                    {
                        return new ReturnResult
                        {
                            Status = Enums.ResultStatus.Success.ToString(),
                            Code = "200",
                            Data = REQ,
                            Message = "Your Demand updated successfully...!"
                        };
                    }
                    else
                    {
                        return new ReturnResult
                        {
                            Status = Enums.ResultStatus.Error.ToString(),
                            Code = "900",
                            Data = null,
                            Message = "Somthing went wrong...! \n Please try again later"
                        };
                    }
                }
            }
            catch (Exception)
            {
                return new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = null,
                    Message = "Somthing went wrong...! \n Please try again later"
                };
            }
        }
    }
}
