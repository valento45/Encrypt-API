namespace Encrypt_API.Commands.Interfaces
{
    public interface ICommandRequest
    {
        Task<string> ObterComando(string acao);
    }
}
