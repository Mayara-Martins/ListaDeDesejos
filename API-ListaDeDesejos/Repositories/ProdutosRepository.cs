using API_ListaDeDesejos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ListaDeDesejos.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        public readonly ProdutosContext _context;

        public ProdutosRepository(ProdutosContext context)
        {
            _context = context;
        }

        public async Task<Produtos> Create(Produtos produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<bool> Exists(string customername)
        {
            return _context.Produtos.Any(c => c.Descricao == customername);
        }

        public async Task Delete(int id)
        {
            var ProdutosToDelete = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(ProdutosToDelete);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Produtos>> Get()
        {
            return await Task.Run(() => _context.Produtos.ToArray());
        }

        public async Task<Produtos> Get(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            return produto;
        }

        public async Task Update(Produtos produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
