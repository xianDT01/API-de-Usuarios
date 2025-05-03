using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCrud.Models;
using WebApiCrud.Repositories;


public class ProductoService
    {
        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Producto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Producto?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Producto producto) => _repo.AddAsync(producto);
        public Task UpdateAsync(Producto producto) => _repo.UpdateAsync(producto);
        public Task DeleteAsync(Producto producto) => _repo.DeleteAsync(producto);
    }
