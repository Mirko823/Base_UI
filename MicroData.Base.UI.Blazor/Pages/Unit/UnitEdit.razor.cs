using MicroData.Base.UI.Shared.ViewModel;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;

namespace MicroData.Base.UI.Blazor.Pages.Unit
{
    public partial class UnitEdit
    {
        
        [Parameter]
        public UnitViewModel unit { get; set; }

        [Parameter]
        public string unitId { get; set; }

        protected override async Task OnInitializedAsync()
        {

            if (unitId == "new")
            {
                unit = new UnitViewModel
                {
                    Code = string.Empty,
                    Label = string.Empty,
                    Name = string.Empty,
                    IsActive = true
                };
            }
            else
            {
                // Ovdje možete učitati postojeći UnitViewModel iz baze podataka prema unitId
                // unit = await LoadUnit(unitId);
            }


        }

       


        private async Task SaveUnit()
        {
            // Ovdje dodajte logiku za spremanje podataka u bazu
            // Trenutno samo vraća na UnitList stranicu
            Console.WriteLine("SaveUnit method called.");
            NavigationManager.NavigateTo("/unitlist");
        }

    
        public void Cancel()
        {
            NavigationManager.NavigateTo("/unitlist");
            Console.WriteLine("Cancel back to unitlist");
        }

        private string message = "Poruka pre klika";

        private void ChangeText()
        {
            message = "Dugme je kliknuto!";
        }

    }
}