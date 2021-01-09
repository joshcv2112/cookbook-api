using System;
using System.ComponentModel.DataAnnotations;

namespace CookbookAPI.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public int RecipeId { get; set; }
        public string NoteMessage { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
