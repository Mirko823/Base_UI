using MicroData.Base.UI.Shared.ViewModel;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using MicroData.Base.UI.Shared.Interface;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Blazor.Pages.Unit
{
    public partial class UnitEdit
    {
        
        [Parameter]
        public UnitViewModel unit { get; set; }

        [Parameter]
        public string unitId { get; set; }

        [Inject]
        public IUnitApi _unitApi { get; set; }

        protected override async Task OnInitializedAsync()
        {

            if (unitId == "new")
            {
                unit = new UnitViewModel
                {
                    Code = string.Empty,
                    Label = string.Empty,
                    Name = string.Empty,
                    IsActive = true,
                    IsNew = true
                };
            }
            else
            {

                var currentUnitId = Convert.ToInt32(unitId);
                var result = _unitApi.Get(currentUnitId, string.Empty);
                unit = result;
                unit.IsNew = false;

                // Ovdje možete učitati postojeći UnitViewModel iz baze podataka prema unitId
                // unit = await LoadUnit(unitId);
            }


        }

       


        private async Task SaveUnit()
        {
            unit.ClearAllErrors();
            unit.Validate();

            if (unit.HasErrors)
            {
                //todo
                return;
            }

            

                // Ovdje dodajte logiku za spremanje podataka u bazu
                // Trenutno samo vraća na UnitList stranicu
                //Uraditi validaciju
                //Ispravne podatke sacuvati u bazi

                UnitViewModel result;

            if (unit.IsNew)
                result = _unitApi.CreateNew(unit, string.Empty);
            else
                result = _unitApi.EditExisting(unit, string.Empty);
 
            //Proveriti rezultat i prikazati ako postoji greska

            if (result.HasErrors)
            {
                string prvagreska = result.GetFirstOrDefaultError();

               var allErrors = result.GetAllErrors();
            }

            //Console.WriteLine("SaveUnit method called.");
            
            NavigationManager.NavigateTo("/unitlist");

            
        }

    
        public void Cancel()
        {
            NavigationManager.NavigateTo("/unitlist");
            Console.WriteLine("Cancel back to unitlist");
        }


        string FormValidationState;

        void HandleValidSubmit()
        {
            FormValidationState = @"Form data is valid";
        }

        void HandleInvalidSubmit()
        {
            FormValidationState = unit.GetFirstOrDefaultError();
        }


        private string message = "Pozdrav iz roditeljske komponente!";

        private void HandleButtonClick(string newText)
        {
            message = newText;
        }


    }
}