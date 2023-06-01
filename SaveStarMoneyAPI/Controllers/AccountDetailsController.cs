using Microsoft.AspNetCore.Authorization;
using SaveStarMoneyAPI.Repository;

namespace SaveStarMoneyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountDetailsController: ControllerBase
    {
        private readonly AccountDetailsRepo _accountDetailsRepo;

        public AccountDetailsController(AccountDetailsRepo accountDetailsRepo)
        {
            _accountDetailsRepo = accountDetailsRepo;
        }

        [HttpGet("AccountDetails")]
        public async Task<ActionResult<ServiceResponse<GetAccountDetailsDto>>> AccountDetails()
        {
            return Ok(await _accountDetailsRepo.AccountDetails());
        }
    }
}
