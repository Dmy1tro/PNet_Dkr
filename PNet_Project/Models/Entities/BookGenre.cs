using System.ComponentModel.DataAnnotations.Schema;

namespace PNet_Project.Models.Entities
{
    public class BookGenre
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        public Book Book { get; set; }

        public Genre Genre { get; set; }
    }
}
