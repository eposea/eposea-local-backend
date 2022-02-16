using AutoMapper;
using EposeaLocalBackend.Core.Interfaces.Managers;
using EposeaLocalBackend.Core.Interfaces.Repositories;
using EposeaLocalBackend.gRPC.Proto.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Item> AddAsync(Item entity)
        {
            var result = await itemRepository.AddAsync(entity);

            return result;
        }

        public Item GetItem(GetItemRequest request)
        {
            return itemRepository.GetAll().FirstOrDefault(item => item.Id == request.Id);
        }

        public Item Update(Item entity)
        {
            return null;
        }
    }
}
