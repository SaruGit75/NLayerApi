namespace NLayerApi.Core.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; } //navigation property*

    }
}
//Referans tipli prop.'ların altlari cizilidir(nullable)(string ve sinif tipleri)