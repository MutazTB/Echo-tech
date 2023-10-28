using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Domain.Base.Interfaces
{
    public interface IBaseRepo<T>
    {
        Task<IList<T>> GetDataList();
        Task<T> GetDataRecord(Guid REQ);
        Task<int> Add(T REQ);
        Task<int> Update(Guid Id, T REQ);
        Task<int> Delete(T REQ);
    }
}
