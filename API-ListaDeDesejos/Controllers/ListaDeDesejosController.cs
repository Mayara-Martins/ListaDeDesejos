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
    public class ListaDeDesejosController : ControllerBase
    {
        private readonly IListaDeDesejosRepository _listaDeDesejosRepository;
        public ListaDeDesejosController(IListaDeDesejosRepository listaDeDesejosRepository)
        {
            _listaDeDesejosRepository = listaDeDesejosRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ListaDeDesejos>> GetListaDeDesejo()
        {
            return await _listaDeDesejosRepository.Get();

        }


        [HttpGet("{id}")]
        public async Task<ListaDeDesejos> GetListaDeDesejo(int id)
        {
            return await _listaDeDesejosRepository.Get(id);
        }

        [HttpPut("{id}")]
        public async Task Update(ListaDeDesejos listaDeDesejo)
        {
            await _listaDeDesejosRepository.Update(listaDeDesejo);


        }


        [HttpPost]
        public async Task<IActionResult> Create(ListaDeDesejos listaDeDesejo)
        {
            if (await _listaDeDesejosRepository.Exists(listaDeDesejo.Id, listaDeDesejo.Produtos_Id))
            {
               return Conflict("Lista de desejo já possui o prouto" );
            }
            await _listaDeDesejosRepository.Create(listaDeDesejo);
              return Ok();
        }

      

        [HttpDelete("{id}")]
        public async Task DeleteTodoItem(int id)
        {
            await _listaDeDesejosRepository.Delete(id);
        }
    }
}