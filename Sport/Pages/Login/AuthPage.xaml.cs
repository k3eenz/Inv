using System.Windows;
using System.Windows.Controls;

namespace Sport.Pages.Login
{
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private async void AuthBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (ValidateManager.IsNullTextBox(LoginTextBox.Text, PasswordBox.Password)) return;

                await using var dbContext = new SportDbContext();
                var user = await new UserRepository(dbContext).SearchUser(LoginTextBox.Text, PasswordBox.Password);

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }
                NavigationService.Navigate(new MainPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
