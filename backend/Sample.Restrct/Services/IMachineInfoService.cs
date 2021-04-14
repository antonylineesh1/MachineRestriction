using Sample.Restrct.Data.Queries;
using Sample.Restrct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Restrct.Services
{
    public interface IMachineInfoService
    {
        IEnumerable<UsemachineInfoResultSet> Upsert(UserMachineInfoModel userMachine);
    }
}
