using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api_filmes_senai.Domains;
using api_filmes_senai.DTO;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
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
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(loginDTO.Email!, loginDTO.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado, email ou senha invalidos");
                }

                // caso o usuario seja encontrado, prossegue para a criacao do token

                // 1* passo - definir as claims() que serao fornecidos no token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),

                    new Claim("Nome da Claim","Valor da Claim")
                };

                // 2* passo - definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                // 3* passo - definir as credenciais do token (header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4* passo - gerar o token
                var token = new JwtSecurityToken
                    (
                        // emissor do token
                        issuer: "api_filmes_senai",

                        // destinatário do token
                        audience: "api_filmes_senai",

                        // dados definidos nas claims
                        claims: claims,

                        // tempo de expiração do token
                        expires: DateTime.Now.AddMinutes(10),

                        // credenciais do token
                        signingCredentials: creds

                    );

                // retorna o token
                return Ok
                    (
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                        }
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
