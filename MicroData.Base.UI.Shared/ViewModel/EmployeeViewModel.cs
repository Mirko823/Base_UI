using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class EmployeeViewModel : BaseAuditViewModel<Guid>
    {
        [Display(AutoGenerateField = false, Name = "Firma")]
        public Guid TenantId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false, Name = "Eksport key")]
        public int? ExportId { get; set; }

        [Required(ErrorMessage = "Šifra je obavezno polje")]
        [Display(Name = "Šifra", Order =10)]
        public string Code { get; set; }

        [Display(Name = "Titula", Order = 19)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje")]
        [Display(Name = "Prezime", Order = 20)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Ime je obavezno polje")]
        [Display(Name = "Ime", Order = 30)]
        public string FirstName { get; set; }

        [Display(Name = "Imenovanje", Order = 40)]
        public string Designation { get; set; }

        [Display(Name = "Telefon", Order = 40)]
        public string Phone { get; set; }

        [Display(Name = "Adresa", Order = 50)]
        public string Address { get; set; }

        [Display(Name = "Mesto", Order = 60)]
        public string City { get; set; }


        [Display(Name = "Aktivan", Order = 70)]
        public bool IsActive { get; set; }

        [Display(Name = "Slika", Order = 200)]
        public byte[] Picture { get; set; }

        [Display(Name = "Napomena", Order = 210)]
        public string Note { get; set; }


    }
}
