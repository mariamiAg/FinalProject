using FinalProject.BusinesLogic.Contracts;
using FinalProject.DataAccess;
using FinalProject.DomainModels;
using FinalProject.Repositories.Repository;

namespace FinalProject.BusinesLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public ProductDTO GetPrductById(int productId)
        {

            var product = _productRepository.Get(productId);
            var result = new ProductDTO
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Category = product.Category,
                OrderItems = product.OrderItems.ToList(),
                Warehouses = product.Warehouses.ToList()
            };
            return result;
        }



        public bool AddProduct(ProductDTO product)
        {
            try
            {
                if (product == null || product.Id.HasValue!)
                    throw new Exception("Invalid Data");

                Product productEntity = new Product
                {
                    Code = product.Code,
                    Name = product.Name,
                    Category = product.Category,
                    OrderItems = product.OrderItems.ToList(),
                    Warehouses = product.Warehouses.ToList()
                };

                _productRepository.Insert(productEntity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditProduct(ProductDTO product)
        {
            try
            {
                if (product == null || !product.Id.HasValue)
                    throw new Exception("Invalid Data");

                var productEntity = _productRepository.Get(product.Id.Value);
                productEntity.Code = product.Code;
                productEntity.Name = product.Name;
                productEntity.Category = product.Category;
                productEntity.OrderItems = product.OrderItems.ToList();
                productEntity.Warehouses = product.Warehouses.ToList();

                _productRepository.Update(productEntity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                var product = _productRepository.Get(productId);
                if (product == null)
                    throw new Exception("ERROR");

                _productRepository.Delete(product);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
