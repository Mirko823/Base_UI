using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class TaxViewModel : BaseViewModel<int>
    {
        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Naziv")]
        public string Name { get; set; }

        [Display(Name = "Tip")]
        public short Type { get; set; }

        [Display(Name = "Oznaka na kasi")]
        public string Label { get; set; }

        [Required(ErrorMessage = "Stopa je obavezno polje")]
        [Display(Name = "Stopa Poreza")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Koeficient je obavezno polje")]
        [Display(Name = "Koeficient Poreza")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N6}")]
        public decimal Coefficient { get; set; }

        [Display(Name = "U PDV-u")]
        public bool InVat { get; set; }

        [Display(Name = "Datum početka primene", AutoGenerateField = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Kraj primene", AutoGenerateField = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Aktivan")]
        public bool IsActive { get; set; }

    }
}
