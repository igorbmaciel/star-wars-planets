using System;
using System.ComponentModel.DataAnnotations;

namespace star_wars_planets.Application.ViewModels
{
    public sealed class PlanetViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill in the Name field")]
        [MaxLength(150, ErrorMessage = "Maximum {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimum {0} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill in the Weather field")]
        [MaxLength(150, ErrorMessage = "Maximum {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimum {0} caracteres")]
        public string Weather { get; set; }


        [Required(ErrorMessage = "Fill in the Ground field")]
        [MaxLength(150, ErrorMessage = "Maximum {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimum {0} caracteres")]
        public string Ground { get; set; }
        
        public int MovieQuantity { get; set; }


    }
}
