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
    /// Логика взаимодействия для namely_AddMoney.xaml
    /// </summary>
    public partial class namely_AddMoney : Window
    {

        public AddMoney AddMoneyWind { get; set; }
        public bool isCoins { get; set; }
        int money_add = 0; 
        public namely_AddMoney()
        {
            InitializeComponent();

            this.Closing += Namely_AddMoney_Closing;
        }

        private void Namely_AddMoney_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                AddMoneyWind.Show();
            }
            catch
            {
                return;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                money_add = Convert.ToInt32(this.NumberOfMoney.Text);
            }
            catch
            {
                return;
            }
            if(this.Reason.Text != "")
            {
                if(isCoins == true)
                {
                    MySqlConnection conn = DB.GetDBConnection();
                    conn.Open();

                    string sql = $"INSERT INTO coins_register(id, reason, number) VALUES(null, '{this.Reason.Text}', {money_add})";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    int command_insert = command.ExecuteNonQuery();

                    sql = $"UPDATE all_money SET number = {money_add} WHERE what = 'coin'";
                    command = new MySqlCommand(sql, conn);
                    command_insert = command.ExecuteNonQuery();

                    sql = $"SELECT number FROM all_money WHERE what = 'all'";
                    command = new MySqlCommand(sql, conn);
                    int temp = Convert.ToInt32(command.ExecuteScalar());

                    sql = $"UPDATE all_money SET number = {temp+money_add} WHERE what = 'all'";
                    command = new MySqlCommand(sql, conn);
                    temp = command.ExecuteNonQuery();

                    this.Close();
                }
                else
                {
                    MySqlConnection conn = DB.GetDBConnection();
                    conn.Open();
                    string sql = $"INSERT INTO bills_register(id, reason, number) VALUES(null, '{this.Reason.Text}', {money_add})";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    int command_insert = command.ExecuteNonQuery();

                    sql = $"UPDATE all_money SET number = {money_add} WHERE what = 'bill'";
                    command = new MySqlCommand(sql, conn);
                    command_insert = command.ExecuteNonQuery();

                    sql = $"SELECT number FROM all_money WHERE what = 'all'";
                    command = new MySqlCommand(sql, conn);
                    int temp = Convert.ToInt32(command.ExecuteScalar());

                    sql = $"UPDATE all_money SET number = {temp + money_add} WHERE what = 'all'";
                    command = new MySqlCommand(sql, conn);
                    temp = command.ExecuteNonQuery();
                }
            }
        }
    }
}
