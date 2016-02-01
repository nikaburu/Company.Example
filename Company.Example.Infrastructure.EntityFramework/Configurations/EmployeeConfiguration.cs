using Company.Example.Core.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Company.Example.Infrastructure.EntityFramework.Configurations
{
	class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(r => r.Id);
        }
    }
}