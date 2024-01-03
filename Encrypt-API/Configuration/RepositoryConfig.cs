using Encrypt_API.Repository;
using Encrypt_API.Repository.Interfaces;

namespace Encrypt_API.Configuration
{
    public static class RepositoryConfig
    {

        public static void AddRepositorys(this IServiceCollection services)
        {
            services.AddTransient<IEncryptRepository, EncryptRepository>();
        }

    }
}
