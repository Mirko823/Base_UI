using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public class BusinessPartnerViewModel : BaseAuditViewModel<Guid>
    {      
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false)]
        public string? ExportId { get; set; }

        [Display(Name = "Šifra", AutoGenerateField = false)]
        public string? Code { get; set; }

        private string? name;
        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Naziv", Order = 30)]
        public string? Name
        {
            get { return name; }
            set
            {

                if (value == null)
                    return;

                if (IsReadOnly)
                    return;

                SetField(ref name, value, () => Name);

                if (!CanEdit)
                    return;

             
            }
        }

        [Required(ErrorMessage = "Adresa je obavezno polje")]
        [Display(Name = "Adresa", AutoGenerateField = false)]
        public string Address { get; set; }

        [Display(Name = "Poštanski broj", AutoGenerateField = false)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Mesto je obavezno polje")]
        [Display(Name = "Mesto",Order = 50)]
        public string City { get; set; }

        [Display(Name = "Država", AutoGenerateField = false)]
        public string State { get; set; }

        [Display(Name = "Telefon", AutoGenerateField = false)]
        public string Phone { get; set; }

        [Display(Name = "Email", AutoGenerateField = false)]
        public string Email { get; set; }

        [Display(Name = "www ", AutoGenerateField = false)]
        public string Www { get; set; }

        public string activityCode;
        [Display(Name = "Šifra delatnosti", AutoGenerateField = false)]
        public string ActivityCode
        {
            get { return activityCode; }
            set
            {
                SetField(ref activityCode, value, () => ActivityCode);

            }
        }

        public string registryNumber;
        [Required(ErrorMessage = "Matični broj je obavezno polje")]
        [Display(Name = "Matični broj", Order =10)]
        [MinLength(8, ErrorMessage = "Matični broj može imati minimalno 9 karaktera")]
        [MaxLength(15, ErrorMessage = "Matični broj može imati maksimalno 15 karaktera")]
        public string RegistryNumber 
        {
            get { return registryNumber; }
            set
            {
                if (value == null)
                    return;

                if (IsReadOnly)
                    return;

                SetField(ref registryNumber, value, () => RegistryNumber);

                if (!CanEdit)
                    return;

              

            }
        }

        private string taxNumber;
        [Required(ErrorMessage = "PIB je obavezno polje")]
        [Display(Name = "PIB", Order = 10)]
        [MinLength(9, ErrorMessage = "PIB može imati minimalno 9 karaktera")]
        [MaxLength(15, ErrorMessage = "PIB može imati maksimalno 15 karaktera")]
        public string TaxNumber
        {
            get { return taxNumber; }
            set
            {
                if (value == null)
                    return;

                if (IsReadOnly)
                    return;

                SetField(ref taxNumber, value, () => TaxNumber);

                if (!CanEdit)
                    return;

              
            }
        }

        private string jbkjs;
        [Display(Name = "JBKJS", Order = 60)]
        [MinLength(0, ErrorMessage = "JBKJS sadrži 5 karaktera")]
        [MaxLength(5, ErrorMessage ="JBKJS sadrži 5 karaktera")]
        public string JBKJS
        {
            get { return jbkjs; }
            set
            {
                if (value == null)
                    return;

                if (IsReadOnly)
                    return;

                SetField(ref jbkjs, value, () => JBKJS);

                if (!CanEdit)
                    return;

               
            }
        }

        [Display(Name = "U sistemu PDV-a", Order = 80)]
        public bool InVat { get; set; }

        private bool inSEF;
        [Display(Name = "Registrovan na SEF", Order = 70)]
        public bool InSEF
        {
            get { return inSEF; }
            set
            {
                SetField(ref inSEF, value, () => InSEF);
            }
        }

        [Display(AutoGenerateField = false)]
        public string Note { get; set; }

        [Display(AutoGenerateField = false)]
        public bool? IsActive { get; set; }


    }
}
