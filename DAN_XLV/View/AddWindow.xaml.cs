using DAN_XLV.ViewModel;
using System.Windows;


namespace DAN_XLV.View
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            this.DataContext = new AddProductViewModel(this);
        }

        public AddWindow(Service.tblProduct p)
        {
            InitializeComponent();
            this.DataContext = new AddProductViewModel(this,p);
        }
    }
}
