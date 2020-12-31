using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LQ43U8B\SQLEXPRESS;Initial Catalog=Booking;Integrated Security=True");
        public Window1()
        {
            InitializeComponent();
        }
        // Displaying Packages
        [Obsolete]
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                String query = "Select RoomType, Price, AvailableDate, EndDate, ID FROM Booking";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("Booking");
                dataAdp.Fill(dt);
                data.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);



                con.Close();
            }
            catch (Exception)
            {
            }
        }

        //BAck to Home page
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow win0 = new MainWindow();
            this.Visibility = Visibility.Hidden;
            win0.Show();
        }

        //Booking Button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Booking book = new Booking();
            this.Visibility = Visibility.Hidden;
            book.Show();
        }
    }
}
