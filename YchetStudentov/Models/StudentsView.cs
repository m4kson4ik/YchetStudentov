using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class StudentsView
{
    public int NumberZacKnig { get; set; }

    public string? Name { get; set; }

    public string? Family { get; set; }

    public string NumberGroup { get; set; } = null!;
}
