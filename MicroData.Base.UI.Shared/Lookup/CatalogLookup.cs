using MicroData.Base.UI.Shared.Enum;
using System;

namespace MicroData.Base.UI.Shared.Lookup
{
    public  class CatalogLookup 
    {
        public Guid Id { get; set; }
        public Guid CatalogCategoryId { get; set; }
        public string? CatalogCategory { get; set; }
        public CatalogType Type { get; set; }
        public string? Code { get; set; }
        public string? BarCode { get; set; }
        public string? Name { get; set; }
        public int UnitId { get; set; }
        public string? Unit { get; set; }
        public string? TaxLabel { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
    }
}
