using Encrypt_API.Request;
using Encrypt_API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Encrypt_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptController : Controller
    {
        private readonly IEncryptService encryptService;

        public EncryptController(IEncryptService encryptService)
        {
            this.encryptService = encryptService;
        }


        [HttpPost]
        [Route("GetKeyCriptografy")]
        public async Task<JsonResult> GetKeyCriptografy(EncryptRequest request)
        {
            var encryptKey = await this.encryptService.ObterChaveEncrypt(request);


            return Json(encryptKey);
        }



        [HttpPost]
        [Route("LoginAffected")]
        public async Task<JsonResult> RegistrarLogin(LoginRequest request)
        {
            var response = await this.encryptService.RegisterLogin(request);

            return Json(response);
        }
    }
}
