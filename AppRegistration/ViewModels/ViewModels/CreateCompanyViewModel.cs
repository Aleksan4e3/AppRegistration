using System.ComponentModel.DataAnnotations;
using EntityModels.Enums;

namespace ViewModels.ViewModels
{
    public class CreateCompanyViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public LegalForm LegalForm { get; set; }
    }
}
