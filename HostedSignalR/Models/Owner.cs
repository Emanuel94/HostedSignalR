using System;
using System.Collections.Generic;

namespace HostedSignalR.Models;

public partial class Owner
{
    public Guid OwnerId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
