using SQLite;
using SQLiteNetExtensions.Attributes;
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

        [ForeignKey(typeof(Category))]
        public int CategoryId { get; set; }

        [ManyToOne]
        public Category Category { get; set; }
    }
}
