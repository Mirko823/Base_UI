using System;

namespace MicroData.Base.UI.Shared.Lookup
{
    public  class ShipperViewLookup 
    {
        public Guid Id { get; set; }
        public string? RegistryNumber { get; set; }
        public string? TaxNumber { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }      
        public string? FullAddress { get; set; }
    }
}
