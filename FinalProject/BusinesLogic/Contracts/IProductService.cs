using FinalProject.DomainModels;

namespace FinalProject.BusinesLogic.Contracts
{
    public interface IProductService
    {
        ProductDTO GetPrductById(int productId);
        bool AddProduct(ProductDTO product);
        bool EditProduct(ProductDTO product);
        bool DeleteProduct(int productId);
    }
}
