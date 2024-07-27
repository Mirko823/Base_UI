using MicroData.Base.UI.Shared.Api;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Shared.Identity;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Blazor.Pages.GrainCatalog
{
    public partial class GrainCatalogEdit
    {

        [Parameter]
        public GrainCatalogViewModel grain { get; set; }

        [Parameter]
        public string grainId { get; set; }

        [Inject]
        public IGrainCatalogApi _grainCatalogApi { get; set; }

        //[Inject]
        //public ILookupBaseApi _lookupBaseApi { get; set; }
        protected override async Task OnInitializedAsync()
        {

            if (grainId == "new")
            {
                grain = new GrainCatalogViewModel
                {
                    Code = string.Empty,
                    BarCode = string.Empty,
                    Name = string.Empty,
                    Unit = string.Empty,
                    UnitId = 1,
                    TaxId = 1,
                    TaxLabel = string.Empty,
                    CatalogCategory = string.Empty,
                    IsNew = true
                };

                grain.Id = Guid.NewGuid();
                grain.TenantId = Guid.NewGuid(); 
                grain.CompanyId = Guid.NewGuid();

                grain.IsReadOnly = false;

                grain.CreatedBy = CurrentUser.UserName;
                grain.UpdatedBy = CurrentUser.UserName;

                grain.CreatedTime = DateTime.Now;
                grain.UpdatedTime = DateTime.Now;

            }
            else
            {

          

                // Ovdje možete učitati postojeći UnitViewModel iz baze podataka prema unitId
                // unit = await LoadUnit(unitId);
            }


        }


        private async Task SaveUnit()
        {
            grain.ClearAllErrors();
            grain.Validate();

            if (grain.HasErrors)
            {
                //todo
                return;
            }



            // Ovdje dodajte logiku za spremanje podataka u bazu
            // Trenutno samo vraća na UnitList stranicu
            //Uraditi validaciju
            //Ispravne podatke sacuvati u bazi

            GrainCatalogViewModel result;

            if (grain.IsNew)
                result = _grainCatalogApi.CreateNew(grain, string.Empty);
            else
                result = _grainCatalogApi.EditExisting(grain, string.Empty);

            //Proveriti rezultat i prikazati ako postoji greska

            if (result.HasErrors)
            {
                string prvagreska = result.GetFirstOrDefaultError();

                var allErrors = result.GetAllErrors();
            }

            //Console.WriteLine("SaveUnit method called.");

            NavigationManager.NavigateTo("/graincataloglist");


        }


        string FormValidationState;

        void HandleValidSubmit()
        {
            FormValidationState = @"Form data is valid";
        }

        void HandleInvalidSubmit()
        {
            FormValidationState = grain.GetFirstOrDefaultError();
        }


    }
}
