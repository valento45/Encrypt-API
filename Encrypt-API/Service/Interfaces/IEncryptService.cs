using Encrypt_API.Request;
using Encrypt_API.Response;

namespace Encrypt_API.Service.Interfaces
{
    public interface IEncryptService
    {

        Task<KeyEncryptResponse> ObterChaveEncrypt(EncryptRequest request);
        Task<RegisterLoginResponse> RegisterLogin(LoginRequest request);
    }
}
