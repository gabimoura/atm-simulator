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
    /// Interaction logic for Balance.xaml
    /// </summary>
    public partial class Balance : Window
    {
        ATMManager atmManager = new ATMManager();

        public Balance(ATMManager atm)
        {
            InitializeComponent();
            atmManager = atm;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            string PIN = passwordBox.Password;
            try
            {
                bool validPIN = false;
                if (passwordBox.Password == "")
                {
                    MessageBox.Show("Please provide a valid password.");
                    validPIN = true;
                }                

                if (validPIN == false)
                {
                    if (Checking.IsChecked == true || Savings.IsChecked == true)
                    {
                        if (Checking.IsChecked == true) 
                        {
                            atmManager.DisplayCheckingAccountBalance(PIN);
                            MessageBox.Show("Your checking account balance is: " + atmManager.DisplayCheckingAccountBalance(PIN)); 
                            this.Close();
                        }
                        if (Savings.IsChecked == true)
                        {
                            atmManager.DisplaySavingsAccountBalance(PIN);
                            MessageBox.Show("Your savings account balance is: " + atmManager.DisplaySavingsAccountBalance(PIN));
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
