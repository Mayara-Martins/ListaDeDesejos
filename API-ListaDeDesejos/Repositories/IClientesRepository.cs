using API_ListaDeDesejos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ListaDeDesejos.Repositories
{
    public interface IClientesRepository
    {
        Task<IEnumerable<Clientes>> Get();

        Task<Clientes> Get(int id);

        Task<Clientes> Create(Clientes clientes);

        Task Update(Clientes clientes);

        Task Delete(int Id);

        Task<bool> Exists(string customername);
    }
}
