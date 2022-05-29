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
    /// Логика взаимодействия для PageSupplier.xaml
    /// </summary>
    public partial class PageSupplier : Page
    {
        List<string> ForSort = new List<string>()
        {
            "По умолчанию","По названию","По адресу","По телефону"
        };
        

        public PageSupplier()
        {
            InitializeComponent();
            cmbSort.ItemsSource = ForSort;
            cmbSort.SelectedIndex = 0;
            Filter();

            lvSupplier.ItemsSource = context.Supplier.ToList();
        }
        private void Filter()
        {
            List<Supplier> suppliers = new List<Supplier>();

            suppliers = context.Supplier.ToList();

            suppliers = suppliers.Where(i => i.FIO.Contains(tbSearch.Text )).ToList();


            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    suppliers = suppliers.OrderBy(i => i.IdSupplier).ToList();
                    break;
                case 1:
                    suppliers = suppliers.OrderBy(i => i.Title).ToList();
                    break;
                case 2:
                    suppliers = suppliers.OrderBy(i => i.Address).ToList();
                    break;
                case 3:
                    suppliers = suppliers.OrderBy(i => i.Phone).ToList();
                    break;
                

            }
            

            lvSupplier.ItemsSource = suppliers;

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void AddSup_Click(object sender, RoutedEventArgs e)
        {
            AddSupWindow addSupWindow = new AddSupWindow();
            addSupWindow.ShowDialog();
        }

        private void DeletSup_Click(object sender, RoutedEventArgs e)
        {
            if (lvSupplier.SelectedItem is Supplier supplier)
            {
                var resMass = MessageBox.Show($"Вы хотите удалить поставщика {supplier.Title}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMass == MessageBoxResult.Yes)
                {
                    context.Supplier.Remove(context.Supplier.Where(i => i.IdSupplier == supplier.IdSupplier).FirstOrDefault());
                    context.SaveChanges();
                    lvSupplier.ItemsSource = context.Supplier.ToList();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали поставщика", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Filter();
        }

        private void lvSupplier_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (lvSupplier.SelectedItem is Supplier supplier)
                {
                    var resMass = MessageBox.Show($"Вы хотите удалить поставщика {supplier.Title}", "Предупреждение", MessageBoxButton.YesNo);
                    if (resMass == MessageBoxResult.Yes)
                    {
                        context.Supplier.Remove(context.Supplier.Where(i => i.IdSupplier == supplier.IdSupplier).FirstOrDefault());
                        context.SaveChanges();
                        lvSupplier.ItemsSource = context.Supplier.ToList();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show($"Вы не выбрали поставщика", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Filter();
        }

        private void AddChange_Click(object sender, RoutedEventArgs e)
        {

            if (lvSupplier.SelectedItem is Supplier supplier)
            {
                var resMAss = MessageBox.Show($"Вы хотите изменить поставщика {supplier.Title}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMAss == MessageBoxResult.Yes)
                {
                    
                    AddSupWindow addWindow = new AddSupWindow(supplier);
                    PesonnelDate.IdSupplier = supplier.IdSupplier;
                    addWindow.ShowDialog();
                   
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали поставщика", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Filter();
        }
    }
}
