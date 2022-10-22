using System.Linq.Expressions;
using EFAPIDAY2.DTOs.Categories;
using EFAPIDAY2.Models;
using EFAPIDAY2.Repositories;

namespace EFAPIDAY2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public CreateCategoryResponse? CreateCategory(CreateCategory createCategory)
        {
            using (var transaction = _categoryRepo.DatabaseTransaction())
            {
                try
                {
                    var _createCategory = new Category
                    {
                        CategoryName = createCategory.CategoryName
                    };

                    var newCategory = _categoryRepo.Create(_createCategory);
                    _categoryRepo.SaveChanges();

                    transaction.Commit();

                    return new CreateCategoryResponse
                    {
                        Id = newCategory.Id,
                        CategoryName = newCategory.CategoryName,
                    };
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }

        public IEnumerable<CreateCategoryResponse> GetAll()
        {
            var viewModels = _categoryRepo.GetAll(x => true)
                .Select(category => new CreateCategoryResponse
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                });

            return viewModels;
        }

        public CreateCategoryResponse? Get(int id)
        {
            var category = _categoryRepo.Get(g => g.Id == id);

            if (category == null) { return null; }

            var getModels = new CreateCategoryResponse
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };

            return getModels;
        }

        public bool DeleteCategory(int id)
        {
            using (var transaction = _categoryRepo.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepo.Get(x => x.Id == id);

                    if (category != null)
                    {
                        _categoryRepo.Delete(category);
                        _categoryRepo.SaveChanges();
                    }
                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.RollBack();
                    return true;
                }
            }
        }

        public CreateCategoryResponse? UpdateCategory(int id, CreateCategory updateCategory)
        {
            using (var transaction = _categoryRepo.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepo.Get(x => x.Id == id);

                    if (category == null) { return null; }

                    category.CategoryName = updateCategory.CategoryName;

                    category = _categoryRepo.Update(category);

                    if (category == null) return null;

                    var viewModel = new Category
                    {
                        CategoryName = category.CategoryName,
                    };

                    _categoryRepo.SaveChanges();

                    transaction.Commit();

                    return new CreateCategoryResponse
                    {
                        Id = category.Id,
                        CategoryName = updateCategory.CategoryName,
                    };
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }
    }
}