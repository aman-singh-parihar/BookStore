using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table(name: "Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "List Price")]
        public double ListPrice { get; set; }

        [Display(Name = "Price for 1-50")]
        public double Price { get; set; }

        [Display(Name = "Price for 50+")]
        public double Price50 { get; set; }

        [Display(Name = "Price for 100+")]
        public double Price100 { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Display(Name = "Image Url")]
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
