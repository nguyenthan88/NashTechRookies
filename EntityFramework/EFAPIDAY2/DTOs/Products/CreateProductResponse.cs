namespace EFAPIDAY2.DTOs.Products
{
    public class CreateProductResponse
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Manufacture { get; set; }

        public int CategoryId { get; set; }
    }
}