using System.ComponentModel.DataAnnotations;
using EntityModels.Enums;

namespace ViewModels.ViewModels
{
    public class CreateCompanyViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required, Display(Name = "Legal form")]
        public LegalForm LegalForm { get; set; }
    }
}
