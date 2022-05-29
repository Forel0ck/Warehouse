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
using Warehouse.Pages;
using Warehouse.BD;
using Warehouse.Classes;

namespace Warehouse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new PagePart();
            

        }

        private void btAutopart_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PagePart();
        }


        private void btSupplier_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageSupplier();
        }

        private void btShipment_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageShipment();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
