namespace SaveStarMoneyAPI.Repository
{
    public interface AccountDetailsRepo
    {
        Task<ServiceResponse<GetAccountDetailsDto>> AccountDetails();
    }
}
