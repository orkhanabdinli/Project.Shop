﻿using Shop.Core.Abstract;

namespace Shop.Core.Entities;

public class Cart : BaseEntities
{
    public int Id { get; set; }
    public User User { get; set; } = null!;
}
