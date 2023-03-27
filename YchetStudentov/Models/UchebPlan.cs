using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class UchebPlan
{
    public int NumberUchebPlan { get; set; }

    public string? NumberGroup { get; set; }

    public int? NumberDisceplini { get; set; }

    public virtual Distceplini? NumberDiscepliniNavigation { get; set; }

    public virtual Group? NumberGroupNavigation { get; set; }
}
