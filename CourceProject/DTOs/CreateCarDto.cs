using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CourceProject.DTOs;

public class CreateCarDto
{
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int YearOfProduction { get; set; }
        [Required]
        [Range(100, float.PositiveInfinity)]
        public float AveragePrice { get; set; } // double
        [Required]
        public string Type { get; set; }
        [Required]
        [Range(0,double.PositiveInfinity)]
        public int QuantityInCountry { get; set; }
        [Required]
        public string EngineDisplacement { get; set; } // double
        [Required]
        public int EngineHorsepower { get; set; }
        [Required]
        public IFormFile File { get; set; }
}