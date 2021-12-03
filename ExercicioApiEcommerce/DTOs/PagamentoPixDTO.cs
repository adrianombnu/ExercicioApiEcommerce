using System;

namespace ExercicioApiEcommerce.DTOs
{
    public class PagamentoPixDTO : Validator
    {
        public string ChavePix { get; set; }
        public int CodigoBanco { get; set; }
        public int CodigoAgencia { get; set; }
        public int NumeroConta { get; set; }
        public decimal Valor { get; set; }

        public PagamentoPixDTO(string chavePix, decimal valor)
        {
            ChavePix = chavePix;
            Valor = valor;
            
            Validar();
        }

        public PagamentoPixDTO(int codigoBanco, int codigoAgencia, int numeroConta, decimal valor)
        {
            CodigoBanco = codigoBanco;
            CodigoAgencia = codigoAgencia;
            NumeroConta = numeroConta;
            Valor = valor;
            
            Validar();
        }

        public override void Validar()
        {
            Valido = true;

            if (Valor <= 0)
            {
                Valido = false;
                throw new Exception("Deve ser informado um valor.");
            }
        }
    }
}
