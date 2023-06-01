namespace SaveStarMoneyAPI.Repository
{
    public interface GetPercentageDetailsRepo
    {
        Task<ServiceResponse<GetPercentageSavingsDetailsDto>> GetFixedSavingsDetails();
    }
}
