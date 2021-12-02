using System;

namespace ExercicioApiEcommerce.DTOs
{
    public class ItemPedidoDTO : Validator
    {
        public int Quantidade { get; set; }
        public ProdutoDTO Produto { get; set; }

        public override void Validar()
        {
            Valido = true;

            if (Quantidade <= 0)
                Valido = false;

            //Produto.Validar();


        }
    }
}
