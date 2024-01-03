namespace Encrypt_API.Configuration
{
    public static class InjectDependences
    {
        /// <summary>
        /// Adiciona todas as dependências do projeto
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddInjecaoDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            ///Injecao dependencias do sistema
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            ///Injecao dependencias personalizadas
            services.AddConfigDB(configuration);
            services.AddRepositorys();
            services.AddServices();
        }
    }
}
