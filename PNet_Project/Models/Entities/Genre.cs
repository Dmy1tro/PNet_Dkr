using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PNet_Project.Models.Entities
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Genre name")]
        public string GenreName { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
