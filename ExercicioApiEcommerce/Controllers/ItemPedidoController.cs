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

        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_itemPedidoService.Delete(id))
                return BadRequest("Não foi possível deletar o item!");

            return Ok("Item deletado com sucesso.");

        }


    }
}
