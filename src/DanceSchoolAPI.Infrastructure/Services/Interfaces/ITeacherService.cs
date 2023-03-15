using DanceSchoolAPI.Common.Models.Lesson;
using DanceSchoolAPI.Common.Models.Teacher;

namespace DanceSchoolAPI.Infrastructure.Services.Interfaces;
public interface ITeacherService
{
    Task<IEnumerable<Teacher>> BrowseAsync();
    Task<long> CreateAsync(Teacher data);
    Task DeleteAsync(long id);
    Task<Teacher> GetAsync(long id);
    Task<Teacher> UpdateAsync(Teacher data);
}