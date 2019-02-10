using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIProdutos.Business;
using APIProdutos.Models;

namespace APIProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private ProdutoService _service;

        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _service.ListarTodos();
        }

        [HttpGet("{codigoBarras}")]
        public ActionResult<Produto> Get(string codigoBarras)
        {
            var produto = _service.Obter(codigoBarras);
            if (produto != null)
                return produto;
            else
                return NotFound();
        }

        [HttpPost]
        public Resultado Post(Produto produto)
        {
            return _service.Incluir(produto);
        }

        [HttpPut]
        public Resultado Put(Produto produto)
        {
            return _service.Atualizar(produto);
        }

        [HttpDelete("{codigoBarras}")]
        public Resultado Delete(string codigoBarras)
        {
            return _service.Excluir(codigoBarras);
        }
    }
}