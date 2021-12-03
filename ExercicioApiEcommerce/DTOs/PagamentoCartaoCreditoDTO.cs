using ExercicioApiEcommerce.Enumeradores;
using System;

namespace ExercicioApiEcommerce.DTOs
{
    public class PagamentoCartaoCreditoDTO : Validator
    {
        public string NomeDoCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string CodigoCvc { get; set; }
        public decimal Valor { get; set; }

        public PagamentoCartaoCreditoDTO(string nomeDoCartao, string numeroCartao, string codigoCvc, decimal valor)
        {
            NomeDoCartao = nomeDoCartao;
            NumeroCartao = numeroCartao;
            CodigoCvc = codigoCvc;
            Valor = valor;
            
            Validar();
        }

        public override void Validar()
        {
            Valido = true;

            if (Valor <= 0)
            {
                Valido = false;
                throw new Exception ("Deve ser informado um valor.");
            }

            if (CodigoCvc.Length != 3)
            {
                Valido = false;
                throw new Exception("Código CVC inválido.");
            }

            if (NumeroCartao.Length < 11)
            {
                Valido = false;
                throw new Exception("Numero do cartão inválido.");
            }
        }
    }
}
