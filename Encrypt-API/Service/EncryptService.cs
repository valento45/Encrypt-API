using Encrypt_API.Commands;
using Encrypt_API.Enums;
using Encrypt_API.Repository.Interfaces;
using Encrypt_API.Request;
using Encrypt_API.Response;
using Encrypt_API.Service.Interfaces;

namespace Encrypt_API.Service
{
    public class EncryptService : IEncryptService
    {
        private readonly IEncryptRepository encryptRepository;

        public EncryptService(IEncryptRepository encryptRepository)
        {
            this.encryptRepository = encryptRepository;
        }

        /// <summary>
        /// Retorna a chave de criptografia
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<KeyEncryptResponse> ObterChaveEncrypt(EncryptRequest request)
        {
            KeyEncryptResponse keyEncrypt = new KeyEncryptResponse();

            if (ValidarRequest(request, keyEncrypt))
                return await this.encryptRepository.GetEncryptKey((Sistema)request.TipoSistema);
            else
                return keyEncrypt;
        }

        /// <summary>
        /// Valida a requisição
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        private bool ValidarRequest(EncryptRequest request, KeyEncryptResponse response)
        {

            if (request == null)
                InsertCommand(response, ActionCommand.RequisicaoNula);


            if (request?.TipoSistema <= 0)
                InsertCommand(response, ActionCommand.RequisicaoInvalida);


            //if (request?.IdLogin <= 0)
            //    InsertCommand(response, ActionCommand.RequisicaoNaoAutorizada);


            return string.IsNullOrEmpty(response?.Command);

        }

        /// <summary>
        /// Inserir comandos que o sistema deve fazer
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        private void InsertCommand(KeyEncryptResponse obj, string command)
        {
            if (!string.IsNullOrEmpty(obj.Command))
                obj.Command += $"; {command}";
            else
                obj.Command = command;


            obj.PossuiComandos = true;
        }

        public async Task<RegisterLoginResponse> RegisterLogin(LoginRequest request)
        {
            return await encryptRepository.InsertLogin(request);
        }
    }
}
