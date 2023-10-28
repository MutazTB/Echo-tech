using Complaints_Task_Repository.Repo_Interface;
using Compliants_Task_Domain.DTOs;
using Compliants_Task_Service.Svc_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliants_Task_Service.Svc_Implementation
{
    public class UserSvc : IUserSvc
    {
        private IUserRepo _UserRepo;

        public UserSvc(IUserRepo userRepo) 
        {
            _UserRepo = userRepo;
        }
        public async Task Login(UserLogin viewModel)
        {
            await _UserRepo.Login(viewModel);
        }

        public async Task Logout()
        {
            await _UserRepo.Logout();
        }

        public async Task Register(UserRegister viewModel)
        {
            await _UserRepo.Register(viewModel);
        }
    }
}
