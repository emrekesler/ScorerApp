using Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace ScorerApp.Entity.Entities
{
    public class Team : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
