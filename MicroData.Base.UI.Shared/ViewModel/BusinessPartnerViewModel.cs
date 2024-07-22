using MicroData.Base.UI.Shared.Settings;
using MicroData.Common.UI.Resource;
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

        [Display(Name = "Code" , ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string? Code { get; set; }

        private string? name;
        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Name", ResourceType = typeof(CommonStrings), Order = 30)]
        public string? Name
        {
            get { return name; }
            set
            {

                if (value == null)
                    return;

                if (IsReadOnly)
                    return;


                if (BaseSettings.IsBusinessPartnerUppercase)
                    name = value.ToUpper();
                else
                    name = value;

                OnPropertyChanged(()=>  Name);

                if (!CanEdit)
                    return;

             
            }
        }



        //[Required(ErrorMessage = "Adresa je obavezno polje")]
        [Display(Name = "Address", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string Address { get; set; }

        [Display(Name = "Poštanski broj", AutoGenerateField = false)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Mesto je obavezno polje")]
        [Display(Name = "City", ResourceType = typeof(CommonStrings), Order = 50)]
        public string City { get; set; }

        [Display(Name = "State", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string State { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string Phone { get; set; }

        [Display(Name = "Email", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string Email { get; set; }

        [Display(Name = "www", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
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
        //[Required(ErrorMessage = "Matični broj je obavezno polje")]
        [Display(Name = "RegistryNumber", ResourceType = typeof(CommonStrings), Order =10, AutoGenerateField = false)]
        //[MinLength(8, ErrorMessage = "Matični broj može imati minimalno 9 karaktera")]
        //[MaxLength(15, ErrorMessage = "Matični broj može imati maksimalno 15 karaktera")]
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
        //[Required(ErrorMessage = "PIB je obavezno polje")]
        [Display(Name = "TaxNumber", ResourceType = typeof(CommonStrings), Order = 10)]
        //[MinLength(9, ErrorMessage = "PIB može imati minimalno 9 karaktera")]
        //[MaxLength(15, ErrorMessage = "PIB može imati maksimalno 15 karaktera")]
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
        [Display(Name = "JBKJS", Order = 60, AutoGenerateField = false)]
        //[MinLength(0, ErrorMessage = "JBKJS sadrži 5 karaktera")]
        //[MaxLength(5, ErrorMessage ="JBKJS sadrži 5 karaktera")]
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

        [Display(Name = "InVat", ResourceType = typeof(CommonStrings), Order = 80, AutoGenerateField = false)]
        public bool InVat { get; set; }

        private bool inSEF;
        [Display(Name = "Registrovan na SEF", Order = 70, AutoGenerateField = false)]
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

        [Display(Name = "IsActive", ResourceType = typeof(CommonStrings), Order = 110)]
        public bool? IsActive { get; set; }


    }
}
