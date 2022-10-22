using EFAPIDAY2.Data;
using EFAPIDAY2.Models;
using EFAPIDAY2.Repositories;
namespace EFAPIDAY2.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}