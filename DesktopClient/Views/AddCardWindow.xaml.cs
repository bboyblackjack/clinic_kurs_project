using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DataModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopClient
{
    /// <summary>
    /// Логика взаимодействия для AddCardWindow.xaml
    /// </summary>
    public partial class AddCardWindow 
    {
        public AddCardWindow()
        {
            InitializeComponent();

        }

        public void CloseWindow(string result)
        {
            
        }
        
    }
}
