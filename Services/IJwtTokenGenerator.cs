using HRVacancies.Models;

namespace HRVacancies.Services
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateJwtTokenString(ApplicationUser user);
        public bool IsTokenValid(string key, string issuer, string token);

    }
}
