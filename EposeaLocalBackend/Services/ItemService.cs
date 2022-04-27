using EposeaLocalBackend.Core.Interfaces.Managers;
using EposeaLocalBackend.gRPC.Proto.Item;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;

namespace EposeaLocalBackend
{
    public class ItemService : gRPC.Proto.Item.ItemService.ItemServiceBase
    {
        private readonly IItemManager itemManager;
        public ItemService(IItemManager itemManager)
        {
            this.itemManager = itemManager;
        }

        public override Task<Item> GetItem(GetItemRequest request, ServerCallContext context)
        {
            return Task.FromResult(itemManager.GetItem(request));
        }
      
    }
}
