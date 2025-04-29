using api_filmes_senai1.Domains;
using api_filmes_senai1.interfaces;
using api_filmes_senai1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;

        }

        [HttpGet]
        public IActionResult Get()
        {
         
                try
                {
                    List<Filme> listaDeFilmes = _filmeRepository.Listar();

                    return Ok(listaDeFilmes);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            
        }

        [HttpPost]
        public IActionResult Post(Filme novofilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novofilme);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult getById(Guid id)
        {
            try
            {
                Filme filmeBuscado = _filmeRepository.BuscarPorId(id);

                return Ok(filmeBuscado);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult delete(Guid id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
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
        //criar endpoint e testar para filtro  de filmes
        [HttpGet("ListarPorGenero/{id}")]
        public IActionResult GetByGenero(Guid id)
        {
            try
            {
                List<Filme> ListaDeFilmePorGenero = _filmeRepository.ListarPorGenero(id);

                return Ok(ListaDeFilmePorGenero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
