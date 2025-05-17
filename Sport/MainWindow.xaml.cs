using Sport.Pages.Login;
using System.Windows;
using System.Windows.Controls;

namespace Sport
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new AuthPage());
        }
        public MainWindow(Page page)
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(page);
        }
    }
}