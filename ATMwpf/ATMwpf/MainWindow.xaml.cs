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
using ATM;

namespace ATMwpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ATMManager atm = new ATMManager();
        Checking check = new Checking();

        public string atmManager { get; set; }
        public string user { get; set; }
        public string pin { get; set; }
        public string counter { get; set; }

        string USERID;
        public MainWindow(string UserID)
        {
            InitializeComponent();
            dateLabel.Content = DateTime.Now.ToLongDateString();
            USERID = UserID;
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            atm.ReadAccounts();
            atm.ReadCustomers();
            atm.ReadTransactions();
        }
        private void Balance_Click(object sender, RoutedEventArgs e)
        {
            Balance balanceForm = new Balance(atm);
            balanceForm.Show();
        }
        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            Deposit depForm = new Deposit(check,atm);
            depForm.Show();
        }

        private void Withdrawal_Click(object sender, RoutedEventArgs e)
        {
            Withdrawal withForm = new Withdrawal(atm);
            withForm.Show();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            Transfer TranferForm = new Transfer(atm);
            TranferForm.Show();
        }

        private void Bill_Payment_Click(object sender, RoutedEventArgs e)
        {
            BillPayment BillForm = new BillPayment(atm);
            BillForm.Show();
        }
               
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            if(atm.WriteAccounts()==true)
            {
                MessageBox.Show("Thank you for using Caju Bank ATM. Have a good day!");
                this.Close();
            }
            else
            {
                MessageBox.Show("We apoligize, we are having technical problems. Your transactions could not be saved. Please find assitency at the branch counter.");
            }   
        }
    }
}
