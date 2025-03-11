using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailSenha(string email, string senha);

    }
}
