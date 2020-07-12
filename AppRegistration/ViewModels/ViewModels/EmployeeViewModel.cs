using System;
using System.ComponentModel.DataAnnotations;
using EntityModels.Enums;

namespace ViewModels.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        [Display(Name = "Employment date")]
        public DateTime EmploymentDate { get; set; }

        public Position? Position { get; set; }

        [Display(Name = "Company")]
        public Guid? CompanyId { get; set; }

        public CompanyViewModel Company { get; set; }
    }
}
