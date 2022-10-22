using EFAPIDAY2.DTOs.Products;
using EFAPIDAY2.Models;
using EFAPIDAY2.Repositories;

namespace EFAPIDAY2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        private readonly ICategoryRepository _categoryRepo;

        public ProductService(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
        }
        public CreateProductResponse? CreateProduct(CreateProduct createProduct)
        {
            using (var transaction = _productRepo.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepo.Get(s => s.Id == createProduct.CategoryId);

                    if (category != null)
                    {
                        var _createProduct = new Product
                        {
                            ProductName = createProduct.ProductName,
                            CategoryId = category.Id
                        };

                        var newProduct = _productRepo.Create(_createProduct);
                        _productRepo.SaveChanges();

                        transaction.Commit();

                        return new CreateProductResponse
                        {
                            ProductId = newProduct.Id,
                            ProductName = newProduct.ProductName,
                            Manufacture = newProduct.Manufacture,
                            CategoryId = newProduct.CategoryId
                        };
                    }
                    return null;
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }

        public IEnumerable<CreateProductResponse> GetAll()
        {
            var product = _productRepo.GetAll(x => true)
                .Select(category => new CreateProductResponse
                {
                    ProductId = category.Id,
                    ProductName = category.ProductName,
                    Manufacture = category.Manufacture,
                    CategoryId = category.CategoryId
                });

            return product;
        }

        public CreateProductResponse? Get(int id)
        {
            var product = _productRepo.Get(g => g.Id == id);

            if (product != null)
            {
                var list = new CreateProductResponse
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    Manufacture = product.Manufacture,
                    CategoryId = product.CategoryId
                };

                return list;
            }
            return null;
        }

        public bool DeleteProduct(int id)
        {
            using (var transaction = _productRepo.DatabaseTransaction())
            {
                try
                {
                    var product = _productRepo.Get(x => x.Id == id);

                    if (product != null)
                    {
                        _productRepo.Delete(product);
                        _productRepo.SaveChanges();
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

        public CreateProductResponse? UpdateProduct(int id, CreateProduct updateProduct)
        {
            using (var transaction = _productRepo.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepo.Get(s => s.Id == updateProduct.CategoryId);

                    var product = _productRepo.Get(x => x.Id == id);

                    if (product == null) return null;

                    product.ProductName = updateProduct.ProductName;
                    product.CategoryId = category.Id;

                    product = _productRepo.Update(product);

                    if (product == null) return null;

                    var viewModel = new Product
                    {
                        ProductName = product.ProductName,
                        CategoryId = product.Id,
                    };

                    _productRepo.SaveChanges();

                    transaction.Commit();

                    return new CreateProductResponse
                    {
                        ProductId = product.Id,
                        ProductName = updateProduct.ProductName,
                        CategoryId = updateProduct.CategoryId
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