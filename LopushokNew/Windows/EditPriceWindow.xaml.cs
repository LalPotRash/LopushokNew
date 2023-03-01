using System;
using System.Linq;
using System.Windows;
using LopushokNew.DB;
using System.Collections.Generic;

namespace LopushokNew.Windows
{
    /// <summary>
    /// Interaction logic for EditPriceWindow.xaml
    /// </summary>
    public partial class EditPriceWindow : Window
    {
        public List<Product> Products { get; set; }

        public EditPriceWindow(List<Product> products)
        {
            InitializeComponent();

            Products = products;

            tbPrice.Text = Math.Round(Products.Sum(x => x.MinPrice) / Products.Count(), 2).ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            decimal price;
            if (!decimal.TryParse(tbPrice.Text, out price))
            {
                MessageBox.Show("Введено не число!", "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            foreach (var product in Products)
            {
                product.MinPrice += price;
                DataAccess.SaveProduct(product);
            }
            
            this.Close();
        }
    }
}
