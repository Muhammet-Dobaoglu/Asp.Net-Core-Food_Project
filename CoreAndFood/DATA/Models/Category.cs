using Microsoft.Build.Framework;
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CoreAndFood.DATA.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Category Name Not Empty")]
        [StringLength(20,ErrorMessage ="Please maximum enter 4-20 lenght characters",MinimumLength =4)]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public List<Food> Foods { get; set; }
    }
}
