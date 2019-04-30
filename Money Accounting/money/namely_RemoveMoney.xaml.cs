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
    /// Логика взаимодействия для namely_RemoveMoney.xaml
    /// </summary>
    public partial class namely_RemoveMoney : Window
    {
        public bool isCoins { get; set; }
        int money_remove = 0;

        public RemoveMoney RemoveMoneyWind { get; set; }

        public namely_RemoveMoney()
        {
            InitializeComponent();

            this.Closing += Namely_RemoveMoney_Closing;
        }

        private void Namely_RemoveMoney_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                RemoveMoneyWind.Show();
            }
            catch
            {
                return;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                money_remove = Convert.ToInt32(this.NumberOfMoney.Text);
            }
            catch
            {
                return;
            }
            if (this.Reason.Text != "")
            {
                if (isCoins == true)
                {
                    MySqlConnection conn = DB.GetDBConnection();
                    conn.Open();

                    string sql = $"INSERT INTO coins_register(id, reason, number) VALUES(null, '{this.Reason.Text}', -{money_remove})";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    int command_insert = command.ExecuteNonQuery();

                    sql = $"SELECT number FROM all_money WHERE what = 'coin'";
                    command = new MySqlCommand(sql, conn);
                    int temp = Convert.ToInt32(command.ExecuteScalar());

                    sql = $"UPDATE all_money SET number = {temp - money_remove} WHERE what = 'coin'";
                    command = new MySqlCommand(sql, conn);
                    command_insert = command.ExecuteNonQuery();

                    sql = $"SELECT number FROM all_money WHERE what = 'all'";
                    command = new MySqlCommand(sql, conn);
                    temp = Convert.ToInt32(command.ExecuteScalar());

                    sql = $"UPDATE all_money SET number = {temp - money_remove} WHERE what = 'all'";
                    command = new MySqlCommand(sql, conn);
                    temp = command.ExecuteNonQuery();

                    this.Close();
                }
                else
                {
                    MySqlConnection conn = DB.GetDBConnection();
                    conn.Open();

                    string sql = $"INSERT INTO bills_register(id, reason, number) VALUES(null, '{this.Reason.Text}', -{money_remove})";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    int command_insert = command.ExecuteNonQuery();

                    sql = $"SELECT number FROM all_money WHERE what = 'bill'";
                    command = new MySqlCommand(sql, conn);
                    int temp = Convert.ToInt32(command.ExecuteScalar());

                    sql = $"UPDATE all_money SET number = {temp - money_remove} WHERE what = 'bill'";
                    command = new MySqlCommand(sql, conn);
                    command_insert = command.ExecuteNonQuery();

                    sql = $"SELECT number FROM all_money WHERE what = 'all'";
                    command = new MySqlCommand(sql, conn);
                    temp = Convert.ToInt32(command.ExecuteScalar());

                    sql = $"UPDATE all_money SET number = {temp - money_remove} WHERE what = 'all'";
                    command = new MySqlCommand(sql, conn);
                    temp = command.ExecuteNonQuery();

                    this.Close();
                }
            }
        }
    }
}
