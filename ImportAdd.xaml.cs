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
    /// Логика взаимодействия для ImportAdd.xaml
    /// </summary>
    public partial class ImportAdd : Page
    {

        private InformationAdmission _currentInformation = new InformationAdmission();
        public ImportAdd(InformationAdmission selectedInformation)
        {
            InitializeComponent();
            if (selectedInformation != null)
            {
                _currentInformation = selectedInformation;
            }
            DataContext = _currentInformation;
            DGridInp.ItemsSource = OvverallEntities.GetContext().Workweas.ToList();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ImportPage());
        }

       

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            if (_currentInformation.ID == 0)
                OvverallEntities.GetContext().InformationAdmissions.Add(_currentInformation);
            try
            {
                OvverallEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
