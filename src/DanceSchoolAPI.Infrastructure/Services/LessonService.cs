using DanceSchoolAPI.Common.Models.Lesson;
using DanceSchoolAPI.Infrastructure.Repositories.MSSQL;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Services;

public class LessonService : ILessonService
{
    private IMSSQLRepository<Lesson> lessonRepository;

    public LessonService(
        IMSSQLRepository<Lesson> lessonRepository)
    {
        this.lessonRepository = lessonRepository;
    }

    public async Task<long> CreateAsync(Lesson lessonData)
        => await lessonRepository.InsertAsync(lessonData);

    public async Task<Lesson> GetAsync(long id)
        => await lessonRepository.GetAsync(id);

    public async Task<IEnumerable<Lesson>> BrowseAsync()
        => await lessonRepository.SelectAsync();

    public async Task<Lesson> UpdateAsync(Lesson lessonData)
        => await lessonRepository.UpdateAsync(lessonData, 0);

    public async Task DeleteAsync(long id)
        => await lessonRepository.DeleteAsync(id);
}
