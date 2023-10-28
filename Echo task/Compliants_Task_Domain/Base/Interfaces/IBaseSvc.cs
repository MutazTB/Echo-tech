using Compliants_Task_Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Domain.Base.Interfaces
{
    public interface IBaseSvc<T>
    {
        Task<ReturnResult> GetDataList();
        Task<ReturnResult> GetDataRecord(Guid REQ);
        Task<ReturnResult> Add(T REQ);
        Task<ReturnResult> Update(Guid Id, T REQ);
        Task<ReturnResult> Delete(Guid REQ);
        bool IsValid(T REQ);
    }
}
