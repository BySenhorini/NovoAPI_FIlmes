using api_filmes_senai1.Domains;

namespace api_filmes_senai1.interfaces
{
    /// <summary>
    /// Interface para Genero : Contrato
    /// Toda classe que herdar(implementar) essa interface, devera implementar todos os metodos definidos aqui dentro
    /// </summary>
    public interface IGeneroRepositoy
    {
        //CRUD : Metodos
        //C : Create : Cadastrar um novo Objeto
        //R : Read : Listar todos os objetos
        //U : Update : Alterar um objeto
        //D : Delete : Deleto ou excluo um objeo

        //Metodo = TipoDeRetorno NomeDoMetodo(Argumentos)

        void Cadastrar(Genero novoGenero);

        List<Genero> Listar();

        void Atualizar (Guid id, Genero Genero);

        void Deletar(Guid id);

        Genero BuscarPorID(Guid id);



    }
}
