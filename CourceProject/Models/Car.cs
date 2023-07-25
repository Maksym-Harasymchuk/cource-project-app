using System.Collections;
using System.Collections.Generic;
using CourceProject.Models;

namespace CourceProject.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int YearOfProduction { get; set; }
        public double AveragePrice { get; set; }
        public string Type { get; set; }
        public string EngineDisplacement { get; set; }
        public int EngineHorsepower { get; set; }
        public int QuantityInCountry { get; set; }

        public string PictureUrl { get; set; }
        public string PublicId { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}