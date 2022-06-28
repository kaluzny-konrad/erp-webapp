using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpService.Entities;

public class User : BaseEntity
{
    public User(int id, string unicalName, string password) : base(id, unicalName)
    {
        Password = password;
    }

    public string Password { get; }
}
