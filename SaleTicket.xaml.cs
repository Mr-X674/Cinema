using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WPF_StudentsAchievement_Project.Resources.Profiles;

namespace Cinema
{
    /// <summary>
    /// Логика взаимодействия для SaleTicket.xaml
    /// </summary>
    public partial class SaleTicket : Window
    {
        DataBaseField baseField = new DataBaseField();
        SqlConnection sqlConnection = new SqlConnection("Data Source=MSI-AEGIS-TI3;Initial Catalog=Cinema;Integrated Security=True");
        DataBase dataBase = new DataBase();

        public SaleTicket()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void FilmComboBoxRefresh()
        {
            dataBase.OpenConnection();
            string queryString = "SELECT film FROM film";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            SqlDataReader sqlDataReader = command.ExecuteReader();
            FilmComboBox.Items.Clear();
            while (sqlDataReader.Read())
            {
                string film = sqlDataReader.GetString(1);
                FilmComboBox.Items.Add($"{film}");
            }
            dataBase.CloseConnection();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FilmComboBoxRefresh();
        }

        //private void ComboBox_DropDownClosed(object sender, EventArgs e)
        //{
        //    baseField.Film = Convert.ToInt32(check.SearchElementID(FilmComboBox.Text));
        //}

    }
}
