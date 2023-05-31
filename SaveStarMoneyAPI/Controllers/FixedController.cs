using Microsoft.AspNetCore.Authorization;
using SaveStarMoneyAPI.Repository;

namespace SaveStarMoneyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FixedController: ControllerBase
    {
        private readonly FixedSavingRepo _fixedSavingRepo;

        public FixedController(FixedSavingRepo fixedSavingRepo)
        {
            _fixedSavingRepo = fixedSavingRepo;
        }

        [HttpPost("PercentageSavings")]
        public async Task<ActionResult<ServiceResponse<GetPercentSavingDto>>> Saving(FixedSavingDto fixedSavingDto)
        {
            return Ok(await _fixedSavingRepo.FixedSaving(fixedSavingDto));
        }
    }
}
