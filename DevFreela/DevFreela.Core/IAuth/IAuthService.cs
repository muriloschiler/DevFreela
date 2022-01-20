using DevFreela.Core.Entities;

namespace DevFreela.Core.IAuth
{
    public interface IAuthService
    {
        string GenerateJWTToken(string email,string role);
        string ComputeSha256Hash(string password);
    }
}