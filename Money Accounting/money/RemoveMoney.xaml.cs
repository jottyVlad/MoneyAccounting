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

namespace Money_Accounting.money
{
    /// <summary>
    /// Логика взаимодействия для RemoveMoney.xaml
    /// </summary>
    public partial class RemoveMoney : Window
    {
        public MainWindow MainWind { get; set; }
        public RemoveMoney()
        {
            InitializeComponent();

            this.Closing += RemoveMoney_Closing;
        }

        private void RemoveMoney_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                MainWind.Show();
            }
            catch
            {
                return;
            }
        }

        private void RemoveCoins_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            namely_RemoveMoney RemoveCoinsWind = new namely_RemoveMoney();
            RemoveCoinsWind.isCoins = true;
            RemoveCoinsWind.RemoveMoneyWind = this;
            RemoveCoinsWind.ShowDialog();
        }

        private void RemoveBills_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            namely_RemoveMoney RemoveCoinsWind = new namely_RemoveMoney();
            RemoveCoinsWind.isCoins = false;
            RemoveCoinsWind.RemoveMoneyWind = this;
            RemoveCoinsWind.ShowDialog();
        }
    }
}
