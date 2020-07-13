using DAN_XLV.ViewModel;
using System.Windows;

namespace DAN_XLV.View
{
    /// <summary>
    /// Interaction logic for StorekeeperWIndow.xaml
    /// </summary>
    public partial class StorekeeperWIndow : Window
    {
        public StorekeeperWIndow()
        {
            InitializeComponent();
            this.DataContext = new StorekeeperViewModel(this);
        }
    }
}
