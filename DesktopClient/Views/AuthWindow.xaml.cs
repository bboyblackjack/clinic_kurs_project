using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using RestSharp;
using DesktopClient.ViewModels;
using DataModel;

namespace DesktopClient
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        //private RestClient _restClient;

        public AuthWindow()
        {
            InitializeComponent();
           
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            Auth(Login.Text, Password.Password);
        }

        private void Password_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        private void Auth(string email, string password)
        {
            User user = new User()
            {
                Email = email,
                Password = password,
            };
            var result = AuthController.GetByEmail(user);
            if (result)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                Close();
            }
            else
            {
                Error.Visibility = System.Windows.Visibility.Visible;
            }
        }


       
        
    }
}
