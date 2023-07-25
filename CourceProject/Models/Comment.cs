using System;
using CourceProject.Entities;

namespace CourceProject.Models;

public class Comment
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string Body { get; set; }
    public string UserName { get; set; }
    public Car Car { get; set; }
}