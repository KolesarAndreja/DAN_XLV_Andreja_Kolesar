using DAN_XLV.ViewModel;
using System.Windows;

namespace DAN_XLV.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel(this);
        }
    }
}
