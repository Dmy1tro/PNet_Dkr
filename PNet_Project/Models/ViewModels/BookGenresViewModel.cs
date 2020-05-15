using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using PNet_Project.Models.Entities;

namespace PNet_Project.Models.ViewModels
{
    public class BookGenresViewModel
    {
        public Book Book { get; set; }

        public List<BookGenreViewModel> Genres { get; set; }
    }
}
