using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class Zanyatie
{
    public int NumberZanyatia { get; set; }

    public DateTime? DataProvedenie { get; set; }

    public string? NameDisceplini { get; set; }

    public string? TypeZanyatia { get; set; }
}
