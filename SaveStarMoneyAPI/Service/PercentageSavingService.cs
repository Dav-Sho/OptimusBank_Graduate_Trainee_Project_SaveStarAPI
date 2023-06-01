using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaveStarMoneyAPI.Dtos;
using System.Net;
using System.Security.Claims;

namespace SaveStarMoneyAPI.Service
{
    public class PercentageSavingService : PercentageSavingRepo
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public PercentageSavingService(IMapper mapper, DataContext context, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _mapper = mapper;
        }


        private int GetUserId() => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        public async Task<ServiceResponse<GetPercentSavingDto>> PercentageSaving(PercentSavingDto percentageSavingDto)
        {
            var response = new ServiceResponse<GetPercentSavingDto>();
            var customerAccount = _context.Accounts.FirstOrDefault(x => x.Id == GetUserId());
            var percentAmount = _context.PercentageSavings.FirstOrDefault(x => x.Account!.Id == GetUserId());
            var percentageSaving = _mapper.Map<PercentageSaving>(percentageSavingDto);
            percentageSaving.Account = await _context.Accounts.FirstOrDefaultAsync(u => u.Id == GetUserId());

            percentageSaving.Name = "Percentage Saving";

            //Frequency Logic
            if (percentageSavingDto.Frequency.Equals(FrequencyType.Daily))
            {
                percentageSaving.Frequency = FrequencyType.Daily;
            }
            else if (percentageSavingDto.Frequency.Equals(FrequencyType.Weekly))
            {
                percentageSaving.Frequency = FrequencyType.Weekly;
            }
            else if (percentageSavingDto.Frequency.Equals(FrequencyType.Monthly))
            {
                percentageSaving.Frequency = FrequencyType.Monthly;
            }

            //Duration Logic
            if (percentageSavingDto.Duration.Equals(Duration.ThreeMonth))
            {
                percentageSaving.Duration = Duration.ThreeMonth;
                percentageSaving.EndDate = DateTime.Now.AddMonths(3); 

            }
            else if (percentageSavingDto.Frequency.Equals(Duration.SixMonth))
            {
                percentageSaving.Duration = Duration.SixMonth;
                percentageSaving.EndDate = DateTime.Now.AddMonths(6);
            }
            else if (percentageSavingDto.Frequency.Equals(Duration.A_Year))
            {
                percentageSaving.Duration = Duration.A_Year;
                percentageSaving.EndDate = DateTime.Now.AddYears(1);
            }

            _context.PercentageSavings.Add(percentageSaving);
            var ch = percentageSaving.Percentage;
            var dff = (percentageSaving.Percentage / 100);

            if (await _context.SaveChangesAsync() > 0)
            {

                percentAmount!.PercentageAmount = dff * customerAccount!.CurrentAccountBalance;

                customerAccount!.CurrentAccountBalance = customerAccount!.CurrentAccountBalance - percentAmount.PercentageAmount;

                percentAmount.Account = customerAccount;

                //_context.Update(customerAccount);

                _context.Update(percentAmount);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetPercentSavingDto>(percentageSaving);
                response.Data.PercentageAmount = percentAmount!.PercentageAmount;
                response.Success = true;
                response.StatusCode = HttpStatusCode.Created;
                response.Message = "Percentage Saving Created";

            }
            return response;
        }
    }
}
