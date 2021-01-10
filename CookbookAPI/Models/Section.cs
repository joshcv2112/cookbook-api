using System.ComponentModel.DataAnnotations;

namespace CookbookAPI.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        public int CookbookId { get; set; }
        public string SectionName { get; set; }
    }
}
