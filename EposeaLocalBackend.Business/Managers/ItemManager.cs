using AutoMapper;
using EposeaLocalBackend.Core.Interfaces.Managers;
using EposeaLocalBackend.Core.Interfaces.Repositories;
using EposeaLocalBackend.gRPC.Proto.Item;
using System.Linq;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Business.Managers
{
    public class ItemManager : IItemManager
    {
        private readonly IItemRepository itemRepository;
        private readonly IMapper mapper;
        public ItemManager(IItemRepository itemRepository, IMapper mapper)
        {
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            var result = await itemRepository.AddAsync(item);

            return result;
        }
        public Item GetItem(ItemFilter filter)
        {
            var items = itemRepository.GetAll();
            return items.FirstOrDefault(item => item.Id == filter.Id);
        }


        public async Task DeleteItemAsync(ItemFilter filter)
        {
            var itemToDelete = GetItem(filter);

            await itemRepository.DeleteAsync(itemToDelete);
        }


        public async Task<Item> UpdateItemAsync(Item item)
        {
            var result = await itemRepository.UpdateAsync(item);

            return result;
        }
    }
}
