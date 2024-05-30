using System;

namespace MicroData.Base.UI.Shared.Lookup
{
    public  class ClientSmallLookup 
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? FullName { get; set; }
        public string? DateOfBorn { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Phone1 { get; set; }
    }
}
