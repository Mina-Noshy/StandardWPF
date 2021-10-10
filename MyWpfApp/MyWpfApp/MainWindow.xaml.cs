using Dapper;
using MyWpfApp.data;
using MyWpfApp.mvvm.models;
using MyWpfApp.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace MyWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly iUserServices services;
        public MainWindow(iUserServices _services)
        {
            services = _services;

            InitializeComponent();
        }

        private async void btnAccent_Click(object sender, RoutedEventArgs e)
        {
            var result = services.add(new user { username = "youstina", password = "666666", loginDate = DateTime.Now.Date });

            if (await result)
                MessageBox.Show("all done");
            else
                MessageBox.Show("error");
        }
    }
}
