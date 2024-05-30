using MicroData.Common.UI.Shared.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class CityViewModel : BaseViewModel<int>
    {
        [Display(Name = "Poštanski broj")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Naziv")]
        public string Name { get; set; }
    }
}
