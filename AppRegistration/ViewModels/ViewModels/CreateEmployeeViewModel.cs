using System;
using EntityModels.Enums;

namespace ViewModels.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Position Position { get; set; }

        
    }
}
