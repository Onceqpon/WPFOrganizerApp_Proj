using System;
using System.Collections.Generic;

namespace WPFOrganizerApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
