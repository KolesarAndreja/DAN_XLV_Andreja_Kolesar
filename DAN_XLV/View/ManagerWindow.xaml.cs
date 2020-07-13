using DAN_XLV.ViewModel;
using System.Windows;


namespace DAN_XLV.View
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            this.DataContext = new ManagerViewModel(this);
        }
    }
}
