using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCrud.Models;

namespace WebApiCrud.Repositories
{
public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Usuario usuario);
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario?> GetByEmailAndPasswordAsync(string email, string password);

    }
}