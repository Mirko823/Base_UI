using System;

namespace MicroData.Base.UI.Shared.Lookup
{
    public class BusinessPartnerViewLookup
    {
        public Guid Id { get; set; }
        public string? RegistryNumber { get; set; }
        public string? TaxNumber { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? JBKJS { get; set; }
        public string? FullAddress { get; set; }
        public bool InVat { get; set; }
    }
}
