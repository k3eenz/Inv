using System.Windows;
using System.Windows.Controls;

namespace Sport.Pages.Login
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateManager.IsNullTextBox(LoginTextBox.Text, PasswordBox.Password, PhoneNumberTextBox.Text, FullNameTextBox.Text)) return;

                await using var dbContext = new SportDbContext();
                var user = new User
                {
                    Login = LoginTextBox.Text,
                    Password = HashManager.HashPassword(PasswordBox.Password),
                    PhoneNumber = PhoneNumberTextBox.Text,
                    FullName = FullNameTextBox.Text
                };

                if (!ValidateManager.IsCorrectModel(user)) return;

                await new BaseRepository<User>(dbContext).AddAsync(user);
                NavigationService.Navigate(new MainPage());
                MessageBox.Show("Вы успешно зарегистрировались!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
