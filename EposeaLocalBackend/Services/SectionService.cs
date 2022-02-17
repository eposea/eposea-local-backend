using EposeaLocalBackend.Core.Interfaces.Managers;
using EposeaLocalBackend.gRPC.Proto.Section;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;

namespace EposeaLocalBackend
{
    public class SectionService : gRPC.Proto.Section.SectionService.SectionServiceBase
    {
        private readonly ISectionManager sectionManager;
        public SectionService(ISectionManager sectionManager)
        {
            this.sectionManager = sectionManager;
        }
        public override Task<Section> CreateSection(Section request, ServerCallContext context)
        {
            return sectionManager.CreateSectionAsync(request);
        }
        public override Task<Section> GetSection(SectionFilter request, ServerCallContext context)
        {
            return Task.FromResult(sectionManager.GetSection(request));
        }
        public override async Task<Section> UpdateSection(Section request, ServerCallContext context)
        {
            return await sectionManager.UpdateSectionAsync(request);
        }
        public override async Task<Empty> RemoveSection(SectionFilter request, ServerCallContext context)
        {
            await sectionManager.DeleteSectionAsync(request);

            return new Empty();
        }
    }
}
