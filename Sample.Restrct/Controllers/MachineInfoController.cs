using Microsoft.AspNetCore.Mvc;
using Sample.Restrct.Models;
using Sample.Restrct.Services;

namespace Sample.Restrct.Controllers
{
    public class MachineInfoController : Controller
    {
        private readonly IMachineInfoService _machineInfoService;

        public MachineInfoController(IMachineInfoService machineInfoService)
        {
            _machineInfoService = machineInfoService;
        }
        [HttpPost]
        public IActionResult Upsert([FromBody] UserMachineInfoModel userMachineInfo)
        {
            return Ok(_machineInfoService.Upsert(userMachineInfo));
        }
    }
}
