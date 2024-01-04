using Dapper;
using Encrypt_API.Enums;
using Encrypt_API.Repository.Dto;
using Encrypt_API.Repository.Interfaces;
using Encrypt_API.Request;
using Encrypt_API.Response;
using Npgsql;
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


            if (encryptKeyDto?.Any() ?? false)
            {
                var obj = encryptKeyDto.FirstOrDefault();

                result.EncryptKey = obj?.chave ?? string.Empty;
            }

            return result;
        }

        public async Task<bool> InsertLogin(LoginRequest request)
        {
            string query = "insert into sys.login_tb (dh_login, licensa, ip, ip_rede, name_machine, id_usuario)" +
                " values (@dh_login, @licensa, @ip, @ip_rede, @name_machine, @id_usuario)";


            NpgsqlCommand cmd = new NpgsqlCommand(query);

            cmd.Parameters.AddWithValue(@"dh_login", request.DataHora);
            cmd.Parameters.AddWithValue(@"licensa", request.Licensa);
            cmd.Parameters.AddWithValue(@"ip", request.IP);
            cmd.Parameters.AddWithValue(@"ip_rede", request.IPRede);
            cmd.Parameters.AddWithValue(@"name_machine", request.NomeMaquina);
            cmd.Parameters.AddWithValue(@"id_usuario", request.IdUsuario);

            var result = await base.ExecuteCommand(cmd);

            return result;
        }
    }
}
