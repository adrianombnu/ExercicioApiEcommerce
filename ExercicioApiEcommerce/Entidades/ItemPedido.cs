using System;

namespace ExercicioApiEcommerce.Entidades
{
    public class ItemPedido : EntidadeBase
    {
        public ItemPedido(int quantidade, Guid id) : base(id)
        {
            Quantidade = quantidade;
            
        }

        public int Quantidade { get; set; }
        public Produto Produto { get; set; }


        public void Atualizar(ItemPedido itemPedido)
        {
            Quantidade = itemPedido.Quantidade;
           
        }
        
    }
}
