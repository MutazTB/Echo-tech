using Complaints_Task_Repository.Repo_Interface;
using Compliants_Task_Domain.Data;
using Compliants_Task_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complaints_Task_Repository.Repo_Implementation
{
    public class DemandRepo : IDemandRepo
    {
        private readonly ComplaintDBContext _Context;
        public DemandRepo(ComplaintDBContext context)
        {
            _Context = context;
        }
        public async Task<int> Add(Demand REQ)
        {
            _Context.Entry(REQ).State = EntityState.Added;
            return await _Context.SaveChangesAsync();
        }

        public async Task<int> Delete(Demand REQ)
        {
            _Context.Entry(REQ).State = EntityState.Deleted;
            return await _Context.SaveChangesAsync();
        }

        public async Task<IList<Demand>> GetDataList()
        {
            return await _Context.Demands.ToListAsync();
        }

        public async Task<Demand> GetDataRecord(Guid REQ)
        {
            return await _Context.Demands.Where(C => C.Id == REQ && C.IsDeleted != true).SingleOrDefaultAsync();
        }

        public async Task<List<Demand>> GetDemandByComplaintId(Guid ComplaintId)
        {
            return await _Context.Demands.Where(C => C.Complaint_Id == ComplaintId && C.IsDeleted != true).ToListAsync();
        }

        public async Task<int> Update(Guid Id, Demand REQ)
        {
            _Context.Entry(REQ).State = EntityState.Modified;
            return await _Context.SaveChangesAsync();
        }
    }
}
