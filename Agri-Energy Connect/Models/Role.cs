using System;
using System.Collections.Generic;

namespace ST10079389_Kaushil_Dajee_PROG7311.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? Role1 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
