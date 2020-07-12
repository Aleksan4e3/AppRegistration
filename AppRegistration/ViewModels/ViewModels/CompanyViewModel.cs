using System;
using System.ComponentModel.DataAnnotations;
using EntityModels.Enums;

namespace ViewModels.ViewModels
{
    public class CompanyViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required, Display(Name = "Company")]
        public string Name { get; set; }

        [Required, Display(Name = "Legal form")]
        public LegalForm LegalForm { get; set; }
    }
}
