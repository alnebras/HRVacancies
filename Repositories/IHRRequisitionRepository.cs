using HRVacancies.Dtos;
using HRVacancies.Models;

namespace HRVacancies.Repositories
{
    public interface IHRRequisitionRepository
    {
        Task<BaseResponse> AddHRRequisition(HRRequisition model);

        Task<List<HRRequisition>> GetHRRequisitions();

        HRRequisitionDto GetHRRequisitionById(int id);

        Task<BaseResponse> EditHRRequisition(HRRequisitionVM model);
        Task<List<HRManagerVacancyDto>> GetHRVacancies();
    }
}
