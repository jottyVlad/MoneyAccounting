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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Money_Accounting.money;

namespace Money_Accounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddMoney_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddMoney AddMoneyWind = new AddMoney();
            AddMoneyWind.MainWind = this;
            AddMoneyWind.ShowDialog();
        }

        private void RemoveMoney_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RemoveMoney RemoveMoneyWind = new RemoveMoney();
            RemoveMoneyWind.MainWind = this;
            RemoveMoneyWind.ShowDialog();
        }

        private void SeeMoney_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SeeMoney SeeMoneyWind = new SeeMoney();
            SeeMoneyWind.MainWind = this;
            SeeMoneyWind.ShowDialog();
        }
    }
}
