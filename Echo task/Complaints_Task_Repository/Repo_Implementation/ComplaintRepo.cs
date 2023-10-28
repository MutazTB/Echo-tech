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
    public class ComplaintRepo : IComplaintRepo
    {
        private readonly ComplaintDBContext _Context;
        public ComplaintRepo(ComplaintDBContext context) 
        { 
            _Context = context;
        }
        public async Task<int> Add(Complaint REQ)
        {
            try
            {
                _Context.Entry(REQ).State = EntityState.Added;
                return await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }

        public async Task<int> Delete(Complaint REQ)
        {       
            _Context.Entry(REQ).State = EntityState.Modified;
            return await _Context.SaveChangesAsync();
        }

        public async Task<List<Complaint>> GetByStatus(int status)
        {
            return await _Context.Complaints.Where(C => C.Status == status && C.IsDeleted != true).ToListAsync();
        }

        public async Task<IList<Complaint>> GetDataList()
        {
            return await _Context.Complaints.Where(c => c.IsDeleted != true).ToListAsync();
        }

        public async Task<Complaint> GetDataRecord(Guid REQ)
        {
            return await _Context.Complaints.Where(C => C.Id == REQ && C.IsDeleted != true).SingleOrDefaultAsync();
        }

        public async Task<int> Update(Guid Id, Complaint REQ)
        {
            _Context.Entry(REQ).State = EntityState.Modified;
            return await _Context.SaveChangesAsync();
        }
    }
}
