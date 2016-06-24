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
    /// Interaction logic for Withdrawal.xaml
    /// </summary>
    public partial class Withdrawal : Window
    {
        ATMManager ATMmanager = new ATMManager();
        
        public Withdrawal(ATMManager atm)
        {
            InitializeComponent();
            ATMmanager = atm;
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
                    bool validatingAmount = int.Parse(AmountTextBox.Text) % 10 == 0;

                    if (validatingAmount == true)
                    {
                        string PIN = passwordBox.Password;
                        double WithdrawalAmount = double.Parse(AmountTextBox.Text);

                        if (Checking.IsChecked == true || Savings.IsChecked == true)
                        {
                            if (Checking.IsChecked == true)
                            {
                                if (ATMmanager.WithdrawChecking(PIN, WithdrawalAmount) == true)
                                {
                                    MessageBox.Show("The amount of $" + WithdrawalAmount + " was successfully withdrawn from your checking account.");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Sorry, the transaction could not be completed. Please contact your manager.");
                                }
                            }
                            if (Savings.IsChecked == true)
                            {
                                if (ATMmanager.WithdrawSavings(PIN, WithdrawalAmount) == true)
                                {
                                    MessageBox.Show("The amount of $" + WithdrawalAmount + " was successfully withdrawn from to your savings account.");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Sorry, the transaction could not be completed. Please contact your manager.");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a value multiple of 10.", "Warning");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an account type.", "Warning");
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
