using ExercicioApiEcommerce.DTOs;
using ExercicioApiEcommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExercicioApiEcommerce.Servicos
{
    public class PedidoService
    {
        private readonly List<Pedido> _pedidos;
        public PedidoService()
        {
            _pedidos ??= new List<Pedido>();
        }

        public Pedido Cadastrar(Pedido pedido)
        {
            _pedidos.Add(pedido);
            
            return pedido;
        }

        public Pedido AdicionarItemPedido(Guid id, ItemPedido itemPedido)
        {
            var ped = _pedidos.SingleOrDefault(u => u.Id == id);

            if (ped is null)
                throw new Exception("Pedido não encontrado!");

            ped.AdicionarItemPedido(itemPedido);            
            ped.CalcularTotal();            
            return ped;

        }

        public Pedido AtualizarItemPedido(Guid id,Guid idItem, ItemPedido itemPedido)
        {
            var ped = _pedidos.SingleOrDefault(u => u.Id == id);

            if (ped is null)
                throw new Exception("Pedido não encontrado!");

            ped.AtualizarItemPedido(idItem, itemPedido);            
            ped.CalcularTotal();            
            return ped;

        }

        public Pedido FinalizarPedido(Guid id, Pagamento pagamento)
        {
            var ped = _pedidos.SingleOrDefault(u => u.Id == id);
            
            if (ped is null)
                throw new Exception("Pedido não encontrado!");
            
            if(ped.ValorPedido != pagamento.Valor) throw new Exception("Valor do pagamento inválido!");
            
            ped.FinalizarPedido(pagamento);

            return ped;

        }

        public Pedido RemoverItemPedido(Guid id, Guid idItem)
        {
            var ped = _pedidos.SingleOrDefault(u => u.Id == id);

            if (ped is null)
                throw new Exception("Pedido não encontrado!");

            var item = ped.ItemPedido.SingleOrDefault(u => u.Id == idItem);

            if (item is null)
                throw new Exception("Item não encontrado!");

            ped.RemoverItemPedido(idItem);
            ped.CalcularTotal();
            return ped;

        }

        public Pedido Get(Guid id) => _pedidos.Where(u => u.Id == id).SingleOrDefault();
        public IEnumerable<Pedido> Get() => _pedidos;
        
        public bool Delete(Guid id)
        {
            var retorno = true;

            var cliente = _pedidos.SingleOrDefault(u => u.Id == id);

            if (cliente is null)
            {
                retorno = false;
            }
            else
            {
                _pedidos.Remove(cliente);
            }

            return retorno;
        }


    }
}
