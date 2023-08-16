using System;
using System.Collections.Generic;

namespace HostedSignalR.Models;

public partial class UserAuth
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
