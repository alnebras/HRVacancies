using HRVacancies.Models;

namespace HRVacancies.Dtos
{
    public class CandidatesDto
    {
        public int VacancyCadidateId { get; set; }

        public string CadidateName { get; set; }

        public string Email { get; set; }

        public string PhoenNumber { get; set; }

        public string CVPath { get; set; }

        public IFormFile CVFile { get; set; }

        public bool ManagerApprive { get; set; }

        public bool DirectorApprove { get; set; }

        public int VacancyId { get; set; }

        public int RequisitionId { get; set; }

        public int UserId { get; set; }

        public List<CandidateVM> CandidatesList { get; set; }

        public List<HRManagerVacancyDto> VacanciesList { get; set; }

        public List<HRRequisition> RequisitionsList { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
