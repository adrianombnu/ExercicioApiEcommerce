using ExercicioApiEcommerce.DTOs;
using ExercicioApiEcommerce.Entidades;
using ExercicioApiEcommerce.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExercicioApiEcommerce.Controllers
{
    [ApiController, Route("[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly ItemPedidoService _itemPedidoService;
        public ItemPedidoController(ItemPedidoService itemPedidoService)
        {
            _itemPedidoService = itemPedidoService;
        }

        /*
        [HttpPost]
        public IActionResult Cadastrar(ItemPedidoDTO itemPedidoDTO)
        {
            itemPedidoDTO.Validar();

            if (!itemPedidoDTO.Valido)
                return BadRequest("Item informado é inválido!");

            var gui = Guid.NewGuid();
            var item = new ItemPedido(id: itemPedidoDTO.Id, quantidade: itemPedidoDTO.Quantidade, valor: itemPedidoDTO.Valor);

            return Created("", _itemPedidoService.Cadastrar(item));
        }*/


        [HttpGet, Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_itemPedidoService.Get(id));

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_itemPedidoService.Get());

        }

        /*
        [HttpPut, Route("{id}")]
        public IActionResult Atualizar(Guid id, ItemPedidoDTO itemPedidoDTO)
        {
            itemPedidoDTO.Validar();

            if (!itemPedidoDTO.Valido)
                return BadRequest("Item informado inválido!");

            var prod = new ItemPedido(id: itemPedidoDTO.Id, quantidade: itemPedidoDTO.Quantidade, valor: itemPedidoDTO.Valor);

            return Created("Cliente alterado com sucesso!", _itemPedidoService.Atualizar(id, prod));

        }*/

        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_itemPedidoService.Delete(id))
                return BadRequest("Não foi possível deletar o item!");

            return Ok("Item deletado com sucesso.");

        }


    }
}
