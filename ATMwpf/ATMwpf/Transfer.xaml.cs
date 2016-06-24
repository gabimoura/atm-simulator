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
    /// Interaction logic for Transfer.xaml
    /// </summary>
    public partial class Transfer : Window
    {
        ATMManager ATMmanager = new ATMManager();
   
        public Transfer(ATMManager atm)
        {
            InitializeComponent();
            ATMmanager = atm;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            string PIN = passwordBox.Password;
            double TransferAmount = double.Parse(AmountTextBox.Text);

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
                    if (Checking.IsChecked == true || Savings.IsChecked == true)
                    {
                        if (Checking.IsChecked == true)
                        {
                            ATMmanager.TransferFunds(PIN, TransferAmount, 'C');
                            
                            MessageBox.Show("The amount of $" + TransferAmount + " was successfully deposited on your checking account.", "Transaction completed.");
                            this.Close();      
                        }
                        if (Savings.IsChecked == true)
                        {
                            ATMmanager.TransferFunds(PIN, TransferAmount, 'S');

                            MessageBox.Show("The amount of $" + TransferAmount + " was successfully deposited on your savings account.");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select an account type.", "Warning");
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
