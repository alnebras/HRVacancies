using HRVacancies.Dtos;
using HRVacancies.Models;

namespace HRVacancies.Repositories
{
    public interface IHRVacancyRepository
    {
        Task<BaseResponse> AddHRVacancy(HRManagerVacancy model);

        Task<List<HRManagerVacancy>> GetHRVacancies();

        Task<HRManagerVacancy> GetHRVacancyById(int id);

        Task<BaseResponse> EditHRVacancy(HRManagerVacancy model);

    }
}
