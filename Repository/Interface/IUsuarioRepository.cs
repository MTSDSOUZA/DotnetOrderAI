using DotnetOrderAI.Models;

namespace DotnetOrderAI.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int userId);
        Task<Usuario> AddUsuario(Usuario user);
        Task<Usuario> UpdateUsuario(Usuario user);
        void DeleteUsuario(int userId);
    }
}
