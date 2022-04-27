using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using EposeaLocalBackend.gRPC.Proto.Section;

namespace EposeaLocalBackend.Core.Interfaces.Repositories
{
    public interface ISectionRepository : ITransientService, IRepository<Section>
    {
    }
}
