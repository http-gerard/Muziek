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

namespace ProjectMuziek.Components
{
    /// <summary>
    /// Interaction logic for BindablePasswordbox.xaml
    /// </summary>
    public partial class BindablePasswordbox : UserControl
    {
        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordbox), new PropertyMetadata(string.Empty));


        public BindablePasswordbox()
        {
            InitializeComponent();
        }

        private void passwordBox_OnPasswordChanged(object sender, RoutedEventArgs e) => Password = passwordBox.Password;
    }
}

