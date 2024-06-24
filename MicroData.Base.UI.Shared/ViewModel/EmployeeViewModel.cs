using MicroData.Base.UI.Resource;
using MicroData.Common.UI.Resource;
using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class EmployeeViewModel : BaseAuditViewModel<Guid>
    {
        [Required]
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }

        [Required]
        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false)]
        public int? ExportId { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(CommonStrings), Order = 10)]
        public string? Code { get; set; }

        [Display(AutoGenerateField = false)]
        public string? Title { get; set; }

        [Display(AutoGenerateField = false)]
        public string? Designation { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(BaseStrings), Order = 20)]
        public string LastName { get; set; } =string.Empty; 


        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(BaseStrings), Order = 30)]
        
        public string FirstName { get; set; } = string.Empty;


        [Display(Name = "Phone", ResourceType = typeof(CommonStrings), Order = 40)]
        public string? Phone { get; set; }

        [Display(Name = "Address", ResourceType = typeof(CommonStrings), Order = 50)]
        public string? Address { get; set; }

        [Required]
        [Display(Name = "City", ResourceType = typeof(CommonStrings), Order = 60)]
        public string? City { get; set; }


        [Display(Name = "IsActive", ResourceType = typeof(CommonStrings), Order = 70)]
        public bool IsActive { get; set; }

        [Display(Name = "Picture", ResourceType = typeof(CommonStrings), Order = 200)]
        public byte[]? Picture { get; set; }

        [Display(Name = "Note", ResourceType = typeof(BaseStrings), Order = 210)]
        public string? Note { get; set; }


    }
}
