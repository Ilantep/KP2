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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для GenPage.xaml
    /// </summary>
    public partial class GenPage : Page
    {
        public GenPage()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame1;
            MainFrame1.Navigate(new Workwea_code());
        }

        private void BtnOverall_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Workwea_code());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ImportPage());
        }
    }
}
