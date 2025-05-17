using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class Inventory : INotifyPropertyChanged
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Название инвентаря обязательно.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов.")]
    private string _name;
    public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }

    [Required(ErrorMessage = "Тип инвентаря обязателен.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Тип должен быть от 2 до 100 символов.")]
    private string _type;
    public string Type { get => _type; set { _type = value; OnPropertyChanged(); } }
    [Required(ErrorMessage = "Описание инвентаря обязательно.")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Описание должно быть от 10 до 500 символов.")]
    private string _description;
    public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }
    [Required(ErrorMessage = "Дата выпуска обязательна.")]
    private DateOnly _releaseDate { get; set; }
    public DateOnly ReleaseDate { get => _releaseDate; set { _releaseDate = value; OnPropertyChanged(); } }
    [Required(ErrorMessage = "Статус инвентаря обязателен.")]
    private InventoryStatus _status { get; set; }
    public InventoryStatus Status { get => _status; set { _status = value; OnPropertyChanged(); } }
    private User? _user { get; set; }
    public User? User { get => _user; set { _user = value; OnPropertyChanged(); } }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}