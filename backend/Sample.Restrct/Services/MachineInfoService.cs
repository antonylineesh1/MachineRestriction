using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sample.Restrct.Data;
using Sample.Restrct.Data.Entities;
using Sample.Restrct.Data.Queries;
using Sample.Restrct.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Restrct.Services
{
    public class MachineInfoService : IMachineInfoService
    {
        private readonly ECommerceDataContext _context;

        public MachineInfoService(ECommerceDataContext context)
        {
            _context = context;
        }
        public IEnumerable<UsemachineInfoResultSet> Upsert(UserMachineInfoModel userMachine)
        {
            return _context.UsemachineInfoResultSet.FromSqlInterpolated($"EXECUTE dbo.UpsertUsermachineInfo {userMachine.Email},{userMachine.MacAddress}").AsNoTracking()
                    .AsEnumerable();
        }
    }
}
