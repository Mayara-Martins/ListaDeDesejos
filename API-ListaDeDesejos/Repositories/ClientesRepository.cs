using API_ListaDeDesejos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ListaDeDesejos.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        public readonly ProdutosContext _context;

        public ClientesRepository(ProdutosContext context)
        {
            _context = context;
        }

        public async Task<Clientes> Create(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<bool> Exists(string customername)
        {
            return _context.Clientes.Any(c => c.Nome == customername);
        }


        public async Task Delete(int id)
        {
            var ClientesToDelete = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(ClientesToDelete);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Clientes>> Get()
        {
            return await Task.Run(() => _context.Clientes.ToArray());
        }

        public async Task<Clientes> Get(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            return cliente;
        }

        public async Task Update(Clientes cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

    }   
}
