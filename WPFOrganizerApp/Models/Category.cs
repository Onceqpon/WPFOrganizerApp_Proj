using System;
using System.Collections.Generic;

namespace WPFOrganizerApp.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
}
