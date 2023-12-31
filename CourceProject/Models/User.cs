﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CourceProject.Models
{
    public class User : IdentityUser
    {
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}