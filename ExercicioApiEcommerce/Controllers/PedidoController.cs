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
        public IActionResult AdicionarItemPedido(Guid id, ItemPedidoDTO itemPedidoDTO)
        {
            itemPedidoDTO.Validar();

            if (!itemPedidoDTO.Valido)
                return BadRequest("Item inválido!");

            try
            {
                var item = new ItemPedido(itemPedidoDTO.Quantidade, itemPedidoDTO.Produto.Id);
                var prod = new Produto(id: itemPedidoDTO.Produto.Id, nome: itemPedidoDTO.Produto.Nome, descricao: itemPedidoDTO.Produto.Descricao, preco: itemPedidoDTO.Produto.Preco);

                item.Produto = prod;

                _itensPedidoService.Cadastrar(item);
                return Created("", _pedidoService.AdicionarItemPedido(id, item));

            }catch (Exception ex)
            {
                return BadRequest("Erro ao adicionar item no pedido: " + ex.Message);
            }

        }

        [HttpPut, Route("{idPedido}/item/{idItem}")]
        public IActionResult AtualizarItemPedido(Guid idPedido, Guid idItem, ItemPedidoDTO itemPedidoDTO)
        {
            itemPedidoDTO.Validar();

            if (!itemPedidoDTO.Valido)
                return BadRequest("Item inválido!");

            try
            {
                var item = new ItemPedido(itemPedidoDTO.Quantidade, idItem);

                return Created("", _pedidoService.AtualizarItemPedido(idPedido, idItem, item));

            }catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar item: " + ex.Message);
            }

        }

        [HttpPost, Route("{idPedido}/pagamento/")]
        public IActionResult FinalizarPedido(Guid idPedido, PagamentoDTO pagamentoDTO)
        {
            pagamentoDTO.Validar();

            if (!pagamentoDTO.Valido)
                return BadRequest("Pagamento inválido!");

            switch (pagamentoDTO.FormaPagamento)
            {
                case EFormaPagamento.Boleto:
                    {
                        var formaPagamento = new Boleto(DateTime.Now, pagamentoDTO.PagamentoBoleto.Valor);
                        
                        return Created("", _pedidoService.FinalizarPedido(idPedido, formaPagamento));

                    }

                case EFormaPagamento.CartaoCredito:
                    {
                        var formaPagamento = new CartaoDebito(pagamentoDTO.PagamentoCartaoCredito.NomeDoCartao,
                                                              pagamentoDTO.PagamentoCartaoCredito.NumeroCartao,
                                                              pagamentoDTO.PagamentoCartaoCredito.CodigoCvc,
                                                              pagamentoDTO.PagamentoCartaoCredito.Valor);

                        return Created("", _pedidoService.FinalizarPedido(idPedido, formaPagamento));

                    }

                case EFormaPagamento.CartaoDebito:
                    {
                        var formaPagamento = new CartaoDebito(pagamentoDTO.PagamentoCartaoDebito.NomeDoCartao,
                                                              pagamentoDTO.PagamentoCartaoDebito.NumeroCartao,
                                                              pagamentoDTO.PagamentoCartaoDebito.CodigoCvc,
                                                              pagamentoDTO.PagamentoCartaoDebito.Valor);

                        return Created("", _pedidoService.FinalizarPedido(idPedido, formaPagamento));

                    }

                case EFormaPagamento.Pix:
                    {
                        if (pagamentoDTO.PagamentoPix.ChavePix != null)
                        {
                            var formaPagamento = new Pix(pagamentoDTO.PagamentoPix.ChavePix, pagamentoDTO.PagamentoPix.Valor);

                            return Created("", _pedidoService.FinalizarPedido(idPedido, formaPagamento));
                        }
                        else
                        {
                            var formaPagamento = new Pix(pagamentoDTO.PagamentoPix.CodigoBanco,
                                                         pagamentoDTO.PagamentoPix.CodigoAgencia,
                                                         pagamentoDTO.PagamentoPix.NumeroConta,
                                                         pagamentoDTO.PagamentoPix.Valor);

                            return Created("", _pedidoService.FinalizarPedido(idPedido, formaPagamento));
                        }

                    }

                default:
                    return BadRequest("Tipo de pagamento inválido!");
            }

        }

        [HttpDelete, Route("{idPedido}/item/{idItem}")]
        public IActionResult RemoverItemPedido(Guid idPedido, Guid idItem)
        {
            try
            {
                return Created("", _pedidoService.RemoverItemPedido(idPedido, idItem));

            }catch (Exception ex)
            {
                return BadRequest("Erro ao remover item do pedido: " + ex.Message);
            }


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
