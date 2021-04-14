using Sample.Restrct.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Restrct.Models
{
    public class UserMachineDetailModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public int? MachineInfoId { get; set; }
        public DateTime? MachineinfoLastupdatedAt { get; set; }
        public TrustStatus? TrustStatus { get; set; }
    }
}

