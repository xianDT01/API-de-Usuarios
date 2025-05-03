using WebApiCrud.Models;
using WebApiCrud.Repositories;

namespace WebApiCrud.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Usuario>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Usuario?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Usuario usuario) => _repo.AddAsync(usuario);
        public Task UpdateAsync(Usuario usuario) => _repo.UpdateAsync(usuario);
        public Task DeleteAsync(Usuario usuario) => _repo.DeleteAsync(usuario);
    }
}
