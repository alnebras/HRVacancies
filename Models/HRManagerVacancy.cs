using System.ComponentModel.DataAnnotations;

namespace HRVacancies.Models
{
    public class HRManagerVacancy: BaseAuditableEntity
    {
        [Key]
        public int VacancyId { get; set; }

        [Required(ErrorMessage="الرجاء إدخال عنوان الوظيفة")]
        public string VacancyTitle { get; set; }
        public string? VacancyDescription { get; set; }
        public string UserId { get; set; }
    }
}
