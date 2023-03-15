using DanceSchoolAPI.Common.Models.Lesson;

namespace DanceSchoolAPI.Infrastructure.Services.Interfaces;
public interface ILessonService
{
    Task<IEnumerable<Lesson>> BrowseAsync();
    Task<long> CreateAsync(Lesson lessonData);
    Task DeleteAsync(long id);
    Task<Lesson> GetAsync(long id);
    Task<Lesson> UpdateAsync(Lesson lessonData);
}