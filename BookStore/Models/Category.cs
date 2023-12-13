using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table(name: "Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Category Name is required") ]
        [StringLength(maximumLength: 100, MinimumLength = 3 , ErrorMessage = "Category Name should be b/w 1 and 100")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Required(ErrorMessage = "Display Order is required")]  
        [Range(1,100, ErrorMessage = "Display order should be b/w 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
