using System;
using System.Collections.Generic;

namespace YchetStudentov.Models;

public partial class Poseshaemost
{
    public int? NumberZacKnig { get; set; }

    public int? NumberDistceplini { get; set; }

    public int NumberUspevaemosti { get; set; }

    public string? Ocenka { get; set; }

    public DateTime? DataZanyatie { get; set; }

    public virtual Student? NumberZacKnigNavigation { get; set; }
}
