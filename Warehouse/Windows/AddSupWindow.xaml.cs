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
using Warehouse.Classes;
using static Warehouse.Classes.ClassEntities;

namespace Warehouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSupWindow.xaml
    /// </summary>
    public partial class AddSupWindow : Window
    {
        public AddSupWindow()
        {
            InitializeComponent();

            tbChange.Visibility = Visibility.Hidden;
            tbChange.IsEnabled = false;
            tbChen.Visibility = Visibility.Hidden;
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btAddPart_Click(object sender, RoutedEventArgs e)
        {
            Supplier supplier = new Supplier();

            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                supplier.Title = tbName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели название");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                supplier.Address = tbAddress.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели адрес");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                supplier.Phone = tbPhone.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели номер");
                return;
            }

            MessageBox.Show("Поставщик добавлен");
            context.Supplier.Add(supplier);
            context.SaveChanges();

            this.Close();
        }

        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => ch == '+' || ch == '-' || ch == '(' || ch == ')' || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        public AddSupWindow(Supplier supplier)
        {
            InitializeComponent();

            tbName.Text = supplier.Title;
            tbAddress.Text = supplier.Address;
            tbPhone.Text = supplier.Phone;

            btAddPart.Visibility = Visibility.Hidden;
            btAddPart.IsEnabled = false;
            tbAdd.Visibility = Visibility.Hidden;
        }

        private void tbChange_Click(object sender, RoutedEventArgs e)
        {
            var supp = context.Supplier.Where(i => i.IdSupplier == PesonnelDate.IdSupplier).FirstOrDefault();
            supp.Title = tbName.Text.Trim();
            supp.Address = tbAddress.Text.Trim();
            supp.Phone = tbPhone.Text.Trim();



            Supplier supplier = new Supplier();

            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                supplier.Title = tbName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели название");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                supplier.Address = tbAddress.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели адрес");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                supplier.Phone = tbPhone.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели номер");
                return;
            }


            var chek = MessageBox.Show($"Вы хотите изменить данные ", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (chek == MessageBoxResult.Yes)
            {
                context.SaveChanges();

                MessageBox.Show("Данные изменены");
                
                this.Close();
            }
        }
    }
}
