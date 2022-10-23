using System.ComponentModel.DataAnnotations;

namespace HRVacancies.Models
{
    public class VacancyCadidate:BaseAuditableEntity
    {
        [Key]
        public int VacancyCadidateId { get; set; }

        [Required]
        public int RequisitionId { get; set; }

        [Required(ErrorMessage ="الرجاء إدخال إسم المرشح")]
        public string CadidateName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoenNumber { get; set; }

        [Required(ErrorMessage ="الرجاء إضافة السيرة الذاتية")]
        public string CVPath { get; set; }

        public bool ManagerApprive { get; set; }

        public bool DirectorApprove { get; set; }

        public int UserId { get; set; }
    }
}
