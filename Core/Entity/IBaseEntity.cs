using System;

namespace Core.Entity
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
        bool IsActive { get; set; }
    }
}
