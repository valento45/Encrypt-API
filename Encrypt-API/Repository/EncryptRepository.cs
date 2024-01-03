using Encrypt_API.Enums;
using Encrypt_API.Repository.Dto;
using Encrypt_API.Repository.Interfaces;
using Encrypt_API.Response;
using System.Data;

namespace Encrypt_API.Repository
{
    public class EncryptRepository : RepositoryBase, IEncryptRepository
    {
        public EncryptRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<KeyEncryptResponse> GetEncryptKey(Sistema keySistema)
        {
            var result = new KeyEncryptResponse();
            string query = "select * from sys.chave_criptografia_tb where sistema = " + (int)keySistema;

            var encryptKeyDto = await base.QueryAsync<EncryptKeyDto>(query);


            if(encryptKeyDto?.Any() ?? false)
            {
                var obj = encryptKeyDto.FirstOrDefault();

                result.EncryptKey = obj?.chave ?? string.Empty;
            }

            return result;
        }
    }
}
