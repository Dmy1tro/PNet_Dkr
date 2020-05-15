using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PNet_Project.Context;
using PNet_Project.Models.Entities;
using PNet_Project.Models.ViewModels;

namespace PNet_Project.Controllers
{
    public class BookController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly Func<IEnumerable<SelectListItem>> _mapToAuthorListItems;

        public BookController(ILogger<BookController> logger, ShopDbContext context)
        {
            _context = context;

            _context.Notify += () =>
            {
                logger.LogInformation($"Changes saved. Date: {DateTime.UtcNow}");
            };

            _mapToAuthorListItems = GetAuthorsListItems;
        }

        public IActionResult BookList()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var books = _context.Books
                .Include(x => x.Author)
                .Include(x => x.BookGenres)
                    .ThenInclude(x => x.Genre)
                .AsNoTracking()
                .ToList();

            var viewModel = books
                .Select(x => new BookViewModel(x))
                .ToList();

            return View(viewModel);
        }

        public IActionResult AddOrEdit(int? id)
        {
            ViewData["Authors"] = _mapToAuthorListItems();

            if (id.HasValue)
            {
                var book = _context.Books.FirstOrDefault(x => x.BookId == id);

                return View(book);
            }

            return View();
        }

        public IActionResult BookGenres(int id)
        {
            var bookGenres = _context.BookGenres
                .AsNoTracking()
                .Where(x => x.BookId == id)
                .Select(x => x.GenreId)
                .ToList();

            var genres = _context.Genres
                .AsNoTracking()
                .Select(x => new BookGenreViewModel
                {
                    GenreId = x.GenreId,
                    GenreName = x.GenreName,
                    Selected = bookGenres.Contains(x.GenreId)
                })
                .ToList();

            var book = _context.Books
                .AsNoTracking()
                .FirstOrDefault(x => x.BookId == id);

            return View(new BookGenresViewModel { Book = book, Genres = genres });
        }

        [HttpPost]
        public IActionResult BookGenres(BookGenresViewModel model)
        {
            var bookGenresModel = model.Genres
                .Where(x => x.Selected)
                .ToList();

            var existing = _context.BookGenres
                .Where(x => x.BookId == model.Book.BookId)
                .ToList();

            _context.BookGenres.RemoveRange(existing);
            _context.SaveChanges();

            var bookGenres = bookGenresModel
                .Select(x => new BookGenre { GenreId = x.GenreId, BookId = model.Book.BookId })
                .ToList();

            _context.BookGenres.AddRange(bookGenres);
            _context.SaveChanges();

            return RedirectToAction("BookList");
        }

        [HttpPost]
        public IActionResult AddOrEdit(Book model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Authors"] = _mapToAuthorListItems();
                return View(model);
            }

            if (model.BookId == 0)
            {
                _context.Books.Add(model);
                _context.SaveChanges();
            }
            else
            {
                _context.Books.Update(model);
                _context.SaveChanges();
            }

            return RedirectToAction("BookList");
        }


        public IActionResult Delete(int id)
        {
            var book = _context.Books
                .FirstOrDefault(x => x.BookId == id);

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("BookList");
        }

        private IEnumerable<SelectListItem> GetAuthorsListItems()
        {
            var authors = _context.Authors
                .AsNoTracking()
                .ToList();

            return authors
                .Select(x => new SelectListItem(x.Name, x.AuthorId.ToString()))
                .ToList();
        }
    }
}