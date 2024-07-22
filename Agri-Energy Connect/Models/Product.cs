using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ST10079389_Kaushil_Dajee_PROG7311.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ProductionDate { get; set; }

    public int? CategoryId { get; set; }

    public int? UserId { get; set; }

    public virtual Category? Category { get; set; } = null!;
    public virtual User? User { get; set; } = null!;
}
