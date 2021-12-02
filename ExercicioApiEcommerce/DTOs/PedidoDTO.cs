using ExercicioApiEcommerce.Entidades;
using ExercicioApiEcommerce.Enumeradores;
using System;
using System.Collections.Generic;

namespace ExercicioApiEcommerce.DTOs
{
    public class PedidoDTO : Validator
    {
        public Guid Id { get;  set; }
        public DateTime DataPedido { get;  set; }
        public decimal ValorPedido { get;  set; }
        public DateTime DataPagamento { get;  set; }
        public ETipoPagamento TipoPagamento { get;  set; }
        public List<ItemPedidoDTO> ItensPedido { get; set; }
        public ClienteDTO Clientes { get;  set; }

        public override void Validar()
        {
            Valido = true;

            if (ValorPedido <= 0)
                Valido = false;

            if(Clientes is null)
                Valido = false;
        }
    }
}
