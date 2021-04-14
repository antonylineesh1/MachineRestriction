using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Restrct.Data.Queries
{
    [Keyless]
    public class UsemachineInfoResultSet
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
