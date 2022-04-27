using EposeaLocalBackend.Core.Interfaces.Repositories;
using EposeaLocalBackend.Data.Models;
using EposeaLocalBackend.gRPC.Proto.Section;
using Microsoft.Extensions.Logging;

namespace EposeaLocalBackend.Data.Repository.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(ApplicationContext applicationContext, ILogger<SectionRepository> logger) : base(applicationContext, logger)
        {
        }
    }
}
