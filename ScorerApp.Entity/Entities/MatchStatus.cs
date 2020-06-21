using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScorerApp.Entity.Entities
{
    public class MatchStatus : BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
