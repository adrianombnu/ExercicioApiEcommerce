using ExercicioApiEcommerce.DTOs;
using ExercicioApiEcommerce.Entidades;
using ExercicioApiEcommerce.Enumeradores;
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

        [HttpPost, Route("{id}/item")]
        public IActionResult AdiocionarItemPedido(Guid id, ItemPedidoDTO itemPedidoDTO)
        {
            itemPedidoDTO.Validar();

            if (!itemPedidoDTO.Valido)
                return BadRequest("Item inválido!");

            var item = new ItemPedido(itemPedidoDTO.Quantidade,itemPedidoDTO.Produto.Id);
            var prod = new Produto(id: itemPedidoDTO.Produto.Id, nome: itemPedidoDTO.Produto.Nome, descricao: itemPedidoDTO.Produto.Descricao, preco: itemPedidoDTO.Produto.Preco);
            
            item.Produto = prod;
            
            _itensPedidoService.Cadastrar(item);
            return Created("", _pedidoService.AdicionarItemPedido(id, item));
        }

        [HttpPut, Route("{idPedido}/item/{idItem}")]
        public IActionResult AtualizarItemPedido(Guid idPedido, Guid idItem, ItemPedidoDTO itemPedidoDTO)
        {
            itemPedidoDTO.Validar();

            if (!itemPedidoDTO.Valido)
                return BadRequest("Item inválido!");

            var item = new ItemPedido(itemPedidoDTO.Quantidade, idItem);
            
            return Created("", _pedidoService.AtualizarItemPedido(idPedido, idItem, item));
        }

        [HttpPost, Route("{idPedido}/pagamento/")]
        public IActionResult FinalizarPedido(Guid idPedido, PagamentoDTO pagamentoDTO)
        {
            pagamentoDTO.Validar();

            if (!pagamentoDTO.Valido)
                return BadRequest("Pagamento inválido!");

            if(pagamentoDTO.FormaPagamento == EFormaPagamento.Boleto)
            {
                var formaPagamento = new Boleto(DateTime.Now, pagamentoDTO.PagamentoBoleto.Valor);
                return Created("", _pedidoService.FinalizarPedido(idPedido, formaPagamento));

            }else if (pagamentoDTO.FormaPagamento == EFormaPagamento.CartaoCredito)
            {
                var formaPagamento = new Boleto(DateTime.Now, pagamentoDTO.PagamentoBoleto.Valor);
                return Created("", _pedidoService.FinalizarPedido(idPedido, formaPagamento));

            }else if (pagamentoDTO.FormaPagamento == EFormaPagamento.CartaoDebito)
            {
                var formaPagamento = new Boleto(DateTime.Now, pagamentoDTO.PagamentoBoleto.Valor);
                return Created("", _pedidoService.FinalizarPedido(idPedido, formaPagamento));

            }else if (pagamentoDTO.FormaPagamento == EFormaPagamento.Pix)
            {
                var formaPagamento = new Boleto(DateTime.Now, pagamentoDTO.PagamentoBoleto.Valor);
                return Created("", _pedidoService.FinalizarPedido(idPedido, formaPagamento));
            }
            else
            {
                return BadRequest("Pagamento inválido!");
            }
            

        }

        [HttpDelete, Route("{idPedido}/item/{idItem}")]
        public IActionResult RemoverItemPedido(Guid idPedido, Guid idItem)
        {
            return Created("", _pedidoService.RemoverItemPedido(idPedido, idItem));
        }



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


    }
}
