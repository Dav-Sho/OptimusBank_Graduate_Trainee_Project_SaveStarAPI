using SaveStarMoneyAPI.Dtos;
using SaveStarMoneyAPI.Repository;

namespace SaveStarMoneyAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly AccountRepo _accountRepo;

        public AccountController(AccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [HttpPost("Account")]
        public async Task<ActionResult<ServiceResponse<string>>> Register(AccountDto accountDto)
        {
            var newUser = new Account { FirstName = accountDto.FirstName, Email = accountDto.Email, LastName = accountDto.LastName, AccountName = accountDto.FirstName + " " + accountDto.LastName, CurrentAccountBalance = accountDto.CurrentAccountBalance };
            return Ok(await _accountRepo.Account(newUser, accountDto.password));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginDto account)
        {

            return Ok(await _accountRepo.Login(account.Email, account.password));
        }
    }
}
