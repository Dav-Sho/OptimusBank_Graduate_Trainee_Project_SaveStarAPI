namespace SaveStarMoneyAPI.Repository
{
    public interface GetFixedSavingDetailsRepo
    {
        Task<ServiceResponse<GetFixedSavingDetailsDto>> GetFixedSavingsDetails();
    }
}
