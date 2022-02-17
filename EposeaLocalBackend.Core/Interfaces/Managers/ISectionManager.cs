using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using EposeaLocalBackend.gRPC.Proto.Section;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Core.Interfaces.Managers
{
    public interface ISectionManager : ITransientService
    {

        public Task<Section> CreateSectionAsync(Section item);
        public Section GetSection(SectionFilter filter);
        public Task<Section> UpdateSectionAsync(Section item);
        public Task DeleteSectionAsync(SectionFilter filter);

    }
}
