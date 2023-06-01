using AutoMapper;
using SaveStarMoneyAPI.Dtos;
using System.Net;
using System.Security.Claims;

namespace SaveStarMoneyAPI.Service
{
    public class AccountDetailsService : AccountDetailsRepo
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public AccountDetailsService(IMapper mapper, DataContext context, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        //Get Account details by login user
        public async Task<ServiceResponse<GetAccountDetailsDto>> AccountDetails()
        {
            var response = new ServiceResponse<GetAccountDetailsDto>();
            var customerAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == GetUserId());
            if (customerAccount is null) {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Success = false;
                response.Message = "Account not found";
                return response;
            }

            response.Data = _mapper.Map<GetAccountDetailsDto>(customerAccount);
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "Account Found in the db";
            return response;
        }
    }
}
