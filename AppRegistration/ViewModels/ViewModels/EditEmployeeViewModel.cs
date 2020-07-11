using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EntityModels.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModels.ViewModels
{
    public class EditEmployeeViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        public DateTime EmploymentDate { get; set; }

        public Position? Position { get; set; }

        [Display(Name = "Company")]
        public Guid? CompanyId { get; set; }
        public List<SelectListItem> Companies { get; set; }
    }
}
