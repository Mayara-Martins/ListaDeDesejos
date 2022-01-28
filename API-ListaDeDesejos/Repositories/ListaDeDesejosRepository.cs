using API_ListaDeDesejos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ListaDeDesejos.Repositories
{
    public class ListaDeDesejosRepository : IListaDeDesejosRepository
    {
        public readonly ProdutosContext _context;

        public ListaDeDesejosRepository(ProdutosContext context)
        {
            _context = context;
        }

        public async Task<ListaDeDesejos> Create(ListaDeDesejos listaDeDesejos)
        {
            _context.ListaDeDesejos.Add(listaDeDesejos);
            await _context.SaveChangesAsync();

            return listaDeDesejos;
        }
          /// public async Task<bool> Exists(int customername)
       /// {
          ///return _context.ListaDeDesejos.Any(c => c.Nome == customername);
       /// }

        public async Task Delete(int id)
        {
            var ListaDeDesejosToDelete = await _context.ListaDeDesejos.FindAsync(id);
            _context.ListaDeDesejos.Remove(ListaDeDesejosToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int idListaDeDesejo, int idProduto)
        {
            return _context.ListaDeDesejos.Any(c => c.Id == idListaDeDesejo && c.Produtos_Id == idProduto);
            
        }

        public async Task<IEnumerable<ListaDeDesejos>> Get()
        {
            return await Task.Run(() => _context.ListaDeDesejos.ToArray());
        }

        public async Task<ListaDeDesejos> Get(int id)
        {
            var listaDeDesejos = await _context.ListaDeDesejos.FindAsync(id);
            return listaDeDesejos;
        }

        public async Task Update(ListaDeDesejos listaDeDesejos)
        {
            _context.ListaDeDesejos.Update(listaDeDesejos);
            await _context.SaveChangesAsync();
        }
    }
}

