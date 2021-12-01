using System;

namespace ExercicioApiEcommerce.DTOs
{
    public class ProdutoDTO : Validator
    {
        public Guid? Id { get; set; }
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public decimal Preco { get;  set; }
        
        public override void Validar()
        {
            Valido = true;

            if(string.IsNullOrEmpty(Nome) || Nome.Length > 150)
                Valido = false;

            if(string.IsNullOrEmpty(Descricao) || Descricao.Length > 1000)
                Valido = false;

            if(Preco <= 0)
                Valido = false;

        }

    }
}
