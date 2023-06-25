using System;
using System.Collections.Generic;

namespace WPFOrganizerApp.Models;

public partial class Note
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
