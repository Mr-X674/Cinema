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
using Cinema.Checks;
using Cinema;

namespace Cinema
{
    public partial class SaleTicket : Window
    {
        Check check = new Check();
        DataBaseField baseField = new DataBaseField();
        //DataBaseField baseField = new DataBaseField();
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
            string queryString = "SELECT id_film,name FROM film";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            SqlDataReader sqlDataReader = command.ExecuteReader();
            FilmComboBox.Items.Clear();
            while (sqlDataReader.Read())
            {
                int id = sqlDataReader.GetInt32(0);
                string filmName = sqlDataReader.GetString(1);
                FilmComboBox.Items.Add($"{id}:{filmName}");
            }
            dataBase.CloseConnection();
        }
        public void HallComboBoxRefresh()
        {
            dataBase.OpenConnection();
            string queryString = "SELECT id_hall,name FROM hall";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            SqlDataReader sqlDataReader = command.ExecuteReader();
            HallComboBox.Items.Clear();
            while (sqlDataReader.Read())
            {
                int id = sqlDataReader.GetInt32(0);
                string hall = sqlDataReader.GetString(1);
                HallComboBox.Items.Add($"{id}:{hall}");
            }
            dataBase.CloseConnection();
        }
        //public void DateTimeComboBoxRefresh()
        //{
        //    dataBase.OpenConnection();
        //    string queryString = "SELECT id_film,date FROM film";
        //    SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
        //    SqlDataReader sqlDataReader = command.ExecuteReader();
        //    DateTimeComboBox.Items.Clear();
        //    while (sqlDataReader.Read())
        //    {
        //        int id = sqlDataReader.GetInt32(0);
        //        int date = sqlDataReader.GetInt32(1);
        //        DateTimeComboBox.Items.Add($"{id}:{date}");
        //    }
        //    dataBase.CloseConnection();
        //}

        private void FilmComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            baseField.Film = (check.SearchElementID(FilmComboBox.Text));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FilmComboBoxRefresh();
            HallComboBoxRefresh();
            ///DateTimeComboBoxRefresh();
        }
    }
}
