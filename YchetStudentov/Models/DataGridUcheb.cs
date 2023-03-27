using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class DataGridUcheb
{
    public string NumberGroup { get; set; } = null!;

    public string? NameDisceplini { get; set; }

    public string? Family { get; set; }

    public string? Name { get; set; }

    public string? Otchestvo { get; set; }

    public string? FormaAttest { get; set; }
}
