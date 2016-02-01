using System;
using System.Collections.Generic;

namespace Company.Example.Core.Domain.Entities
{
	public partial class TimeEntry
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public float Hours { get; set; }
        public short Type { get; set; }
        public System.DateTime LastModified { get; set; }
    
        public virtual Task Task { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Department CurrentDepartment { get; set; }
    }
}  