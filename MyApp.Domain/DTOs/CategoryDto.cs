﻿namespace MyApp.Domain.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public virtual List<ProductDto>? Products { get; set; }
}