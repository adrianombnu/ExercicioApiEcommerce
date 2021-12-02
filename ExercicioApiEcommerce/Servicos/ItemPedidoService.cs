using ExercicioApiEcommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExercicioApiEcommerce.Servicos
{
    public class ItemPedidoService
    {
        private readonly List<ItemPedido> _itensPedido;
        public ItemPedidoService()
        {
            _itensPedido ??= new List<ItemPedido>();
        }

        public IEnumerable<ItemPedido> Get() => _itensPedido;

        public ItemPedido Get(Guid id) => _itensPedido.Where(u => u.Id == id).SingleOrDefault();

        public ItemPedido Cadastrar(ItemPedido itensPedido)
        {
            _itensPedido.Add(itensPedido);
            return itensPedido;
        }

        public ItemPedido Atualizar(Guid id, ItemPedido itensPedido)
        {
            var itens = _itensPedido.SingleOrDefault(u => u.Id == id);

            if (itens is null)
                throw new Exception("Item não encontrado!");

            itens.Atualizar(itensPedido);
            return itens;

        }

        public bool Delete(Guid id)
        {
            var retorno = true;

            var itens = _itensPedido.SingleOrDefault(u => u.Id == id);

            if (itens is null)
            {
                retorno = false;
            }
            else
            {
                _itensPedido.Remove(itens);
            }

            return retorno;
        }
    }
}
