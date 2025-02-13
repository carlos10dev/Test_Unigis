
using Microsoft.EntityFrameworkCore;
using Test_Unigis.Models;

namespace Test_Unigis.Repository
{
    public class ProductoRepository : IRepository<Producto>
    {
        private StoreContext _context;
        public ProductoRepository(StoreContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Producto>> Get() =>
            await _context.Productos.ToListAsync();

        public async Task<Producto> GetById(int id) =>
            await _context.Productos.FindAsync(id);

        public async Task Add(Producto producto) =>
            await _context.Productos.AddAsync(producto);

        public void Update(Producto producto)
        {
            _context.Productos.Attach(producto);
            _context.Productos.Entry(producto).State = EntityState.Modified;
        }

        public void Delete(Producto producto) =>
            _context.Productos.Remove(producto);

        public async Task Save() =>
            await _context.SaveChangesAsync();
        
        
    }
}