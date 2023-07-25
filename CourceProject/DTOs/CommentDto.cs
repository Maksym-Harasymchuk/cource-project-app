using System;

namespace CourceProject.DTOs;

public class CommentDto
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string Body { get; set; }
}