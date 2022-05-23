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
    /// Логика взаимодействия для Workwea_code.xaml
    /// </summary>
    public partial class Workwea_code : Page
    {
        public Workwea_code()
        {
            InitializeComponent();
            DGridWorkwea.ItemsSource = OvverallEntities.GetContext().Workweas.ToList();
        }


        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EnterPage());

        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPageOverall(null));
        }

        private void Deletbtn_Click(object sender, RoutedEventArgs e)
        {
            var WorkwearRemoving = DGridWorkwea.SelectedItems.Cast<Workwea>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {WorkwearRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    OvverallEntities.GetContext().Workweas.RemoveRange(WorkwearRemoving);
                    OvverallEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridWorkwea.ItemsSource = OvverallEntities.GetContext().Workweas.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPageOverall((sender as Button).DataContext as Workwea));
        }
    }
}
