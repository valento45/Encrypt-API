using Encrypt_API.Service;
using Encrypt_API.Service.Interfaces;

namespace Encrypt_API.Configuration
{
    public static class ServicesConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEncryptService, EncryptService>();
        }
    }
}
