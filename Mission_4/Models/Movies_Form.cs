using System;
using System.ComponentModel.DataAnnotations;

namespace Mission_4.Models
{
    public class Movies_Form
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        // Build foreign key relationship
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string Lent { get; set; }

        public string Notes { get; set; }


    }
}
