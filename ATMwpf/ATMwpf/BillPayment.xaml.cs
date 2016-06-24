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
using ATM;

namespace ATMwpf
{
    /// <summary>
    /// Interaction logic for BillPayment.xaml
    /// </summary>
    public partial class BillPayment : Window
    {
        ATMManager Atm = new ATMManager();
        
        public BillPayment(ATMManager atm)
        {
            InitializeComponent();
            Atm = atm;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validAmount = false;
                bool validPIN = false;
                if (passwordBox.Password == "")
                {
                    MessageBox.Show("Please provide a valid password.");
                    validPIN = true;
                }
                if (AmountTextBox.Text == "")
                {
                    MessageBox.Show("Please provide a valid deposit amount.");
                    validAmount = true;
                }

                if (validAmount == false && validPIN == false)
                {
                    string PIN = passwordBox.Password;
                    double PaymentAmount = double.Parse(AmountTextBox.Text);
                        
                    if (Atm.PayBill(PIN, PaymentAmount) == true)
                    {
                        MessageBox.Show("New balance: " + Atm.DisplayCheckingAccountBalance(PIN), "Transaction completed.");
                        MessageBox.Show("Don't forget to insert your envelop.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sorry, the transaction could not be completed. Please contact your manager.");
                    }
                }                   
            }
            catch
            {
                MessageBox.Show("Invalid input.");
                AmountTextBox.Clear();
                passwordBox.Clear();
                return;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
