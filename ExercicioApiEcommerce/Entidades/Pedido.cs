using ExercicioApiEcommerce.DTOs;
using ExercicioApiEcommerce.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace ExercicioApiEcommerce.Entidades
{
    public class Pedido : EntidadeBase
    {
        private List<ItemPedido> _itensPedido;
        
        public DateTime DataPedido { get; private set; }
        public decimal ValorPedido { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public EFormaPagamento FormaPagamento { get; private set; }        
        public IReadOnlyList<ItemPedido> ItemPedido => _itensPedido;
        public Cliente Clientes { get; private set; }
        public Pagamento? Pagamento { get; private set; }
        
        public Pedido(Guid id, Cliente cliente) : base(id)
        {
            _itensPedido ??= new List<ItemPedido>();            
            Clientes = cliente;

        }

        public void AdicionarItemPedido(ItemPedido itemPedido)
        {
            if (_itensPedido.Any(i => i.Produto.Id == itemPedido.Produto.Id))
                throw new Exception("Produto já incluido, favor atualizar a quantidade!");

            _itensPedido.Add(itemPedido);
                                    
        }
        public void AtualizarItemPedido(Guid idItem, ItemPedido itemPedido)
        {
            _itensPedido.Where(w => w.Id == idItem).ToList().ForEach(f => f.Quantidade = itemPedido.Quantidade);
            
        }
        public void FinalizarPagamento(Pagamento pagamento)
        {
            Pagamento = pagamento;

        }

        public void RemoverItemPedido(Guid idItem)
        {
            _itensPedido.RemoveAll(x => x.Id == idItem);

        }

        public void CalcularTotal()
        {
            decimal valorTotal = 0;

            foreach(var c in _itensPedido) valorTotal += (c.Produto.Preco * c.Quantidade);

            this.ValorPedido = valorTotal;

        }

        public void FinalizarCompra(Pagamento pagamento)
        {
            if (pagamento.Valido)
            {
                Pagamento = pagamento;
                Console.WriteLine("Compra finalizada!!!");
            }
            else
            {
                throw new Exception("Forma de pagamento inválida!!");
            }

        }

    }
}
