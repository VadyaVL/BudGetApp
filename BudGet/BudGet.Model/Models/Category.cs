using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace BudGet.Model.Models
{
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Icon { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public byte Coefficient { get; set; }

        [ForeignKey(typeof(Category))]
        public int ParentCategoryId { get; set; }

        [ManyToOne]
        public Category ParentCategory { get; set; }

        [OneToMany]
        public ICollection<Category> ChildCategories { get; set; }

        [OneToMany]
        public ICollection<Note> Notes { get; set; }
    }
}
