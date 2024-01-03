namespace Encrypt_API.Commands
{
    public static class ActionCommand
    {
        public const string RequisicaoInvalida = nameof(InvalidRequest);
        public const string RequisicaoNaoAutorizada = nameof(UnauthorizedRequest);
        public const string RequisicaoNula = nameof(NullRequest);
    }

    public class InvalidRequest { }
    public class UnauthorizedRequest { }
    public class NullRequest { }
}
