using System;

namespace MicroData.Base.UI.Shared.Lookup
{
    public class ClientLookup
    {
        public Guid Id { get; set; }
        public string? ExportStr { get; set; }
        public string? Code { get; set; }
        public string? JMBG { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? FullName { get; set; }
        public string? DateOfBorn { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Email { get; set; }
    }
}
