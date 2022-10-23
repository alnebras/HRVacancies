using HRVacancies.Models;

namespace HRVacancies.Dtos
{
    public class HRRequisitionDto
    {
        public int RequisitionId { get; set; }

        public string RequisitionName { get; set; }

        public int VacancyId { get; set; }

        public string VacancyName { get; set; }

        public List<HRRequisition> hRRequisitionsList { get; set; }

        public List<HRManagerVacancyDto> VacanciesList { get; set; }

        public HRRequisitionVM  requisitionVM { get; set; }
    }
}
