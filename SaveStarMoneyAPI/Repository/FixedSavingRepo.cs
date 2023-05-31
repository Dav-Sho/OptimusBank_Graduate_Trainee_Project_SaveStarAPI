namespace SaveStarMoneyAPI.Repository
{
    public interface FixedSavingRepo
    {
        Task<ServiceResponse<GetFixedSavingDto>> FixedSaving(FixedSavingDto fixedSavingDto);
    }
}
