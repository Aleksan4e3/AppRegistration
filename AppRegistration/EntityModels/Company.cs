using System;
using System.Collections.Generic;
using EntityModels.Enums;

namespace EntityModels
{
    public class Company : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LegalForm LegalForm { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
