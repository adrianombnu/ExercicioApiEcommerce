using ExercicioApiEcommerce.Enumeradores;
using System;

#nullable enable
namespace ExercicioApiEcommerce.Entidades
{
    public class Cliente : EntidadeBase
    {
        public Cliente(string nome, string sobrenome, string documento, int idade, ETipoPessoa tipoPessoa)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            Idade = idade;
            TipoPessoa = tipoPessoa;

            CriarPedido();

        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Documento { get; private set; }
        public int Idade { get; private set; }
        public ETipoPessoa TipoPessoa { get; private set; }
        public Pedido? Pedido { get; private set; }

        public void Atualizar(Cliente cliente)
        {
            Nome = cliente.Nome;
            Sobrenome = cliente.Sobrenome;
            Documento = cliente.Documento;
            Idade = cliente.Idade;

        }

        public void CriarPedido()
        {
            Pedido ??= new Pedido(Guid.NewGuid(), this);
        }


    }
}
