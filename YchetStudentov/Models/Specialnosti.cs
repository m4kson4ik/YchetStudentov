using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class Specialnosti
{
    public string? NameSpecialnosti { get; set; }

    public string NumberSpecialnosti { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; } = new List<Group>();
}
