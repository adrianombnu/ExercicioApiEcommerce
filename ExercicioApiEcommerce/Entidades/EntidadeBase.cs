using System;

namespace ExercicioApiEcommerce.Entidades
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase(Guid id)
        {
            Id = id;
        }
            
        public Guid Id { get; private set; }

    }
}
