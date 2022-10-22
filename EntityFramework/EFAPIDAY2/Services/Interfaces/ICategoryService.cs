using EFAPIDAY2.DTOs.Categories;
using System.Linq.Expressions;

namespace EFAPIDAY2.Services
{
    public interface ICategoryService
    {
        IEnumerable<CreateCategoryResponse> GetAll();

        CreateCategoryResponse? Get(int id);

        CreateCategoryResponse? CreateCategory(CreateCategory createCategory);

        CreateCategoryResponse? UpdateCategory(int id, CreateCategory createCategory);

        bool DeleteCategory(int id);
    }
}