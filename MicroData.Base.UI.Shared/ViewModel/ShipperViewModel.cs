using MicroData.Base.UI.Resource;
using MicroData.Base.UI.Shared.Settings;
using MicroData.Common.UI.Resource;
using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public partial class ShipperViewModel : BaseAuditViewModel<Guid>
    {
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }
        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }
        [Display(AutoGenerateField = false)]
        public int? ExportId { get; set; }

        [Display(Name = "Code", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string? Code { get; set; }


        public string? name;
        [Required]
        [Display(Name = "Name", ResourceType = typeof(CommonStrings), Order = 30)]
        public string? Name
        {
            get { return name; }
            set
            {

                if (BaseSettings.IsShipperUppercase)
                    name = value.ToUpper();
                else
                    name = value;

                OnPropertyChanged(() => Name);
            }
        }

        [Display(Name = "Address", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string? Address { get; set; }

        [Display(Name = "Poštanski broj", AutoGenerateField = false)]
        public string? PostalCode { get; set; }

        [Required]
        [Display(Name = "City", ResourceType = typeof(CommonStrings), Order = 50)]
        public string City { get; set; } = null!;

        [Display(Name = "State", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string? State { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string? Phone { get; set; }

        [Display(Name = "Email", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string? Email { get; set; }

        [Display(Name = "www", ResourceType = typeof(CommonStrings), AutoGenerateField = false)]
        public string? Www { get; set; }

        [Display(Name = "RegistryNumber", ResourceType = typeof(CommonStrings), Order = 10, AutoGenerateField = false)]
        public string RegistryNumber { get; set; } = null!;

        [Display(Name = "TaxNumber", ResourceType = typeof(CommonStrings), Order = 10)]
        public string TaxNumber { get; set; } = null!;

        [Display(AutoGenerateField = false)]
        public string? Note { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(CommonStrings), Order = 110)]
        public bool IsActive { get; set; }
    }
}
