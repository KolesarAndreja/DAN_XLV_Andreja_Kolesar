using DAN_XLV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
