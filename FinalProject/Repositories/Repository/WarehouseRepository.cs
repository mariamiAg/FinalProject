using FinalProject.DataAccess;
using FinalProject.Repositories.Interfaces;

namespace FinalProject.Repositories.Repository
{
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(WebTry2Context context) : base(context)
        {
        }
    }
}
