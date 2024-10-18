using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public class ConsultationRequest
    {
        [Required(ErrorMessage = "Ім'я та прізвище обов'язкові")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email обов'язковий")]
        [EmailAddress(ErrorMessage = "Невірний формат Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Оберіть бажану дату")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Дата має бути в майбутньому та не попадати на вихідні")]
        public DateTime DesiredDate { get; set; }

        [Required(ErrorMessage = "Оберіть продукт для консультації")]
        public string Product { get; set; }
    }

}
