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
    /// Логика взаимодействия для namely_JournalMoney.xaml
    /// </summary>
    public partial class namely_JournalMoney : Window
    {
        public JournalMoney JournalMoneyWind { get; set; }
        public namely_JournalMoney(int wts)
        {
            InitializeComponent();

            MySqlConnection conn = DB.GetDBConnection();
            conn.Open();
            if(wts == 0)
            {
                string sql = "SELECT * FROM coins_register WHERE number > 0";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    this.label.Content += reader[1].ToString() + " - " + reader[2].ToString() + " рублей\n";
                }
            }
            else if(wts == 1)
            {
                string sql = "SELECT * FROM bills_register WHERE number > 0";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.label.Content += reader[1].ToString() + " - " + reader[2].ToString() + " рублей\n";
                }
            }
            else if (wts == 3)
            {
                string sql = "SELECT * FROM coins_register WHERE number < 0";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.label.Content += reader[1].ToString() + " - " + reader[2].ToString() + " рублей\n";
                }
            }
            else if (wts == 4)
            {
                string sql = "SELECT * FROM bills_register WHERE number < 0";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.label.Content += reader[1].ToString() + " - " + reader[2].ToString() + " рублей\n";
                }
            }
            this.Closing += Namely_JournalMoney_Closing;
        }

        private void Namely_JournalMoney_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                JournalMoneyWind.Show();
            }
            catch
            {
                return;
            }
        }
    }
}
