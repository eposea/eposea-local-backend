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
        public override Task<Section> GetSection(GetSectionRequest request, ServerCallContext context)
        {
            return Task.FromResult(sectionManager.GetSection(request));
        }

    }
}
