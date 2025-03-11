using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
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
