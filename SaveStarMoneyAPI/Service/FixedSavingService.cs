using System.Net;
using System.Security.Claims;

namespace SaveStarMoneyAPI.Service
{
    public class FixedSavingService : FixedSavingRepo
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public FixedSavingService(IMapper mapper, DataContext context, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        public async Task<ServiceResponse<GetFixedSavingDto>> FixedSaving(FixedSavingDto fixedSavingDto)
        {
            var response = new ServiceResponse<GetFixedSavingDto>();
            var customerAccount = _context.Accounts.FirstOrDefault(x => x.Id == GetUserId());
            var fixedSaving = _mapper.Map<FixedSavingsEntity>(fixedSavingDto);
            fixedSaving.Account = await _context.Accounts.FirstOrDefaultAsync(u => u.Id == GetUserId());

            //fixedSaving.Account.CurrentAccountBalance = 300.0;

            fixedSaving.Name = "Fixed Saving";

            //Frequency Logic
            if (fixedSavingDto.Frequency.Equals(FrequencyType.Daily))
            {
                fixedSaving.Frequency = FrequencyType.Daily;
            }
            else if (fixedSavingDto.Frequency.Equals(FrequencyType.Weekly))
            {
                fixedSaving.Frequency = FrequencyType.Weekly;
            }
            else if (fixedSavingDto.Frequency.Equals(FrequencyType.Monthly))
            {
                fixedSaving.Frequency = FrequencyType.Monthly;
            }

            //Duration Logic
            if (fixedSavingDto.Duration.Equals(Duration.ThreeMonth))
            {
                fixedSaving.Duration = Duration.ThreeMonth;
                fixedSaving.EndDate = DateTime.Now.AddMonths(3);
                
            }
            else if (fixedSavingDto.Frequency.Equals(Duration.SixMonth))
            {
                fixedSaving.Duration = Duration.SixMonth;
                fixedSaving.EndDate = DateTime.Now.AddMonths(6);
            }
            else if (fixedSavingDto.Frequency.Equals(Duration.A_Year))
            {
                fixedSaving.Duration = Duration.A_Year;
                fixedSaving.EndDate = DateTime.Now.AddYears(1).Date;
            }

            _context.FixedSavings.Add(fixedSaving);
            if (await _context.SaveChangesAsync() > 0)
            {
                customerAccount!.CurrentAccountBalance -= fixedSavingDto.FixedAmount;


                _context.Update(customerAccount);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetFixedSavingDto>(fixedSaving);
                response.Success = true;
                response.StatusCode = HttpStatusCode.Created;
                response.Message = "Fixed Saving Created";
                
            }
            return response;

        }
    }
}
