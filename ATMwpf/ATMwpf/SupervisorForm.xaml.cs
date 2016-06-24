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
    /// Interaction logic for SupervisorForm.xaml
    /// </summary>
    public partial class SupervisorForm : Window
    {
        ATMManager atm = new ATMManager();
        Bank b = new Bank();

        string USERid;
        public SupervisorForm(string UserID)
        {
            InitializeComponent();
            USERid = UserID;
            this.Loaded += new RoutedEventHandler(SupervisorForm_Loaded);
        }
        void SupervisorForm_Loaded(object sender, RoutedEventArgs e)
        {
            atm.ReadAccounts();
            atm.ReadCustomers();
            atm.ReadTransactions();
        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = e.Source as MenuItem;
            switch (menu.Name)
            {
                case "Exit":
                    MessageBox.Show("Are you sure you want quit the Administrator menu?");
                    this.Close();
                    break;
                case "CloseATM":
                    MessageBox.Show("Are you sure you want to close the Caju Bank ATM?");                                              
                    Login log = new Login();
                    log.Close();
                    this.Close();
                    break;
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = e.Source as MenuItem;
            switch (menu.Name)
            {
                case "Support":
                    Support SupportForm = new Support();
                    SupportForm.Show();
                    break;
                case "About":
                    aboutATM aboutForm = new aboutATM();
                    aboutForm.Show();
                    break;
            }
        }

        private void Money_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = e.Source as MenuItem;
            switch (menu.Name)
            {
                case "FillUp":
                    b.refillATM(USERid);
                    MessageBox.Show("The amount of $5000 has been refilled. Thank you.");
                    break;
                case "PayInterests":
                    if (atm.PayInterests(USERid) == true)
                    {
                        MessageBox.Show("The interest of 1.25 was applied to all savings accounts. Thank you.");
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Sorry, the transaction could not be completed.");
                        break;
                    }
            }            
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = e.Source as MenuItem;
            switch (menu.Name)
            {
                case "TransactionsByDate":
                    atm.ReadTransactions();
                    break;
                case "TransactionsByAccount":
                    aboutATM aboutForm = new aboutATM();
                    aboutForm.Show();
                    break;
            }
        }
    }
}
