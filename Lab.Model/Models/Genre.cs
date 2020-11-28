using System.ComponentModel.DataAnnotations.Schema;

namespace Lab.Model.Models
{
    //change the name of the table
    [Table("tb_genre")]
    public class Genre
    {
        public int GenreId { get; set; }

        //change the name of the column
        [Column("Name")]
        public string GenreName { get; set; }
        //public int DispalayOrder { get; set; }
    }
}
