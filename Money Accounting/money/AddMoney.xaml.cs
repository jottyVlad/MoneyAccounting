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
    /// Логика взаимодействия для AddMoney.xaml
    /// </summary>
    public partial class AddMoney : Window
    {
        public MainWindow MainWind { get; set; }
        public AddMoney()
        {
            InitializeComponent();

            this.Closing += AddMoney_Closing;
        }

        private void AddMoney_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void AddCoins_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            namely_AddMoney AddCoinsWind = new namely_AddMoney();
            AddCoinsWind.isCoins = true;
            AddCoinsWind.AddMoneyWind = this;
            AddCoinsWind.ShowDialog();
        }

        private void AddBills_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            namely_AddMoney AddCoinsWind = new namely_AddMoney();
            AddCoinsWind.isCoins = false;
            AddCoinsWind.AddMoneyWind = this;
            AddCoinsWind.ShowDialog();
        }
    }
}
