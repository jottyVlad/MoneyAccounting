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
    /// Логика взаимодействия для JournalMoney.xaml
    /// </summary>
    public partial class JournalMoney : Window
    {
        public MainWindow MainWind { get; set; }
        public JournalMoney()
        {
            InitializeComponent();
            this.Closing += JournalMoney_Closing;
        }

        private void JournalMoney_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void ButtonMoneyAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            namely_JournalMoney namely_JournalWind = new namely_JournalMoney(0);
            namely_JournalWind.JournalMoneyWind = this;
            namely_JournalWind.ShowDialog();
        }

        private void ButtonBillsAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            namely_JournalMoney namely_JournalWind = new namely_JournalMoney(1);
            namely_JournalWind.JournalMoneyWind = this;
            namely_JournalWind.ShowDialog();
        }

        private void ButtonMoneyDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            namely_JournalMoney namely_JournalWind = new namely_JournalMoney(3);
            namely_JournalWind.JournalMoneyWind = this;
            namely_JournalWind.ShowDialog();
        }

        private void ButtonBillsDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            namely_JournalMoney namely_JournalWind = new namely_JournalMoney(4);
            namely_JournalWind.JournalMoneyWind = this;
            namely_JournalWind.ShowDialog();
        }
    }
}
