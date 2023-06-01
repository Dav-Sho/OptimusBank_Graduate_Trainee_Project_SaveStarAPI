using System.Net;
using System.Security.Claims;

namespace SaveStarMoneyAPI.Service
{
    public class GetFixedSavingsService : GetFixedSavingDetailsRepo
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetFixedSavingsService(IMapper mapper, DataContext context, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        public async Task<ServiceResponse<List<GetFixedSavingDetailsDto>>> GetFixedSavingsDetails()
        {
            var response = new ServiceResponse<List<GetFixedSavingDetailsDto>>();
            //var fixedSavings = await _context.FixedSavings.FirstOrDefaultAsync(x => x.Id == GetUserId());

            var fixedSavings = await _context.FixedSavings.Where(c => c.Account!.Id == GetUserId()).ToListAsync();
            if (fixedSavings is null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Success = false;
                response.Message = "fixed Savings not found";
                return response;
            }

            response.Data = fixedSavings.Select(c => _mapper.Map<GetFixedSavingDetailsDto>(c)).ToList() ;
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "fixed Savings Found in the db";
            return response;
        }
    }
}
