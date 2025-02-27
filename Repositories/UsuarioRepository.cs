using API_Filmes_SENAI.Context;
using api_filmes_senai1.Domains;
using api_filmes_senai1.interfaces;
using api_filmes_senai1.Utils;

namespace api_filmes_senai1.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Filmes_Context _context;


        public UsuarioRepository(Filmes_Context context)
        {
            _context = context;
        }


        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.Find(id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);

                _context.Usuario.Add(novoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
