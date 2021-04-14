using Sample.Restrct.Data;
using Sample.Restrct.Data.Entities;
using Sample.Restrct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Restrct.Services
{
    public class AuthService : IAuthService
    {
        private readonly ECommerceDataContext _context;
        public AuthService(ECommerceDataContext context)
        {
            _context = context;
        }
        public LoginResponse Login(UserModel userModel)
        {
            UserMachineDetailModel userMachineDetails = (from u in _context.Users.Where(x => x.Email == userModel.Email && x.Password == userModel.Password)
                                                         join um in _context.UserMachines on u.Id equals um.UserId into machineResult
                                                         from mr in machineResult.DefaultIfEmpty()
                                                         select new UserMachineDetailModel
                                                         {
                                                             Email = u.Email,
                                                             UserId = u.Id,
                                                             MachineInfoId = mr.Id,
                                                             MachineinfoLastupdatedAt = mr.LastUpdated,
                                                             TrustStatus = mr.TrustStatus
                                                         }).FirstOrDefault();

            if (userMachineDetails is null)
                return new LoginResponse { IsSuccess = false, Message = "Invalid credentials" };
            else if (userMachineDetails.TrustStatus.HasValue && userMachineDetails.TrustStatus.Value == TrustStatus.Fail)
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = "Please login to this applicatino from only one device"
                };
            }
            else if (!userMachineDetails.MachineinfoLastupdatedAt.HasValue
                    || !IsUserMachineInfoUpdatedRecent(userMachineDetails.MachineinfoLastupdatedAt))
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = "Make sure the desktop application is running in background " +
                    ",enter your mail id and keep it sync"
                };
            }
            else
            {
                return new LoginResponse { IsSuccess = true };
            }
        }

        private bool IsUserMachineInfoUpdatedRecent(DateTime? lastUpdated)
        {
            if (!lastUpdated.HasValue)
                return false;

            DateTime machineinfoLastupdatedAt = lastUpdated.GetValueOrDefault();
            DateTime end = DateTime.UtcNow;
            DateTime start = DateTime.UtcNow.AddSeconds(-12);
            return (start <= machineinfoLastupdatedAt && machineinfoLastupdatedAt <= end);
        }
    }
}
