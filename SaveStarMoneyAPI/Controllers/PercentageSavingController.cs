using Microsoft.AspNetCore.Authorization;
using SaveStarMoneyAPI.Repository;

namespace SaveStarMoneyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PercentageSavingController:ControllerBase
    {
        private readonly PercentageSavingRepo _percentageSavingRepo;

        public PercentageSavingController(PercentageSavingRepo percentageSavingRepo)
        {
            _percentageSavingRepo = percentageSavingRepo;
        }

        [HttpPost("PercentageSaving")]
        public async Task<ActionResult<ServiceResponse<GetPercentSavingDto>>> PercentageSaving(PercentSavingDto percentageSavingDto)
        {
            return Ok(await _percentageSavingRepo.PercentageSaving(percentageSavingDto));
        }
    }
}
