using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class Prepodovateli
{
    public string? Family { get; set; }

    public string? Name { get; set; }

    public string? Otchestvo { get; set; }

    public int LoginPrepodovatela { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Distceplini> Distceplinis { get; } = new List<Distceplini>();
}
