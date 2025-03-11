using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces
{

    // interface para Genero : Contrato
    // toda classe que herdar essa interface, deverá implementar todos os métodos aqui dentro
    public interface IGeneroRepository
    {  // CRUD : Métodos
       // C : Create : Cadastrar um novo Objeto
       // R : Read : Listar todos os objetos 
       // U : Update : Alterar um objeto
       // D : Delete : Deleto ou excluo um objeto

        // Método = TipoDeRetorno NomeDoMetodo(Argumentos)

        void Cadastrar(Genero novoGenero);

        List<Genero> Listar();

        void Atualizar(Guid id, Genero genero);

        void Deletar(Guid id);

        Genero BuscarPorId(Guid id);

    }
}
