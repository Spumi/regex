using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


namespace regex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!IsNameValid())
                MessageBox.Show("Name is invalid!", "Invalid name",MessageBoxButton.OK, MessageBoxImage.Warning);
            if (!IsEmailValid())
                MessageBox.Show("Email is invalid!", "Invalid email", MessageBoxButton.OK, MessageBoxImage.Warning);
            if (!IsPhoneValid())
                MessageBox.Show("phone is valid!", "valid phone", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                ReformatPhone();
        }

        bool IsNameValid()
        {
            string name = "[a-zA-Z]+";
            string whitespace = @"\s";
            string pattern = "^(" + name + whitespace + "*)+$";
            return Regex.IsMatch(txtName.Text, pattern);
        }

        bool IsEmailValid() {
            string pattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,5}$";
            return Regex.IsMatch(txtEmail.Text, pattern);
        }

        bool IsPhoneValid() {
            string pattern = @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$";
            return Regex.IsMatch(txtPhone.Text, pattern);
        }

        void ReformatPhone() {
            string pattern = @"(\d{3})(\d{3})(\d{4})";
            txtPhone.Text = Regex.Replace(txtPhone.Text, pattern, "($1) $2-$3");
        }
    }
}
