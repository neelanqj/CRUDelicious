using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        [Required]
        public string Chef { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,5, ErrorMessage="Tastiness must be between 1 and 5")]
        public int Tastiness { get; set; }
        [Range(0, Double.PositiveInfinity)]
        public int Calories { get; set; }
        public string Description { get; set; } 
        public DateTime CreateAt { get; set; }  
        public DateTime UpdatedAt { get; set; }
    }
}