using ExercicioApiEcommerce.DTOs;
using ExercicioApiEcommerce.Entidades;
using ExercicioApiEcommerce.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExercicioApiEcommerce.Controllers
{
    [ApiController, Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;    
        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public IActionResult Cadastrar(ProdutoDTO produtoDTO)
        {
            produtoDTO.Validar();

            if (!produtoDTO.Valido)
                return BadRequest("Produto informado inválido!");

            var gui = Guid.NewGuid();
            var prod = new Produto(id: gui, nome: produtoDTO.Nome,descricao:produtoDTO.Descricao, preco: produtoDTO.Preco);

            return Created("",_produtoService.Cadastrar(prod));
        }


        [HttpGet, Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_produtoService.Get(id));

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_produtoService.Get());

        }
 
        [HttpPut, Route("{id}")]
        public IActionResult Atualizar(Guid id, Produto produto)
        {
            try
            {
                _produtoService.Atualizar(id, produto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            return Created("Produto alterado com sucesso!", produto);

        }

        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoService.Delete(id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            return Ok("Produto deletado com sucesso.");

        }


    }
}
