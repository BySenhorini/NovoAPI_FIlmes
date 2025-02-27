using API_Filmes_SENAI.Context;
using api_filmes_senai1.Domains;
using api_filmes_senai1.interfaces;
using Microsoft.EntityFrameworkCore;
namespace api_filmes_senai1.Repositories
{
    public class FilmeRepository : IFilmeRepository

    {
        private readonly Filmes_Context _context;

        public FilmeRepository(Filmes_Context context)
        {
            _context = context;
        }


        public void Atualizar(Guid id, Filme filme)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                if (filmeBuscado != null)
                {
                    filmeBuscado.IdGenero = filme.IdGenero;
                    filmeBuscado.Titulo = filme.Titulo;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                return filmeBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Filme novoFilme)
        {
            try
            {
                _context.Filme.Add(novoFilme);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscado = (_context.Filme.Find(id))!;

                if (filmeBuscado != null)
                {
                    _context.Filme.Remove(filmeBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filme.ToList();

                return listaDeFilmes;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Filme> ListarPorGenero(Guid idGenero)
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filme

                    .Include(g => g.Genero)
                    .Where(f => f.IdGenero == idGenero)
                    .ToList();

                return listaDeFilmes;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
    }
}
