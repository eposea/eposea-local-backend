using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using EposeaLocalBackend.gRPC.Proto.Item;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Core.Interfaces.Managers
{

    public interface IItemManager : ITransientService
    {
        public Item GetItem(GetItemRequest request);
    }
}
