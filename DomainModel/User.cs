using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Surname { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Client? Client { get; set; }

    public virtual Courier? Courier { get; set; }

    public virtual Manager? Manager { get; set; }
}
