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
    [Table("VoiceLog")]
    public class VoiceLog
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Guild Guild { get; set; }
        public DateTime DateTimeEnter { get; set; }
        public DateTime DateTimeExit { get; set; }
    }
}
