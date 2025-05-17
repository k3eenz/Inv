using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Sport.Pages
{
    public partial class IssuePage : Page
    {
        public ObservableCollection<User> Users { get; set; }
        public Inventory currentInventory { get; set; }

        public IssuePage(Inventory inventory)
        {
            InitializeComponent();
            currentInventory = inventory;
            _ = LoadUsers();
        }

        private async Task LoadUsers()
        {
            try
            {
                await using var dbContext = new SportDbContext();
                var allUsers = await new BaseRepository<User>(dbContext).GetAllAsync();
                Users = new ObservableCollection<User>(allUsers);
                DataContext = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}");
            }
        }

        private async void PickBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserListView.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя для выдачи инвентаря");
                return;
            }

            if (currentInventory.Status != InventoryStatus.В_наличии)
            {
                MessageBox.Show("Инвентарь недоступен для выдачи.");
                return;
            }
            try
            {
                await using var dbContext = new SportDbContext();
                currentInventory.User = (User)UserListView.SelectedItem;
                currentInventory.Status = InventoryStatus.Выдан;
                await new BaseRepository<Inventory>(dbContext).UpdateAsync(currentInventory);
                MessageBox.Show("Инвентарь выдан!");
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
            Window.GetWindow(this).Close();
        }
    }
}