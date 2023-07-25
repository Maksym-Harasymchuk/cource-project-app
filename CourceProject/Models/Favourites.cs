using CourceProject.Entities;

namespace CourceProject.Models;

public class Favourite
{
    public int Id { get; set; }
    public Car Car { get; set; }
    public int? CarId { get; set; }

    public string Manufacturer { get; set; }
    public string CarModel { get; set; }
    public string UserId { get; set; }
}