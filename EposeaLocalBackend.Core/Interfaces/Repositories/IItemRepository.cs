using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using EposeaLocalBackend.gRPC.Proto.Item;

namespace EposeaLocalBackend.Core.Interfaces.Repositories
{
    public interface IItemRepository : ITransientService, IRepository<Item>
    {
    }
}
