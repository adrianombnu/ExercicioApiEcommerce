using System;

namespace ExercicioApiEcommerce.Entidades
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
            
        public Guid Id { get; private set; }

    }
}
