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
    [Table("ClanApplication")]
    public class ClanApplication
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime AnswerDate { get; set; }
        public User Respondent { get; set; }
        public int RespondentId { get; set; }
        public bool Answer { get; set; }
        public string Reason { get; set; }
        public bool IsDeleted { get; set; }
        public ClanApplication()
        {

        }
    }
}
