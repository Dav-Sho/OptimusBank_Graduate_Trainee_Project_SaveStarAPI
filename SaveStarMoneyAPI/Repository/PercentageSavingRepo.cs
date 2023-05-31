namespace SaveStarMoneyAPI.Repository
{
    public interface PercentageSavingRepo
    {
        Task<ServiceResponse<GetPercentSavingDto>> PercentageSaving(PercentSavingDto percentageSavingDto);
    }
}
