using System;

namespace Logic.Entities
{
    public abstract class List : IEntity
    {
        public virtual Guid Id { get; set; }
    }
}
