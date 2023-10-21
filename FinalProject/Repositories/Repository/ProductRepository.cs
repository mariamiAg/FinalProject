using FinalProject.DataAccess;
using FinalProject.Repositories.Interfaces;

namespace FinalProject.Repositories.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WebTry2Context context) : base(context)
        {
        }
    }
}
