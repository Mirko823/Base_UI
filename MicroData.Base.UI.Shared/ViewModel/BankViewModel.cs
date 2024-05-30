using MicroData.Common.UI.Shared.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class BankViewModel : BaseViewModel<int>
    {
        [Required(ErrorMessage = "Oznaka je obavezno polje")]
        [Display(Name = "Oznaka")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Naziv")]
        public string Name { get; set; }

        [Display(Name = "Mesto")]
        public string City { get; set; }
    }
}
