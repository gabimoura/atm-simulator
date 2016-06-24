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
using System.IO;
using ATM;

namespace ATMwpf
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ATMManager atmManager = new ATMManager();
        

        public Login()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Login_Loaded);
        }
        void Login_Loaded(object sender, RoutedEventArgs e)
        {
            atmManager.ReadAccounts();
            atmManager.ReadCustomers();
            atmManager.ReadTransactions();
        }
        public string pin { get; set; }
        public string amount { get; set; }

        public bool accountsRead;

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (userTextbox.Text == "" && passwordTextbox.Password == "")
                {
                    MessageBox.Show("Please provide username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    bool accountsRead = false;
                    atmManager.ReadCustomers();
                    foreach (Customer c in atmManager.allcustomers)
                    {
                        if (userTextbox.Text == c.GetName() && passwordTextbox.Password == c.GetPINNumber())
                        {
                            if (c.GetPINNumber() == "0000")
                            {
                                accountsRead = true;
                                MessageBox.Show("Welcome to Caju Bank. You have been granted the administrator menu.");
                                SupervisorForm SupForm = new SupervisorForm(passwordTextbox.Password);
                                SupForm.Show();
                                userTextbox.Clear();
                                passwordTextbox.Clear();
                                break;
                            }
                            else
                            {
                                accountsRead = true;
                                MessageBox.Show("Welcome to Caju Bank.");
                                MainWindow mainw = new MainWindow(passwordTextbox.Password);
                                mainw.Show();
                                this.Close();
                                break;
                            }
                        }
                    }
                    if (accountsRead == false)
                    {
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        userTextbox.Clear();
                        passwordTextbox.Clear();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry, something went wrong with your login.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
