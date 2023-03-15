using DanceSchoolAPI.Common.Models.Lesson;
using DanceSchoolAPI.Common.Models.Teacher;
using DanceSchoolAPI.Infrastructure.Repositories.MSSQL;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Services;

public class TeacherService : ITeacherService
{
    private IMSSQLRepository<Teacher> teacherRepository;

    public TeacherService(
        IMSSQLRepository<Teacher> teacherRepository)
    {
        this.teacherRepository = teacherRepository;
    }

    public async Task<long> CreateAsync(Teacher data)
        => await teacherRepository.InsertAsync(data);

    public async Task<Teacher> GetAsync(long id)
        => await teacherRepository.GetAsync(id);

    public async Task<IEnumerable<Teacher>> BrowseAsync()
        => await teacherRepository.SelectAsync();

    public async Task<Teacher> UpdateAsync(Teacher data)
        => await teacherRepository.UpdateAsync(data, 0);

    public async Task DeleteAsync(long id)
        => await teacherRepository.DeleteAsync(id);
}
