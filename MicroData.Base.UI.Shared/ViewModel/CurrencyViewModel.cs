using MicroData.Common.UI.Shared.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class CurrencyViewModel : BaseViewModel<int>
    {
        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Naziv")]
        public string Label { get; set; }

        [Required(ErrorMessage = "Oznaka je obavezno polje")]
        [Display(Name = "Oznaka")]
        public string Name { get; set; }

        [Display(Name = "Ino Naziv")]
        public string NameEn { get; set; }


        [Required(ErrorMessage = "Država je obavezno polje")]
        [Display(Name = "Država")]
        public string State { get; set; }

        [Required(ErrorMessage = "Jedinica je obavezno polje")]
        [Display(Name = "Jedinica")]
        public short Unit { get; set; }

        [Display(Name = "RSD")]
        public bool IsDefault { get; set; }

      
    }
}
