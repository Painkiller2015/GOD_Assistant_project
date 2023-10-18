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
    [Table("Attachments")]
    public class Attachment
    {
        public int Id { get; set; }
        public ulong MessageId { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
    }
}
