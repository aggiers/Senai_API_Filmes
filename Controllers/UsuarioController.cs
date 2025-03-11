using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>usuario buscado</returns>
        /// 
        [HttpPost]
        [Authorize]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);   
            }
        }

        /// <summary>
        /// Endpoint para buscar um usuario
        /// </summary>
        /// <param name="id"> id do usuario buscado</param>
        /// <returns>usuario buscado</returns>
        /// 
        [HttpGet("{id}")]

        public IActionResult GetByID(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }

                    return null!;
            }
            catch (Exception e)
            {
                return BadRequest(e. Message);
            }
        }

    }
}
