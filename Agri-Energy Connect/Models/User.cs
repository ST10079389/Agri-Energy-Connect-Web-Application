using System;
using System.Collections.Generic;

namespace ST10079389_Kaushil_Dajee_PROG7311.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; } = null!;
}
