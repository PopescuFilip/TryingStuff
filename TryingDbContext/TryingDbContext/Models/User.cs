﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TryingDbContext.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Password { get; set; }
}