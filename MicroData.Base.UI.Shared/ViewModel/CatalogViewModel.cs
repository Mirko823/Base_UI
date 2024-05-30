using MicroData.Base.UI.Shared.Lookup;
using MicroData.Common.UI.Shared.Lookup;
using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class CatalogViewModel : BaseAuditViewModel<Guid>
    {
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false)]
        public int? CatalogCategoryId { get; set; }

        [Display(AutoGenerateField = false)]
        public int? ExportId { get; set; }

        public int? unitId;
        [Required(ErrorMessage = "Jedinica mere je obavezno polje")]
        [Display(AutoGenerateField = false)]
        public int? UnitId
        {
            get { return unitId; }
            set {
                if (value == null)
                    return;

                if (IsReadOnly)
                    return;

                SetField(ref unitId, value.Value, () => UnitId);

                if (AllUnits == null)
                    return;

                var unit = AllUnits.FirstOrDefault(f => f.Id == value);
                if (unit != null)
                    Unit = unit.Value;
                else
                    Unit = string.Empty;

                unitId = value; 
            }
        }

        public int? taxId;
        [Required(ErrorMessage = "Poreska grupa je obavezno polje")]
        [Display(AutoGenerateField = false)]
        public int? TaxId
        {
            get { return taxId; }
            set
            {
                if (value == null)
                    return;

                if (IsReadOnly)
                    return;

                SetField(ref taxId, value.Value, () => TaxId);

                if (AllTaxes == null)
                    return;

                var tax = AllTaxes.FirstOrDefault(f => f.Id == value);
                if (tax != null)
                {
                    TaxLabel = tax.Label;
                    TaxRate = tax.Rate;
                }
                else
                {
                    TaxLabel = string.Empty;
                    TaxRate = 0;
                }

                taxId = value;
            }
        }

        [Required(ErrorMessage = "Šifra je obavezno polje")]
        [Display(Name = "Šifra", Order = 10)]
        public string Code { get; set; }

        [Display(Name = "Barkod", Order = 20)]
        public string BarCode { get; set; }

        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Naziv", Order = 30)]
        public string Name { get; set; }


        [Display(Name = "Jedinica mere", Order = 40)]
        public string Unit { get; set; }

        [Display(Name = "Poreska grupa", Order = 50)]
        public string TaxLabel { get; set; }

        private decimal taxRate;
        [Required(ErrorMessage = "Stopa je obavezno polje")]
        [ReadOnly(true)]
        [Display(Name = "Stopa Poreza", Order = 60)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal TaxRate
        {
            get { return taxRate; }
            set
            {
                SetField(ref taxRate, value, () => TaxRate);
            }
        }

        [Required(ErrorMessage = "Cena je obavezno polje")]
        //[Display(Name = "Cena")]
        [Display(Name = "Cena", Order = 100)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal Price { get; set; }

        [Display(Name = "Vrsta usluge", AutoGenerateField = false, Order = 70)]
        public string CatalogCategory { get; set; }

        [Display(AutoGenerateField = false, Name = "Vode se Zalihe")]
        public bool StockIsActive { get; set; }

        [Display(AutoGenerateField = false, Name = "Zalihe")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal Stock { get; set; }

        [Display(AutoGenerateField = false)]
        public List<BaseIntLookup> AllUnits { get; set; }

        [Display(AutoGenerateField = false)]
        public List<TaxLookup> AllTaxes { get; set; }

    }
}
