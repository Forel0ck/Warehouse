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
    /// Логика взаимодействия для AddPartWindow.xaml
    /// </summary>
    public partial class AddPartWindow : Window
    {
        List<Firm> firms = new List<Firm>();

        public AddPartWindow()
        {
            InitializeComponent();

            cmbFirm.ItemsSource = context.Firm.ToList();
            cmbFirm.DisplayMemberPath = "Title";
            cmbFirm.SelectedIndex = 0;

            tbChange.Visibility = Visibility.Hidden;
            btChahgePart.Visibility = Visibility.Hidden;
            btChahgePart.IsEnabled = false;
        }

        private void btAddPart_Click(object sender, RoutedEventArgs e)
        {
            Autopart autopart = new Autopart();

            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                autopart.Title = tbName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели название");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbQty.Text))
            {
                autopart.Qty = Convert.ToInt32(tbQty.Text);
            }
            else
            {
                MessageBox.Show("Вы не ввели количество ");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbCost.Text))
            {
                autopart.Cost = Convert.ToInt32(tbCost.Text);
            }
            else
            {
                MessageBox.Show("Вы не ввели цену");
                return;
            }

            autopart.IdFirm = cmbFirm.SelectedIndex + 1;

            MessageBox.Show("Запчасть добавлен");
            context.Autopart.Add(autopart);
            context.SaveChanges();

            this.Close();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public AddPartWindow(Autopart autopart)
        {
            InitializeComponent();

            cmbFirm.ItemsSource = context.Firm.ToList();
            cmbFirm.DisplayMemberPath = "Title";
            cmbFirm.SelectedIndex = autopart.IdFirm - 1;

            tbName.Text = autopart.Title;
            tbQty.Text = Convert.ToString(autopart.Qty);
            tbCost.Text = Convert.ToString(autopart.Cost);

            tbAdd.Visibility = Visibility.Hidden;
            btAddPart.Visibility = Visibility.Hidden;
            btAddPart.IsEnabled = false;
                
        }


        private void btChahgePart_Click(object sender, RoutedEventArgs e)
        {
            var part = context.Autopart.Where(i => i.IdAutopart == PesonnelDate.IdAutopart).FirstOrDefault();

            part.Title = tbName.Text.Trim();
            part.Qty = Convert.ToInt32(tbQty.Text.Trim());
            part.Cost = Convert.ToInt32(tbCost.Text.Trim());
            part.IdFirm = cmbFirm.SelectedIndex + 1;

            Autopart autopart = new Autopart();

            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                autopart.Title = tbName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели название");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbQty.Text))
            {
                autopart.Qty = Convert.ToInt32(tbQty.Text);
            }
            else
            {
                MessageBox.Show("Вы не ввели количество ");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbCost.Text))
            {
                autopart.Cost = Convert.ToInt32(tbCost.Text);
            }
            else
            {
                MessageBox.Show("Вы не ввели цену");
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

        private void tbQty_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }
    }
}
