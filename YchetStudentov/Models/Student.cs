using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class Student
{
    public int NumberZacKnig { get; set; }

    public string? NumberGroup { get; set; }

    public string? Name { get; set; }

    public string? Family { get; set; }

    public string? Otchesto { get; set; }

    public DateTime? DataRoj { get; set; }

    public string? AdressProj { get; set; }

    public string? Gragdanstvo { get; set; }

    public string? Email { get; set; }

    public int? GodPostuplenya { get; set; }

    public string? Budget { get; set; }

    public virtual Group? NumberGroupNavigation { get; set; }

    public virtual ICollection<Poseshaemost> Poseshaemosts { get; } = new List<Poseshaemost>();
}
