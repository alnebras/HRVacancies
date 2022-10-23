namespace HRVacancies.Dtos
{
    public class CandidateVM
    {
        public int VacancyCadidateId { get; set; }

        public string CadidateName { get; set; }

        public string Email { get; set; }

        public string PhoenNumber { get; set; }

        public string CVPath { get; set; }

        public bool ManagerApprive { get; set; }

        public bool DirectorApprove { get; set; }
    }
}
