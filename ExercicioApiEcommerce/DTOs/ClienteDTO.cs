using ExercicioApiEcommerce.Enumeradores;
#nullable enable
namespace ExercicioApiEcommerce.DTOs
{
    public class ClienteDTO : Validator
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public int Idade { get; set; }
        public ETipoPessoa TipoPessoa { get; set; }
        public PedidoDTO? Pedido { get; set; }

        public override void Validar()
        {
            Valido = true;

            if (string.IsNullOrEmpty(Nome) || Nome.Length > 150)
                Valido = false;

            if (string.IsNullOrEmpty(Sobrenome) || Sobrenome.Length > 150)
                Valido = false;

            if (string.IsNullOrEmpty(Documento)) 
                Valido = false;

            if(TipoPessoa == ETipoPessoa.Fisica)
                Valido = ValidarCpf(Documento);

            if (TipoPessoa == ETipoPessoa.Juridica)
                Valido = ValidarCnpj(Documento);

            if (Idade <= 0)
                Valido = false;

        }

        private bool ValidarCpf(string cpf)
        {
            return true;
        }

        private bool ValidarCnpj(string cpf)
        {
            return true;
        }

    }
}
