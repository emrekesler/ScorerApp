using Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace ScorerApp.Entity.Entities
{
    public class League : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
