using System;
using Microsoft.AspNetCore.Identity;

namespace _1.MCargoExpress.Domain
{
    public class Usuario : IdentityUser
    {
        public bool Activo { get; set; }
    }
}