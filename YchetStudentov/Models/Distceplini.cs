using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class Distceplini
{
    public int NumberDisceplini { get; set; }

    public string? NameDisceplini { get; set; }

    public string? FormaAttest { get; set; }

    public int? LoginPrepodovatela { get; set; }

    public virtual Prepodovateli? LoginPrepodovatelaNavigation { get; set; }

    public virtual ICollection<UchebPlan> UchebPlans { get; } = new List<UchebPlan>();
}
