

namespace SaveStarMoneyAPI.Repository
{
    public interface AccountRepo
    {
        Task<ServiceResponse<string>> Account(Account account, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExist(string email);
    }
}
