using System;
using System.ComponentModel.DataAnnotations;

namespace Mission_4.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

    }
}
