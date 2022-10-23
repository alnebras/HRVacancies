namespace HRVacancies.Dtos
{
    public class HRRequisitionVM
    {
        public int RequisitionId { get; set; }

        public string RequisitionName { get; set; }

        public int VacancyId { get; set; }

        public string VacancyName { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }

}
