using MySql.Data.MySqlClient;
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
    /// Логика взаимодействия для SeeMoney.xaml
    /// </summary>
    public partial class SeeMoney : Window
    {
        public MainWindow MainWind { get; set; }
        public SeeMoney()
        {
            InitializeComponent();

            SeeMoneyOnLabel();

            this.Closing += SeeMoney_Closing;
        }

        private void SeeMoney_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        void SeeMoneyOnLabel()
        {
            MySqlConnection conn = DB.GetDBConnection();
            conn.Open();
            string sql = "SELECT number FROM all_money WHERE what = 'coin'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            int coins = Convert.ToInt32(command.ExecuteScalar());
            this.Coins.Content = $"Монет: {coins} рублей";

            sql = "SELECT number FROM all_money WHERE what = 'bill'";
            command = new MySqlCommand(sql, conn);
            int bills = Convert.ToInt32(command.ExecuteScalar());
            this.Bills.Content = $"Купюр: {bills} рублей";

            this.Total.Content = $"Всего: {coins+bills} рублей";
        }
    }
}
