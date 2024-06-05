using MicroData.Common.UI.Shared.Lookup;
using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class ClientViewModel : BaseAuditViewModel<Guid>
    {
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false)]
        public int? ExportId { get; set; }

        [Display(AutoGenerateField = false)]
        public string ExportStr { get; set; }

        private string code;
        [Display(Name = "Šifra", Order = 10)]
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
                SetField(ref code, value, () => Code);
            }
        }

        [Required(ErrorMessage = "Prezime je obavezno polje")]
        [Display(Name = "Prezime", Order = 40)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        [Display(Name = "Ime", Order = 30)]
        public string FirstName { get; set; }

        [Display(Name = "Datum rodjenja", Order = 50)]
        public virtual string DateOfBorn { get; set; }

        [Display(Name = "JMBG", Order = 55)]
        [MaxLength(13)]
        public string Jmbg { get; set; }

        [Display(Name = "Adresa", Order = 60)]
        public string Address { get; set; }

        [Display(Name = "Mesto", Order = 70)]
        public virtual string City { get; set; }

        [Display(Name = "Država", Order = 75)]
        public string State { get; set; }

        [Required(ErrorMessage = "Kontakt je obavezno polje")]
        [Display(Name = "Kontakt 1", Order = 80)]
        public string Phone1 { get; set; }

        [Display(Name = "Kontakt 2", Order = 90)]
        public string Phone2 { get; set; }

        [Display(Name = "Email", Order = 95)]
        public string Email { get; set; }

        [Display(Name = "Napomena", Order = 200)]
        public string Note { get; set; }

        [Display(AutoGenerateField = false)]
        public List<BaseIntViewLookup> AllCities { get; set; }

        [Display(AutoGenerateField = false)]
        public List<BaseIntViewLookup> AllStates { get; set; }
    }
}
