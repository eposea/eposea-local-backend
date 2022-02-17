using EposeaLocalBackend.Core.Interfaces.Repositories;
using EposeaLocalBackend.Data.Models;
using EposeaLocalBackend.gRPC.Proto.Section;

namespace EposeaLocalBackend.Data.Repository.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
