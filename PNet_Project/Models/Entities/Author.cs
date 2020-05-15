using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PNet_Project.Models.Entities
{
    public class Author
    {
        [Key]

        public int AuthorId { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
