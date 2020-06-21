using System;

namespace Core.Entity
{
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
        }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
