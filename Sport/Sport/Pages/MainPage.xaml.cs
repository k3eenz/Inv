using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Sport.Pages
{
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Inventory> _inventories;
        private ObservableCollection<Inventory> _allInventories;
        public ObservableCollection<Inventory> Inventories { get => _inventories; set { _inventories = value; OnPropertyChanged(); } }

        public MainPage()
        {
            InitializeComponent();
            _ = LoadInventory();
        }

        public async Task LoadInventory()
        {
            try
            {
                await using var dbContext = new SportDbContext();
                var allInventory = await new BaseRepository<Inventory>(dbContext).GetAllAsync();
                _allInventories = new ObservableCollection<Inventory>(allInventory);
                Inventories = new ObservableCollection<Inventory>(_allInventories);
                DataContext = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Inventory GetSelectedInventory()
        {
            if (InventoryListView.SelectedItem == null)
            {
                MessageBox.Show("Выберите инвентарь.");
                return null;
            }
            return (Inventory)InventoryListView.SelectedItem;
        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GetSelectedInventory() == null) return;

            await using var dbContext = new SportDbContext();
            var selected = GetSelectedInventory();
            await new BaseRepository<Inventory>(dbContext).DeleteAsync(selected);
            Inventories.Remove(selected);
            _allInventories.Remove(selected);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new AddInventoryPage();
            if (new MainWindow(page).ShowDialog() == true)
            {
                Inventories.Add(page.newInventory);
                _allInventories.Add(page.newInventory); 
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetSelectedInventory() == null) return;

            var page = new AddInventoryPage(GetSelectedInventory());
            new MainWindow(page).ShowDialog();
        }

        private void IssueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GetSelectedInventory() == null) return;

            var page = new IssuePage(GetSelectedInventory());
            new MainWindow(page).ShowDialog();
        }

        private async void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = GetSelectedInventory();
            if (selected == null) return;

            if (selected.Status != InventoryStatus.Выдан)
            {
                MessageBox.Show("Инвентарь не выдан, списание невозможно.");
                return;
            }
            try
            {
                await using var dbContext = new SportDbContext();
                var repository = new BaseRepository<Inventory>(dbContext);

                selected.Status = InventoryStatus.В_наличии;
                selected.User = null;
                await repository.UpdateAsync(selected);

                MessageBox.Show("Инвентарь успешно списан.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchTextBox.Text.Trim().ToLower();
            Inventories = string.IsNullOrEmpty(searchText) ? _allInventories : new ObservableCollection<Inventory>(_allInventories.Where(i => i.Name.ToLower().Contains(searchText)));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}