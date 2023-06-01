using Microsoft.AspNetCore.Authorization;
using SaveStarMoneyAPI.Repository;

namespace SaveStarMoneyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FixedSavingsController: ControllerBase
    {
        private readonly FixedSavingRepo _fixedSavingRepo;

        public FixedSavingsController(FixedSavingRepo fixedSavingRepo)
        {
            _fixedSavingRepo = fixedSavingRepo;
        }

        [HttpPost("FixedSavings")]
        public async Task<ActionResult<ServiceResponse<GetFixedSavingDto>>> FixedSavings(FixedSavingDto fixedSavingDto)
        {
            return Ok(await _fixedSavingRepo.FixedSaving(fixedSavingDto));
        }
    }
}
