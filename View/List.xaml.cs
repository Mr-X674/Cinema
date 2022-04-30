using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace Cinema
{
    public partial class List : Window
    {
        public List()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=MSI-AEGIS-TI3;Initial Catalog=Cinema2.0;Integrated Security=True");
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            string cmd = "SELECT film.id_film,film.film,genre.genre,film.[date],film.years,hall.hall FROM film left join genre on genre.id_genre = film.genre left join hall on hall.id_hall = film.hall";
            SqlCommand createCommand = new SqlCommand(cmd, sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable table = new DataTable("film");
            dataAdp.Fill(table);
            ListGrid.ItemsSource = table.DefaultView;
            sqlConnection.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            string cmd = "SELECT * FROM hall";
            SqlCommand createCommand = new SqlCommand(cmd, sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable table = new DataTable("hall");
            dataAdp.Fill(table);
            ListGrid.ItemsSource = table.DefaultView;
            sqlConnection.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            string cmd = "SELECT * FROM genre";
            SqlCommand createCommand = new SqlCommand(cmd, sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable table = new DataTable("genre");
            dataAdp.Fill(table);
            ListGrid.ItemsSource = table.DefaultView;
            sqlConnection.Close();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            string cmd = "SELECT [session].id_seans,film.film,[session].price,film.[date],hall.hall FROM [session] left join film on film.id_film = [session].film left join hall on hall.id_hall = [session].hall";
            SqlCommand createCommand = new SqlCommand(cmd, sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable table = new DataTable("session");
            dataAdp.Fill(table);
            ListGrid.ItemsSource = table.DefaultView;
            sqlConnection.Close();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            string cmd = "SELECT ticket.id_ticket, film.film,film.date,hall.hall,ticket.number_rows,ticket.number_place FROM ticket left join film on film.id_film = ticket.film left join hall on hall.id_hall = ticket.hall";
            SqlCommand createCommand = new SqlCommand(cmd, sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable table = new DataTable("ticket");
            dataAdp.Fill(table);
            ListGrid.ItemsSource = table.DefaultView;
            sqlConnection.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            SaleTicket saleTicket = new SaleTicket();
            saleTicket.Show();
            this.Close();
        }
    }
}
