using FinalProject.DataAccess;
using FinalProject.Repositories.Interfaces;

namespace FinalProject.Repositories.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(WebTry2Context context) : base(context)
        {
        }
    }
}
