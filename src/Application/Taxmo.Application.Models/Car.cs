﻿namespace Taxmo.Application.Models;

public class Car
{
    public string CarNumber { get; set; } // Unique, Not null
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateTime? Year { get; set; }
    public CarPark CarPark { get; set; }
}