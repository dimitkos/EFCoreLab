using System.ComponentModel.DataAnnotations;

namespace Lab.Model.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        public string Name { get; set; }
    }
}
