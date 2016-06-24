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
using System.Globalization;
using System.Text.RegularExpressions;
using ATM;

namespace ATMwpf
{
    /// <summary>
    /// Logique d'interaction pour Deposit.xaml
    /// </summary>
    public partial class Deposit : Window
    {
        ATMManager atmManager = new ATMManager();
        Checking c = new Checking();

        public Deposit(Checking check, ATMManager atm)
        {
            InitializeComponent();
            atmManager = atm;
            c = check;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            string PIN = passwordBox.Password;
            double DepositAmount = double.Parse(AmountTextBox.Text);

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
                            if (atmManager.DepositChecking(PIN, DepositAmount) == true)
                            {
                                MessageBox.Show("The amount of $" + DepositAmount + " was successfully deposited on your checking account.", "Transaction completed.");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Sorry, the deposit could not be completed. Please contact your manager.");
                            }                            
                        }
                        if (Savings.IsChecked == true)
                        {
                            if (atmManager.DepositSavings(PIN, DepositAmount) == true)
                            {
                                MessageBox.Show("The amount of $" + DepositAmount + " was successfully deposited on your savings account.");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Sorry, the deposit could not be completed. Please contact your manager.");
                            }                            
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
