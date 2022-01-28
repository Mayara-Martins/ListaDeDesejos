using API_ListaDeDesejos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ListaDeDesejos.Repositories
{
    public interface IListaDeDesejosRepository
    {
        Task<IEnumerable<ListaDeDesejos>> Get();

        Task<ListaDeDesejos> Get(int id);

        Task<ListaDeDesejos> Create(ListaDeDesejos listaDeDesejos);

        Task Update(ListaDeDesejos listaDeDesejos);

        Task Delete(int Id);

        Task<bool> Exists(int idListaDeDesejo, int idProduto);
    }
}
