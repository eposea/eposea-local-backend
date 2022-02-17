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
        public override Task<Item> CreateItem(Item request, ServerCallContext context)
        {
            return itemManager.CreateItemAsync(request);
        }
        public override Task<Item> GetItem(ItemFilter request, ServerCallContext context)
        {
            return Task.FromResult(itemManager.GetItem(request));
        }
        public override async Task<Item> UpdateItem(Item request, ServerCallContext context)
        {
            return await itemManager.UpdateItemAsync(request);
        }
        public override async Task<Empty> RemoveItem(ItemFilter request, ServerCallContext context)
        {
            await itemManager.DeleteItemAsync(request);

            return new Empty();
        }
    }
}
