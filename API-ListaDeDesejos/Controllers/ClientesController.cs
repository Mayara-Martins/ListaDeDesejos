using API_ListaDeDesejos.Model;
using API_ListaDeDesejos.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ListaDeDesejos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository _clientesRepository;
        public ClientesController(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Clientes>> GetCliente()
        {
            return await _clientesRepository.Get();
               
        }

        
        [HttpGet("{id}")]
        public async Task<Clientes> GetCliente(int id)
        {
            return await _clientesRepository.Get(id);
        }
      
        [HttpPut("{id}")]
        public async Task Update(Clientes cliente)
        {
            await _clientesRepository.Update(cliente);


        }
        
        
        [HttpPost]
        public async Task<IActionResult> Create(Clientes cliente)
        {
            if(await _clientesRepository.Exists(cliente.Nome))
            {
                return Conflict("Cliente já existe com o nome " + cliente.Nome);
            }
            await _clientesRepository.Create(cliente);
            return Ok();
        }

       
        [HttpDelete("{id}")]
        public async Task DeleteTodoItem(int id)
        {
            await _clientesRepository.Delete(id);
        }
    }
}
