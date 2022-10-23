using HRVacancies.Dtos;
using HRVacancies.Models;

namespace HRVacancies.Repositories
{
    public interface ICandidateRepository
    {
        Task<List<CandidateVM>> GetCandidates();

        Task<List<CandidateVM>> GetCandidatesByRequisitionId(string requisitionId);

        Task<List<HRManagerVacancyDto>> GetHRVacancies();

        Task<List<HRRequisition>> GetHRRequisitions();


        Task<BaseResponse> AddCandidate(CandidatesDto model);

    }
}
