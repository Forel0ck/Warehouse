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
using Warehouse.BD;
using static Warehouse.Classes.ClassEntities;
using Warehouse.Classes;

namespace Warehouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для InfoShipmentWindow.xaml
    /// </summary>
    public partial class InfoShipmentWindow : Window
    {
        public InfoShipmentWindow()
        {
            InitializeComponent();


        }
        public InfoShipmentWindow(Shipmen shipmen)
        {
            InitializeComponent();

            tbShipment.Text = "Поставка от : " +shipmen.Supplier.Title;
            tbDate.Text = "Дата поставки : " + Convert.ToString(shipmen.Date);

            var listpart = context.Equipment.Where(i => i.IdShipmen == shipmen.IdShipmen).ToList();

            lvPart.ItemsSource = listpart;
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
