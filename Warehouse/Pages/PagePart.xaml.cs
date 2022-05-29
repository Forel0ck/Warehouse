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
using Warehouse.BD;
using Warehouse.Classes;
using static Warehouse.Classes.ClassEntities;
using Warehouse.Windows;

namespace Warehouse.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePart.xaml
    /// </summary>
    public partial class PagePart : Page
    {
        List<Autopart> parts = new List<Autopart>();
        List<string> ForSort = new List<string>()
        {
            "По умолчанию","По названию","По колличесву","По цене","По фирме","По стране"
        };
        public PagePart()
        {
            InitializeComponent();
            lvPart.ItemsSource = context.Autopart.ToList();
            cmbSort.ItemsSource = ForSort;
            cmbSort.SelectedIndex = 0;
            Filter();
        }
        private void Filter()
        {
            List<Autopart> autoparts = new List<Autopart>();

            autoparts = ClassEntities.context.Autopart.ToList();

            autoparts = autoparts.Where(i => i.Title.Contains(tbSearch.Text)).ToList();


            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    autoparts = autoparts.OrderBy(i => i.IdAutopart).ToList();
                    break;
                case 1:
                    autoparts = autoparts.OrderBy(i => i.Title).ToList();
                    break;
                case 2:
                    autoparts = autoparts.OrderBy(i => i.Qty).ToList();
                    break;
                case 3:
                    autoparts = autoparts.OrderBy(i => i.Cost).ToList();
                    break;
                case 4:
                    autoparts = autoparts.OrderBy(i => i.Firm.Title).ToList();
                    break;
                case 5:
                    autoparts = autoparts.OrderBy(i => i.Firm.Coutry.Country).ToList();
                    break;

            }
            if (lvPart == null)
            {
                MessageBox.Show("Такой записи нет");
            }

            lvPart.ItemsSource = autoparts;

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btDeletPart_Click(object sender, RoutedEventArgs e)
        {

            if (lvPart.SelectedItem is Autopart autopart)
            {
                var resMass = MessageBox.Show($"Вы хотите удалить запчасть {autopart.Title}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMass == MessageBoxResult.Yes)
                {
                    context.Autopart.Remove(context.Autopart.Where(i => i.IdAutopart == autopart.IdAutopart).FirstOrDefault());
                    context.SaveChanges();
                    lvPart.ItemsSource = context.Autopart.ToList();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали запчасть", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Filter();
        }

        private void btChangePart_Click(object sender, RoutedEventArgs e)
        {
            if (lvPart.SelectedItem is Autopart autopart)
            {
                var resMAss = MessageBox.Show($"Вы хотите изменить запчасть {autopart.Title}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMAss == MessageBoxResult.Yes)
                {
                    AddPartWindow addPartWindow = new AddPartWindow(autopart);
                    PesonnelDate.IdAutopart = autopart.IdAutopart;
                    addPartWindow.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали запчасть", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Filter();
        }

        private void btAddPar_Click(object sender, RoutedEventArgs e)
        {
            AddPartWindow addPartWindow = new AddPartWindow();
            addPartWindow.ShowDialog();


            Filter();
        }

        private void lvPart_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (lvPart.SelectedItem is Autopart autopart)
                {
                    var resMass = MessageBox.Show($"Вы хотите удалить запчасть {autopart.Title}", "Предупреждение", MessageBoxButton.YesNo);
                    if (resMass == MessageBoxResult.Yes)
                    {
                        context.Autopart.Remove(context.Autopart.Where(i => i.IdAutopart == autopart.IdAutopart).FirstOrDefault());
                        context.SaveChanges();
                        lvPart.ItemsSource = context.Autopart.ToList();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show($"Вы не выбрали запчасть", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Filter();
        }
    }
}
