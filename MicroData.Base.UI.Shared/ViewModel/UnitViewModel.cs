﻿using MicroData.Common.UI.Shared.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class UnitViewModel : BaseViewModel<int>
    {
        [Required(ErrorMessage = "Sifra je obavezno polje")]
        [Display(Name = "Sifra")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Oznaka je obavezno polje")]
        [Display(Name = "Oznaka")]
        public string Label { get; set; }

        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Naziv")]
        public string Name { get; set; }

        [Display(Name = "Aktivna", AutoGenerateField = false)]
        public bool IsActive { get; set; }
    }
}
