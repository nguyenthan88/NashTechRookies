using System.Linq.Expressions;
using EFAPIDAY2.DTOs.Products;

namespace EFAPIDAY2.Services
{
    public interface IProductService
    {
        IEnumerable<CreateProductResponse> GetAll();

        CreateProductResponse? Get(int id);

        CreateProductResponse? CreateProduct(CreateProduct createProduct);

        CreateProductResponse? UpdateProduct(int id, CreateProduct updateProduct);

        bool DeleteProduct(int id);
    }
}