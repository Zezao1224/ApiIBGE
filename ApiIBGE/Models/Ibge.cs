﻿using System.ComponentModel.DataAnnotations;

namespace ApiIBGE.Models;

public class Ibge
{
    public int Id { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
}
