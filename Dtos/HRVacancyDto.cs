using HRVacancies.Models;

namespace HRVacancies.Dtos
{
    public class HRVacancyVM
    {
        public int VacancyId { get; set; }

        public string VacancyTitle { get; set; }
        public string? VacancyDescription { get; set; }

        public List<HRManagerVacancy> HRVacanciesList { get; set; }
    }
}
