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
    /// Логика взаимодействия для AddEditPageOverall.xaml
    /// </summary>
    public partial class AddEditPageOverall : Page
    {

        private Workwea _currentWorkwea = new Workwea();
        public AddEditPageOverall(Workwea selectedworkwea)
        {
            InitializeComponent();
            if (selectedworkwea != null)
            {
                _currentWorkwea = selectedworkwea;
            }
            DataContext = _currentWorkwea;

        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Workwea_code());
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            if (_currentWorkwea.ID == 0)
                OvverallEntities.GetContext().Workweas.Add(_currentWorkwea);
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

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                OvverallEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}
