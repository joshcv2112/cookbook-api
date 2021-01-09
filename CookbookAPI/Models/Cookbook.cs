using System;
using System.ComponentModel.DataAnnotations;

namespace CookbookAPI.Models
{
    public class Cookbook
    {
        [Key]
        public int CookbookId { get; set; }
        public string CookbookName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int UserId { get; set; }
    }
}
