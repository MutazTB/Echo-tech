using Compliants_Task_Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complaints_Task_Repository.Repo_Interface
{
    public interface IUserRepo
    {
        public Task Register(UserRegister viewModel);

        public Task Login(UserLogin viewModel);

        public Task Logout();

    }
}
