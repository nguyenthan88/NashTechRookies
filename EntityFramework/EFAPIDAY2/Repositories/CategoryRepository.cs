using EFAPIDAY2.Data;
using EFAPIDAY2.Models;

namespace EFAPIDAY2.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductContext context) : base(context)
        {
        }
    }
}