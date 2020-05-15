using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using PNet_Project.Models.Entities;

namespace PNet_Project.Context
{
    public class SampleData
    {
        private readonly ShopDbContext _context;

        public SampleData(ShopDbContext context)
        {
            _context = context;
        }

        public void ProceedData()
        {
            if (!_context.Authors.Any())
            {
                _context.Authors.AddRange(GetAuthors());
            }

            if (!_context.Genres.Any())
            {
                _context.Genres.AddRange(GetGenres());

                _context.SaveChanges();
            }

            if (!_context.Books.Any())
            {
                _context.Books.AddRange(GetBooks());

                _context.SaveChanges();
            }

            if (!_context.BookGenres.Any())
            {
                _context.BookGenres.AddRange(getBookGenres());

                _context.SaveChanges();
            }
        }

        private IList<Genre> GetGenres() =>
            new List<Genre>
            {
                new Genre
                {
                    GenreName = "Dystopian"
                },
                new Genre
                {
                    GenreName = "Fantasy"
                },
                new Genre
                {
                    GenreName = "Science fiction"
                },
                new Genre
                {
                    GenreName = "Horror"
                }
            };

        private IList<BookGenre> getBookGenres() =>
            new List<BookGenre>
            {
                new BookGenre
                {
                    BookId = 1,
                    GenreId = 1
                },
                new BookGenre
                {
                    BookId = 2,
                    GenreId = 3
                },
                new BookGenre
                {
                    BookId = 3,
                    GenreId = 4
                },
                new BookGenre
                {
                    BookId = 4,
                    GenreId = 2
                },
            };

        private IList<Author> GetAuthors() =>
            new List<Author>
            {
                new Author
                {
                    Name = "Ray Bradbury",
                    DateOfBirth = new DateTime(1920, 8, 22)
                },

                new Author
                {
                    Name = "Stephen King",
                    DateOfBirth = new DateTime(1947, 9, 21)
                }
            };

        private IList<Book> GetBooks() =>
            new List<Book>
            {
                new Book
                {
                    Title = "Fahrenheit 451",
                    Description = "Some description...",
                    AuthorId = 1,
                    Price = 200,
                    Date = new DateTime(1953, 1, 1)
                },

                new Book
                {
                    Title = "Dandelion Wine",
                    Description = "Some description...",
                    AuthorId = 1,
                    Price = 200,
                    Date = new DateTime(1957, 1, 1)
                },

                new Book
                {
                    Title = "It",
                    Description = "Description...",
                    AuthorId = 2,
                    Price = 200,
                    Date = new DateTime(1986, 1, 1)
                },

                new Book
                {
                    Title = "The Green Mile",
                    Description = "Description...",
                    AuthorId = 2,
                    Price = 200,
                    Date = new DateTime(1996, 1, 1)
                }
            };
    }
}
