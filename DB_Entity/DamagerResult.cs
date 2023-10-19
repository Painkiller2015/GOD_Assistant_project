using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD_Assistant.DB_Entity
{
    [PrimaryKey("Id")]
    [Table("DamagerResults")]
    public class DamagerResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Attachment Attachment { get; set; }
        public float Damager { get; set; }
        public int Deaths { get; set; }
        public int RoundsCount { get; set; }
        public bool Win { get; set; }
        public float FinalScore { get; set; }
    }
}
