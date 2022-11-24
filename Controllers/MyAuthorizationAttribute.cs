using System;

namespace WebApplication2.Controllers
{
    internal class MyAuthorizationAttribute : Attribute
    {
        public string Roles { get; set; }
    }
}