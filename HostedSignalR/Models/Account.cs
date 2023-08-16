using System;
using System.Collections.Generic;

namespace HostedSignalR.Models;

public partial class Account
{
    public Guid AccountId { get; set; }

    public DateTime DateCreated { get; set; }

    public string AccountType { get; set; } = null!;

    public Guid OwnerId { get; set; }

    public virtual Owner Owner { get; set; } = null!;
}
