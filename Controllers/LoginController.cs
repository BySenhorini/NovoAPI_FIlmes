using api_filmes_senai1.Domains;
using api_filmes_senai1.DTO;
using api_filmes_senai1.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace api_filmes_senai1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;


        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDTO.Email!, loginDTO.Senha!);
                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado, email ou senha inválidos!");

                }
                var claims = new[]
                {
                    new Claim
                    (JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    new Claim
                    (JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),

                    new Claim
                    (JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),

                    //definir uma claim personalizada
                    new Claim("Nome da Claim", "Valor da Claim")

                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Issuer é o emissor do token, Audience é o destinatário, Claims são os dados definidos do token e SigningCredentials são as credenciais.
                var token = new JwtSecurityToken(issuer: "api_filmes_senai1",
                    audience: "api_filmes_senai1",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5), signingCredentials: creds);
                return Ok(
                    new
                    {

                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
