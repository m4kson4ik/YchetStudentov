using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class Group
{
    public string PolnNameSpec { get; set; } = null!;

    public string NumberGroup { get; set; } = null!;

    public string? NumberSpecialnosti { get; set; }

    public string? Kurator { get; set; }

    public virtual Specialnosti? NumberSpecialnostiNavigation { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<UchebPlan> UchebPlans { get; } = new List<UchebPlan>();
}
