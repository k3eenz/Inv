using System.Windows;
using System.Windows.Controls;

namespace Sport.Pages
{
    public partial class AddInventoryPage : Page
    {
        public Inventory newInventory { get; set; }

        public AddInventoryPage(Inventory inventory = null)
        {
            InitializeComponent();
            if (inventory != null)
            {
                newInventory = inventory;
                TitleTextBlock.Text = "Редактирование инвентаря";
            }
            else
            {
                newInventory = new Inventory();
                TitleTextBlock.Text = "Добавление инвентаря";
            }

            StatusComboBox.ItemsSource = Enum.GetValues<InventoryStatus>().Cast<InventoryStatus>().ToList();
            DataContext = this;
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateManager.IsNullTextBox(NameTextBox.Text, TypeTextBox.Text, DescriptionTextBox.Text, ReleaseDatePicker.SelectedDate?.ToString(), StatusComboBox.SelectedValue?.ToString())) return;
            try
            {
                await using var dbContext = new SportDbContext();

                newInventory.Name = NameTextBox.Text;
                newInventory.Description = DescriptionTextBox.Text;
                newInventory.Type = TypeTextBox.Text;
                newInventory.ReleaseDate = DateOnly.FromDateTime(ReleaseDatePicker.SelectedDate.Value);
                newInventory.Status = (InventoryStatus)StatusComboBox.SelectedItem;

                if (!ValidateManager.IsCorrectModel(newInventory)) return;

                var repository = new BaseRepository<Inventory>(dbContext);
                if (newInventory.Id == null)
                {
                    await repository.AddAsync(newInventory);
                    MessageBox.Show("Инвентарь добавлен!");
                }
                else
                {
                    await repository.UpdateAsync(newInventory);
                    MessageBox.Show("Инвентарь изменен!");
                }

                Window.GetWindow(this).DialogResult = true;
                Window.GetWindow(this).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).DialogResult = false;
            Window.GetWindow(this).Close();
        }
    }
}