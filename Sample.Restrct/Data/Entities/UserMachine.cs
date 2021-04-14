using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Restrct.Data.Entities
{
    public class UserMachine
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string MacAdress { get; set; }
        public TrustStatus TrustStatus { get; set; }
        public DateTime LastUpdated { get; set; }


    }
    public enum TrustStatus 
    {
        Success=1,
        Fail=2
    }
}
