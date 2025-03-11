
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

    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        /// <summary>
        /// Endpoint para listar todos os Filmes
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Filme> listaDeFilmes = _filmeRepository.Listar();
                
                return Ok(listaDeFilmes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para postar novos Filmes
        /// </summary>
        /// <param name="novoFilme"></param>
        /// <returns> filme buscado </returns>
        /// 
        [HttpPost]
        [Authorize]
        public IActionResult Post(Filme novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para buscar um Filme pelo seu Id
        /// </summary>
        /// <param name="id"> Id do Filme buscado </param>
        /// <returns> filme buscado </returns>
        [HttpGet("BuscarPorId/{id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                Filme filmeBuscado = _filmeRepository.BuscarPorID(id);

                return Ok(filmeBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar um Filme pelo seu Id
        /// </summary>
        /// <param name="id"> Id do Filme buscado </param>
        /// <returns> filme buscado </returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Endpoint para atualizar um Filme pelo seu Id
        /// </summary>
        /// <param name="id"> id do Filme buscado </param>
        /// <param name="filme"> Nome do Filme buscado </param>
        /// <returns> genero buscado </returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(Guid id, Filme filme)
        {
            try
            {
                _filmeRepository.Atualizar(id, filme);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para listar Filmes pelo Gênero
        /// </summary>
        /// <param name="idGenero"> id do Genero buscado </param>
        /// <returns></returns>
        [HttpGet("genero/{idGenero}")]
        public IActionResult ListarPorGenero(Guid idGenero)
        {
            var filmes = _filmeRepository.ListarPorGenero(idGenero);

            if (filmes == null || !filmes.Any())
                return NotFound("Nenhum filme encontrado para esse gênero.");

            return Ok(filmes);
        }

    }
}
