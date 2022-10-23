using System.ComponentModel.DataAnnotations;

namespace HRVacancies.Models
{
    public class HRRequisition:BaseAuditableEntity
    {
        [Key]
        public int RequisitionId { get; set; }

        [Required(ErrorMessage ="الرجاء إدحال عنوان الوظيفة")]
        public string RequisitionName { get; set; }

        public int VacancyId { get; set; }

    }
}
