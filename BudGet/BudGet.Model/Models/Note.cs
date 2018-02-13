using SQLite;
using System;

namespace BudGet.Model.Models
{
    [Table("Note")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public float Sum { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }
        
        //public Category Category { get; set; }
    }
}
