using System;
using System.ComponentModel.DataAnnotations;
using EntityModels.Enums;

namespace ViewModels.ViewModels
{
    public class CompanyViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public LegalForm LegalForm { get; set; }
    }
}
