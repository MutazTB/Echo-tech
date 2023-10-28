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
    public class ComplaintSvc : IComplaintSvc
    {
        private IComplaintRepo _ComplaintRepo;
        public ComplaintSvc(IComplaintRepo complaintRepo)
        {
            _ComplaintRepo = complaintRepo;
        }
        public async Task<ReturnResult> Add(Complaint REQ)
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
                    REQ.Status = (int)Enums.ComplaintStatus.Pending;
                    result = await _ComplaintRepo.Add(REQ);
                    if (result > 0)
                    {
                        return new ReturnResult
                        {
                            Status = Enums.ResultStatus.Success.ToString(),
                            Code = "200",
                            Data = REQ,
                            Message = "Your complaint added successfully, please wait our response"
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
            Complaint complaint = new Complaint();
            try
            {
                complaint = await _ComplaintRepo.GetDataRecord(REQ);
                if (complaint != null)
                {
                    complaint.ModifyOn = DateTime.Now;
                    complaint.IsDeleted = true;
                    result = await _ComplaintRepo.Delete(complaint);
                }
                if (result > 0)
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Success.ToString(),
                        Code = "200",
                        Data = REQ,
                        Message = "Your complaint deleted successfully...!"
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
            List<Complaint> complaints = new List<Complaint>();
            try
            {
                complaints = (List<Complaint>)await _ComplaintRepo.GetDataList();
                if (complaints == null)
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
                        Data = complaints,
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
            Complaint complaint = new Complaint();
            try
            {
                complaint = await _ComplaintRepo.GetDataRecord(REQ);
                if (complaint == null)
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
                        Data = complaint,
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

        public bool IsValid(Complaint REQ)
        {
            if (REQ == null)
            {
                return false;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(REQ.Title))
                {
                    return false;
                }
                else if (String.IsNullOrWhiteSpace(REQ.Description)) 
                { 
                    return false; 
                }
            }
            return true;
        }

        public async Task<ReturnResult> Update(Guid Id, Complaint REQ)
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
                    REQ.ModifyOn = DateTime.Now;
                    result = await _ComplaintRepo.Update(Id, REQ);
                    if (result > 0)
                    {
                        return new ReturnResult
                        {
                            Status = Enums.ResultStatus.Success.ToString(),
                            Code = "200",
                            Data = REQ,
                            Message = "Your complaint updated successfully...!"
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

        public async Task<ReturnResult> Reject(Guid REQ)
        {
            int result = 0;
            Complaint complaint = new Complaint();
            try
            {
                complaint = await _ComplaintRepo.GetDataRecord(REQ);
                if (complaint != null)
                {
                    complaint.ModifyOn = DateTime.Now;
                    complaint.Status = (int)Enums.ComplaintStatus.Rejected;
                    result = await _ComplaintRepo.Update(REQ,complaint);
                }
                if (result > 0)
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Success.ToString(),
                        Code = "200",
                        Data = REQ,
                        Message = "The complaint rejected successfully...!"
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

        public async Task<ReturnResult> Approve(Guid REQ)
        {
            int result = 0;
            Complaint complaint = new Complaint();
            try
            {
                complaint = await _ComplaintRepo.GetDataRecord(REQ);
                if (complaint != null)
                {
                    complaint.ModifyOn = DateTime.Now;
                    complaint.Status = (int)Enums.ComplaintStatus.Approved;
                    result = await _ComplaintRepo.Update(REQ, complaint);
                }
                if (result > 0)
                {
                    return new ReturnResult
                    {
                        Status = Enums.ResultStatus.Success.ToString(),
                        Code = "200",
                        Data = REQ,
                        Message = "The complaint approved successfully...!"
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
    }
}
