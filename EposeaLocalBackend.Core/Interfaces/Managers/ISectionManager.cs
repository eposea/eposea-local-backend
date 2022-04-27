using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using EposeaLocalBackend.gRPC.Proto.Section;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Core.Interfaces.Managers
{
    public interface ISectionManager : ITransientService
    {
        public Section GetSection(GetSectionRequest request);
    }
}
