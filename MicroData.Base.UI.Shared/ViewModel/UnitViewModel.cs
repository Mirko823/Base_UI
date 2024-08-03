using MicroData.Base.UI.Resource;
using MicroData.Common.UI.Shared.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class UnitViewModel : BaseViewModel<int>
    {
        [Required(ErrorMessageResourceType = typeof(BaseStrings), ErrorMessageResourceName = "CodeRequired")]
        [Display(Name="Šifra")]
        public string? Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(BaseStrings), ErrorMessageResourceName = "LabelRequired")]
        [Display(ResourceType = typeof(BaseStrings), Name = "LabelName", Order = 20)]
        public string? Label { get; set; }

        private string name;
        [Required(ErrorMessageResourceType = typeof(BaseStrings), ErrorMessageResourceName = "NameRequired")]
        [Display(ResourceType = typeof(BaseStrings), Name = "NameName", Order = 30)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        [Display(ResourceType = typeof(BaseStrings), Name = "IsActiveName", Order = 40)]
        public bool IsActive { get; set; }
    }
}
