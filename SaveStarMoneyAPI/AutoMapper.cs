

namespace SaveStarMoneyAPI
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<FixedSavingDto,FixedSavingsEntity>();
            CreateMap<FixedSavingsEntity, GetFixedSavingDto>();
            CreateMap<PercentSavingDto, PercentageSaving>();
            CreateMap<PercentageSaving, GetPercentSavingDto>();
            CreateMap<Account, GetAccountDetailsDto>();
            CreateMap<FixedSavingsEntity, GetFixedSavingDetailsDto>();
            CreateMap<PercentageSaving, GetPercentageSavingsDetailsDto>();
        }
    }
}
