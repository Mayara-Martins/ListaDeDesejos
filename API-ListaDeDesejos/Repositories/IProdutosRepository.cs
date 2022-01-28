using API_ListaDeDesejos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API_ListaDeDesejos.Repositories
{
    public interface IProdutosRepository
    {
        Task<IEnumerable<Produtos>> Get();

        Task<Produtos> Get(int id);

        Task<Produtos> Create(Produtos produtos);

        Task Update(Produtos produtos);

        Task Delete(int Id);

        Task<bool> Exists(string customername);
    }
}
