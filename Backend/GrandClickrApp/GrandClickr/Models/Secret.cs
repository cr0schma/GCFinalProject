using System;
using System.Collections.Generic;

namespace GrandClickr.Models;

public partial class Secret
{
    public int? UserId { get; set; }

    public string? Password { get; set; }

    public virtual UserName? User { get; set; }
}
