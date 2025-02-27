using API_Filmes_SENAI.Context;
using api_filmes_senai1.Domains;
using api_filmes_senai1.interfaces;

namespace api_filmes_senai1.Repositories
{
    /// <summary>
    /// Classe que vai implementar a interface IGeneroRepository ou seja vamos implementar os metodos, toda a logica do metodos
    /// </summary>


    public class GeneroRepository : IGeneroRepositoy
    {

        /// <summary>
        /// Variavel privada e somente leitura que "guarda" os dados do contexto
        /// </summary>

        private readonly Filmes_Context _context;

        /// <summary>
        /// Construtor do repositorio
        /// Aqui, toda vez que o construtor for chamado,
        /// os dados estarao disponiveis
        /// </summary>
        /// <param name="contexto"></param>
        public GeneroRepository(Filmes_Context contexto)
        {
            _context = contexto;

        }       






        public void Atualizar(Guid id, Genero Genero)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;

                if (generoBuscado != null)
                {
                    generoBuscado.Nome = Genero.Nome;
                }

                _context.SaveChanges();
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public Genero BuscarPorID(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;

                return generoBuscado;
            }
            catch (Exception)
                {
                    throw;
                }
        }

        /// <summary>
        /// Metodo para cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto genero a ser cadastro
        /// </param>

        public void Cadastrar(Genero novoGenero)
        {
            try
            {
                //Adiciona um novo genero na tabela Generos(BD)
                _context.Genero.Add(novoGenero);

                //Apos o cadastro, salva as alteracoes(BD)
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
                Genero generoBuscado = _context.Genero.Find(id)!;

                if (generoBuscado != null)
                {
                    _context.SaveChanges();
                }

                _context.SaveChanges();
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<Genero> Listar()
        {
            try
            {
                List<Genero> listaGeneros = _context.Genero.ToList();

                return listaGeneros;
            }
            catch (Exception)
            {
                throw;
            }
        }


        
    }
}
