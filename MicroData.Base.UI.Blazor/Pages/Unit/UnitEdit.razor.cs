using MicroData.Base.UI.Shared.ViewModel;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Blazor.Pages.Unit
{
    public partial class UnitEdit
    {
        [Parameter]
        public string IdS { get; set; }

        private UnitViewModel unit = new UnitViewModel();

       

        protected override async Task OnInitializedAsync()
        {
            // Ovdje simuliramo dohvaćanje jedinice prema kodu
            unit = new UnitViewModel
            {
                Code = "nesto",
                Label = "Sample Label",
                Name = "Sample Name",
                IsActive = true
            };
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

        }
    }
}