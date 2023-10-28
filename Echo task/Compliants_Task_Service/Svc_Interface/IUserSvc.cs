using Compliants_Task_Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Service.Svc_Interface
{
    public interface IUserSvc
    {
        public Task Register(UserRegister viewModel);

        public Task Login(UserLogin viewModel);

        public Task Logout();
    }
}
