using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SaveStarMoneyAPI.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace SaveStarMoneyAPI.Service
{
    public class AccountService : AccountRepo
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AccountService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ServiceResponse<string>> Account(Account account, string password)
        {

            var response = new ServiceResponse<string>();

            if (await UserExist(account.Email))
            {
                response.Success = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "User already exist";
                return response;
            }

            createPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            account.PasswordHash = passwordHash;
            account.PasswordSalt = passwordSalt;

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            response.Data = CreateToken(account);
            response.StatusCode = HttpStatusCode.Created;
            response.Message = "Account created";
            return response;

        }

        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Accounts.FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));

            if (user is null)
            {
                response.Success = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Invalid user or password";
                return response;
            }

            else if (!verifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Invalid email or password";
                return response;
            }
            else
            {
                response.Data = CreateToken(user);
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "User Login";
                return response;
            }
        }

        public async Task<bool> UserExist(string email)
        {
            if (await _context.Accounts.AnyAsync(u => u.Email.ToLower() == email.ToLower()))
            {
                return true;
            }

            return false;
        }


        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool verifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(Account account)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.AccountName)
            };

            var appSettingToken = _configuration.GetSection("AppSetting:Token").Value;
            if (appSettingToken is null)
            {
                throw new Exception("AppSettings Token is null");
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingToken));

            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
