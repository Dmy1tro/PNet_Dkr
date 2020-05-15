using System.Linq;
using PNet_Project.Models.Entities;

namespace PNet_Project.Models.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(Book book)
        {
            BookId = book.BookId;

            AuthorId = book.AuthorId;

            Title = book.Title;

            Date = book.Date?.ToShortDateString();

            Description = book.Description;

            Price = book.Price;

            Author = book.Author?.Name ?? "Unknown";

            Genres = string.Join(", ", book.BookGenres.Select(x => x.Genre.GenreName).ToList());
        }

        public int BookId { get; set; }

        public int? AuthorId { get; set; }

        public string Title { get; set; }

        public string Date { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Author { get; set; }

        public string Genres { get; set; }
    }
}
