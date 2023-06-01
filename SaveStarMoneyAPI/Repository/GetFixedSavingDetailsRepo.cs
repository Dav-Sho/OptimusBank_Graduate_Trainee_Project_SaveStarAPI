namespace SaveStarMoneyAPI.Repository
{
    public interface GetFixedSavingDetailsRepo
    {
        Task<ServiceResponse<List<GetFixedSavingDetailsDto>>> GetFixedSavingsDetails();
    }
}
