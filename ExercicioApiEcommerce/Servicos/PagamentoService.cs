using ExercicioApiEcommerce.Entidades;
using System;
using System.Collections.Generic;

namespace ExercicioApiEcommerce.Servicos
{
    public class PagamentoService
    {
        private readonly PedidoService _pedidoService;

        public PagamentoService(PedidoService pedidoService)
        {
            _pedidoService ??= pedidoService;
        }

        

    }
}
