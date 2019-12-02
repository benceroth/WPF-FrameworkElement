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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfFrameworkElement.ViewModels;

namespace WpfFrameworkElement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool shown;
        public MainWindow()
        {
            this.InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if(!shown)
            {
                shown = true;
                this.MainViewModel.GenerateCommand.Execute(null);
            }
        }

        private MainViewModel MainViewModel => this.FindResource("VM") as MainViewModel;
    }
}
