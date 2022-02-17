using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using EposeaLocalBackend.gRPC.Proto.Item;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Core.Interfaces.Managers
{

    public interface IItemManager : ITransientService
    {

        public Task<Item> CreateItemAsync(Item item);
        public Item GetItem(ItemFilter filter);
        public Task<Item> UpdateItemAsync(Item item);
        public Task DeleteItemAsync(ItemFilter filter);


    }
}
