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
    public class ProdutosController : ControllerBase
    { 
        private readonly IProdutosRepository _produtosRepository;
        public ProdutosController(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
   
        }

        [HttpGet]
        public async Task<IEnumerable<Produtos>> GetProduto()
        {
        return await _produtosRepository.Get();

        }


        [HttpGet("{id}")]
        public async Task<Produtos> GetProduto(int id)
        {
        return await _produtosRepository.Get(id);
        }

        [HttpPut("{id}")]
        public async Task Update(Produtos produto)
        {
        await _produtosRepository.Update(produto);


        }


        [HttpPost]
        public async Task<IActionResult> Create(Produtos produto)
        {
            if (await _produtosRepository.Exists(produto.Descricao))
            {
                return Conflict("Produto já existe com o nome " + produto.Descricao);
            }
            await _produtosRepository.Create(produto);
            return Ok();
        }

      
            [HttpDelete("{id}")]
        public async Task DeleteTodoItem(int id)
        {
        await _produtosRepository.Delete(id);
        }
    }
}