using ExercicioApiEcommerce.DTOs;
using ExercicioApiEcommerce.Entidades;
using ExercicioApiEcommerce.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ExercicioApiEcommerce.Controllers
{
    [ApiController, Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;
        private readonly ItemPedidoService _itensPedidoService;

        public PedidoController(PedidoService pedidoService, ItemPedidoService itemPedidoService)
        {
            _pedidoService = pedidoService;
            _itensPedidoService = itemPedidoService;
        }

        /*
        [HttpPost]
        public IActionResult Cadastrar(PedidoDTO pedidoDTO)
        {
            pedidoDTO.Validar();

            if (!pedidoDTO.Valido)
                return BadRequest("Pedido inválido!");

            var gui = Guid.NewGuid();
            
            var ped = new Pedido(dataPedido: pedidoDTO.DataPedido, tipoPagamento: pedidoDTO.TipoPagamento, cliente: pedidoDTO.Clientes);
            
            return Created("", _pedidoService.Cadastrar(ped));
        }*/

        [HttpPost, Route("{id}/item")]
        public IActionResult AdiocionarItemPedido(Guid id, ItemPedidoDTO itemPedidoDTO)
        {
            itemPedidoDTO.Validar();

            if (!itemPedidoDTO.Valido)
                return BadRequest("Item inválido!");

            var item = new ItemPedido(itemPedidoDTO.Quantidade);
            var prod = new Produto(nome: itemPedidoDTO.Produto.Nome, descricao: itemPedidoDTO.Produto.Descricao, preco: itemPedidoDTO.Produto.Preco);
            
            item.Produto = prod;
            _itensPedidoService.Cadastrar(item);
            return Created("", _pedidoService.AdicionarItemPedido(id, item));
        }

        /*
        [HttpPut, Route("{idPedido}/item/{idItem}")]
        public IActionResult AtualizarItemPedido(Guid idPedido, Guid idItem, ItemPedidoDTO itemPedidoDTO)
        {
            itemPedidoDTO.Validar();

            if (!itemPedidoDTO.Valido)
                return BadRequest("Item inválido!");

            var item = new ItemPedido(itemPedidoDTO.Quantidade, itemPedidoDTO.Valor);
            
            return Created("", _pedidoService.AtualizarItemPedido(id, idItem, item));
        }

        */

        [HttpGet, Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_pedidoService.Get(id));

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_pedidoService.Get());

        }

        /*
        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_pedidoService.Delete(id))
                return BadRequest("Não foi possível deletar o produto!");

            return Ok("Cliente deletado com sucesso.");

        }
        */

    }
}
