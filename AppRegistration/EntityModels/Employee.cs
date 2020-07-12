using System;
using EntityModels.Enums;

namespace EntityModels
{
    public class Employee : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Position? Position { get; set; }

        public Guid? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
