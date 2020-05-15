using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace PNet_Project.Models.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [ForeignKey(nameof(Author))]
        [DisplayName("Author name")]
        public int? AuthorId { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Date")]
        public DateTime? Date { get; set; }

        [MaxLength(300)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }

        [JsonIgnore]
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
