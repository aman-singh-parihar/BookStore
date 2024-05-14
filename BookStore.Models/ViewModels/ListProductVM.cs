using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Models.ViewModels
{
    public class ListProductVM
    {
        public Product Product { get; set; }
        [ValidateNever]
        public SelectListItem Category { get; set; }
    }
}
