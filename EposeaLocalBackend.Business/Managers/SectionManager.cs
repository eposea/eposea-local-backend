using AutoMapper;
using EposeaLocalBackend.Core.Interfaces.Managers;
using EposeaLocalBackend.Core.Interfaces.Repositories;
using EposeaLocalBackend.gRPC.Proto.Section;
using System.Linq;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Business.Managers
{
    public class SectionManager : ISectionManager
    {
        private readonly ISectionRepository sectionRepository;
        private readonly IMapper mapper;
        public SectionManager(ISectionRepository sectionRepository, IMapper mapper)
        {
            this.sectionRepository = sectionRepository;
            this.mapper = mapper;
        }


        public async Task<Section> CreateSectionAsync(Section course)
        {
            var result = await sectionRepository.AddAsync(course);

            return result;
        }

        public Section GetSection(SectionFilter filter)
        {
            var courses = sectionRepository.GetAll();
            return courses.FirstOrDefault(course => course.Id == filter.Id);
        }


        public async Task DeleteSectionAsync(SectionFilter filter)
        {
            var courseToDelete = GetSection(filter);

            await sectionRepository.DeleteAsync(courseToDelete);
        }


        public async Task<Section> UpdateSectionAsync(Section course)
        {
            var result = await sectionRepository.UpdateAsync(course);

            return result;
        }
    }
}
