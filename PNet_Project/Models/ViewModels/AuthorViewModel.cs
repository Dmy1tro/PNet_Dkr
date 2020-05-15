using PNet_Project.Models.Entities;

namespace PNet_Project.Models.ViewModels
{
    public class AuthorViewModel
    {
        public AuthorViewModel(Author author)
        {
            AuthorId = author.AuthorId;
            Name = author.Name;
            DateOfBirth = author.DateOfBirth.ToShortDateString();
        }

        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string DateOfBirth { get; set; }
    }
}
