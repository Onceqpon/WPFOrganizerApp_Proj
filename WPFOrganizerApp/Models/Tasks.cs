using System;
using System.Collections.Generic;

namespace WPFOrganizerApp.Models;

public partial class Tasks
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Priority { get; set; }

    public bool? IsCompleted { get; set; }

    public virtual User User { get; set; } = null!;
}
