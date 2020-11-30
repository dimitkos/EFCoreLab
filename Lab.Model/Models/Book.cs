using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab.Model.Models
{
    public class Book
    {
        //set this property as primary key
        [Key]
        public int Book_Id { get; set; }
        //this prop is required cannot be nulled
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(15)]
        public string ISBN { get; set; }
        [Required]
        public double Price { get; set; }

        [ForeignKey("BookDetail")]
        public int BookDetail_Id { get; set; }
        public BookDetail BookDetail { get; set; }

        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        public Publisher Publisher { get; set; }

        public  ICollection<Author> Authors { get; set; }
    }
}
