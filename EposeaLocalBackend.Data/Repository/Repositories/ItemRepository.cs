using EposeaLocalBackend.Core.Interfaces.Repositories;
using EposeaLocalBackend.Data.Models;
using EposeaLocalBackend.gRPC.Proto.Item;
using Microsoft.Extensions.Logging;

namespace EposeaLocalBackend.Data.Repository.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationContext applicationContext, ILogger<ItemRepository> logger) : base(applicationContext, logger)
        {
        }
    }
}
