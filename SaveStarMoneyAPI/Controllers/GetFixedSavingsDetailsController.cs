using Microsoft.AspNetCore.Authorization;
using SaveStarMoneyAPI.Dtos;
using SaveStarMoneyAPI.Repository;

namespace SaveStarMoneyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GetFixedSavingsDetailsController: ControllerBase
    {
        private readonly GetFixedSavingDetailsRepo _getFixedSavingDetailsRepo;

        public GetFixedSavingsDetailsController(GetFixedSavingDetailsRepo getFixedSavingDetailsRepo)
        {
            _getFixedSavingDetailsRepo = getFixedSavingDetailsRepo;
        }

        [HttpGet("FixedSavingsDetails")]
        public async Task<ActionResult<ServiceResponse<GetFixedSavingDetailsDto>>> FixedSavingsDetails()
        {
            return Ok(await _getFixedSavingDetailsRepo.GetFixedSavingsDetails());
        }
    }
}
