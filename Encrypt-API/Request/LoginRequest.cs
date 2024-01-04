namespace Encrypt_API.Request
{
    public class LoginRequest
    {
        public long IdLogin { get; set; }
        public DateTime DataHora { get; set; }
        public string Licensa { get; set; }
        public string IP { get; set; }
        public string IPRede { get; set; }
        public string NomeMaquina { get; set; }
        public long IdUsuario { get; set; }

    }
}
