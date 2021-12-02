using ExercicioApiEcommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExercicioApiEcommerce.Servicos
{
    public class ClienteService
    {
        private readonly List<Cliente> _clientes;
        private readonly PedidoService _pedidoService;
        public ClienteService(PedidoService pedidoService)
        {
            _clientes ??= new List<Cliente>();
            _pedidoService ??= pedidoService;
        }

        public IEnumerable<Cliente> Get() => _clientes;

        public Cliente Get(Guid id) => _clientes.Where(u => u.Id == id).SingleOrDefault();

        public Cliente Cadastrar(Cliente cliente)
        {
            _clientes.Add(cliente);
            _pedidoService.Cadastrar(cliente.Pedido);
            return cliente;
        }

        public Cliente Atualizar(Guid id, Cliente cliente)
        {
            var cli = _clientes.SingleOrDefault(u => u.Id == id);

            if (cli is null)
                throw new Exception("Cliente não encontrado!");

            cli.Atualizar(cliente);
            return cli;

        }

        public bool Delete(Guid id)
        {
            var retorno = true;

            var cliente = _clientes.SingleOrDefault(u => u.Id == id);

            if (cliente is null) 
            {
                retorno = false;
            }
            else
            {
                _clientes.Remove(cliente);
            }
             
            return retorno;
        }

    }
}
