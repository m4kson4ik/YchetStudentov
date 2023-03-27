using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class GetPredmet
{
    public int LoginPrepodovatela { get; set; }

    public string? NumberGroup { get; set; }

    public string? NameDisceplini { get; set; }
}
