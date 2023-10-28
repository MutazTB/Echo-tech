using Microsoft.AspNetCore.Authorization;
using Compliants_Task_Domain.common;
using Compliants_Task_Domain.DTOs;
using Compliants_Task_Domain.Refit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System.Collections.Generic;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Compliants_Task_Domain.Base;
using Compliants_Task_Domain.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Complaints_Task.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class ComplaintsController : Controller
    {
        private readonly IComplaintAPI _complaintAPI;
        private readonly IWebHostEnvironment _environment;

        public ComplaintsController(IComplaintAPI complaintAPI, IWebHostEnvironment webHostEnvironment)
        {
            _complaintAPI = complaintAPI;
            _environment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllComplaints()
        {
            List<ComplaintDto> Complaints = new List<ComplaintDto>();
            ReturnResult returnResult = await _complaintAPI.GetAllComplaints();
            if (returnResult.Status == Enums.ResultStatus.Error.ToString())
            {
                return BadRequest(returnResult);
            }
            else if (returnResult.Status == Enums.ResultStatus.NotAuthorize.ToString())
            {
                return RedirectToAction("Login", "Account");
            }
            return Ok(returnResult);
        }

        [HttpGet]
        [Route("AddComplaint")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateComplaint(ComplaintDto complaint)
        {
            try
            {
                var fileExtension = Path.GetExtension(complaint.UserIdentity.FileName);
                string nameOfImage = $"{fileExtension}";
                var filePath = Path.Combine(_environment.WebRootPath, "images", nameOfImage);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await complaint.UserIdentity.CopyToAsync(stream);
                }
                ReturnResult returnResult = await _complaintAPI.Add(complaint);
                if (returnResult.Status == Enums.ResultStatus.Error.ToString())
                {
                    return BadRequest(returnResult);
                }
                else if (returnResult.Status == Enums.ResultStatus.NotAuthorize.ToString())
                {
                    return RedirectToAction("Login", "Account");
                }
                return Ok(returnResult);
            }
            catch (Exception)
            {
                return BadRequest(new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = null,
                    Message = "Somthing went wrong...! \n Please try again later"
                });
            }
        }

        [HttpPost]
        [Route("Delete/{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid complaintId)
        {
            try
            {
                ReturnResult returnResult = await _complaintAPI.Delete(complaintId);
                if (returnResult.Status == Enums.ResultStatus.Error.ToString())
                {
                    return BadRequest(returnResult);
                }
                else if (returnResult.Status == Enums.ResultStatus.NotAuthorize.ToString())
                {
                    return RedirectToAction("Login", "Account");
                }
                return Ok(returnResult);
            }
            catch (Exception)
            {
                return BadRequest(new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = null,
                    Message = "Somthing went wrong...! \n Please try again later"
                });
            }
        }

        [HttpPost]
        [Route("Update/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] ComplaintDto complaint)
        {
            try
            {
                ReturnResult returnResult = await _complaintAPI.Update(Id , complaint);
                if (returnResult.Status == Enums.ResultStatus.Error.ToString())
                {
                    return BadRequest(returnResult);
                }
                else if (returnResult.Status == Enums.ResultStatus.NotAuthorize.ToString())
                {
                    return RedirectToAction("Login", "Account");
                }
                return Ok(returnResult);
            }
            catch (Exception)
            {
                return BadRequest(new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = null,
                    Message = "Somthing went wrong...! \n Please try again later"
                });
            }
        }

        [HttpPost]
        [Route("Reject/{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reject(Guid Id)
        {
            try
            {
                ReturnResult returnResult = await _complaintAPI.Reject(Id);
                if (returnResult.Status == Enums.ResultStatus.Error.ToString())
                {
                    return BadRequest(returnResult);
                }
                else if (returnResult.Status == Enums.ResultStatus.NotAuthorize.ToString())
                {
                    return RedirectToAction("Login", "Account");
                }
                return Ok(returnResult);
            }
            catch (Exception)
            {
                return BadRequest(new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = null,
                    Message = "Somthing went wrong...! \n Please try again later"
                });
            }
        }
        [HttpPost]
        [Route("Approve/{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(Guid Id)
        {
            try
            {
                ReturnResult returnResult = await _complaintAPI.Approve(Id);
                if (returnResult.Status == Enums.ResultStatus.NotAuthorize.ToString())
                {
                    return RedirectToAction("Login", "Account");
                }
                return Ok(returnResult);
            }
            catch (Exception)
            {
                return BadRequest(new ReturnResult
                {
                    Status = Enums.ResultStatus.Error.ToString(),
                    Code = "900",
                    Data = null,
                    Message = "Somthing went wrong...! \n Please try again later"
                });
            }
        }
    }
}
