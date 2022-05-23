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
    /// Логика взаимодействия для ImportPage.xaml
    /// </summary>
    public partial class ImportPage : Page
    {
        public ImportPage()
        {
            InitializeComponent();
            DGridImport.ItemsSource = OvverallEntities.GetContext().InformationAdmissions.ToList();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EnterPage());
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ImportAdd(null));
        }

        private void Deletbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ImportAdd((sender as Button).DataContext as InformationAdmission));
        }
    }
}
