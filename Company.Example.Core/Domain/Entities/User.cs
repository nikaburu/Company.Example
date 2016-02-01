using System;
using System.Collections.Generic;

namespace Company.Example.Core.Domain.Entities
{
	public partial class User
    {
        public User() { }
    
        public int Id { get; set; }
        public string Login { get; set; }
    }
}