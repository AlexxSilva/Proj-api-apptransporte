using API_AppTransporte.Dto;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace API_AppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IWMS_USER_Service usuarioService;
        private readonly IMapper mapper;


        [HttpPost]
        [Route("postLogin")]
        [AllowAnonymous]
       
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] WMS_USERDto usuarioDto)
        {
            var user = mapper.Map<WMS_USER>(usuarioDto);

            WMS_USER userLogin = await usuarioService.GetUsuario(user);
            if (userLogin == null)
                return NotFound(new { message = "Usuário ou senha Inválidos" });
            
            //if (user == null)
            //    return NotFound(new { message = "Usuário ou senha Inválidos" });
            //if (user.DESCRICAO_USER == "" || user.DESCRICAO_USER.ToLower() == "string")
            //    return NotFound(new { message = "Usuário ou senha Inválidos" });
            
            
            var token = TokenService.GenerateToken(user);
            //user.SetPasswordVazio();
            return new
            {
                user = user,
                token = token
            };
        }

        public UsuarioController(IWMS_USER_Service usuarioService, IMapper mapper)
        {
            this.usuarioService = usuarioService;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("getUsuarios")]
        [Authorize]
        public async Task<IActionResult> GetUsuarios()
        {
            return Ok(await usuarioService.GetUsuarios());
        }
    }
}
