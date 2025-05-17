using System.ComponentModel.DataAnnotations;
using System.Configuration;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Логин обязателен.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Логин должен быть от 3 до 50 символов.")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Пароль обязателен.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Пароль должен быть от 5 до 100 символов.")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Дата регистрации обязательна.")]
    public DateOnly RegistrationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Required(ErrorMessage = "ФИО обязательно.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "ФИО должно быть от 2 до 100 символов.")]
    [RegexStringValidator(@"^[а-яА-Яa-zA-Z\s-]+$")]
    public string FullName { get; set; }
    [Required(ErrorMessage = "Номер телефона обязателен.")]
    [RegexStringValidator(@"^\+7\d{10}$")]
    public string PhoneNumber { get; set; }
}
