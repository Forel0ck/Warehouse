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
using static Warehouse.Classes.ClassEntities;
using Warehouse.Windows;
using Warehouse.Classes;

namespace Warehouse.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageShipment.xaml
    /// </summary>
    public partial class PageShipment : Page
    {
        List<string> ForSort = new List<string>()
        {
            "По умолчанию","По дате","По поставщику",
        };

        public PageShipment()
        {
            InitializeComponent();
            cmbSort.ItemsSource = ForSort;
            cmbSort.SelectedIndex = 0;
            Filter();

            lvShipment.ItemsSource = context.Shipmen.ToList();

        }
        private void Filter()
        {
           

            List<Shipmen> shipmens = new List<Shipmen>();

            shipmens = context.Shipmen.ToList();

            shipmens = shipmens.Where(i => i.Supplier.Title.Contains(tbSearch.Text) || i.Date.ToString().Contains(tbSearch.Text)).ToList();


            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    shipmens = shipmens.OrderBy(i => i.IdShipmen).ToList();
                    break;
                case 1:
                    shipmens = shipmens.OrderBy(i => i.Date).ToList();
                    break;
                case 2:
                    shipmens = shipmens.OrderBy(i => i.Supplier.Title).ToList();
                    break;
                


            }
            

            lvShipment.ItemsSource = shipmens;

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void btInfoShipmen_Click(object sender, RoutedEventArgs e)
        {
            if (lvShipment.SelectedItem is Shipmen shipmen)
            {

                InfoShipmentWindow infoShipmentWindow = new InfoShipmentWindow(shipmen); 
                PesonnelDate.IdShipmen = shipmen.IdShipmen;
                infoShipmentWindow.ShowDialog();

            }
            else
            {
                MessageBox.Show($"Вы не выбрали поставщику", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
