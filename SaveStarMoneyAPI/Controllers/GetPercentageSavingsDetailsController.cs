using Microsoft.AspNetCore.Authorization;
using SaveStarMoneyAPI.Repository;

namespace SaveStarMoneyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GetPercentageSavingsDetailsController: ControllerBase
    {
        private readonly GetPercentageDetailsRepo _getPercentageDetailsRepo;

        public GetPercentageSavingsDetailsController(GetPercentageDetailsRepo getPercentageDetailsRepo)
        {
            _getPercentageDetailsRepo = getPercentageDetailsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetPercentageSavingsDetailsDto>>> GetPercentageDetails()
        {
            return Ok(await _getPercentageDetailsRepo.GetFixedSavingsDetails());
        }
    }
}
