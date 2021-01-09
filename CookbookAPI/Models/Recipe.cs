using System.ComponentModel.DataAnnotations;

namespace CookbookAPI.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public int Rating { get; set; }
        public string PrepTime { get; set; }
        public string ImageURL { get; set; }
        public int SectionId { get; set; }
        public int CookbookId { get; set; }
    }
}
