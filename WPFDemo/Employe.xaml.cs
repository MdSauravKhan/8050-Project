using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for Employe.xaml
    /// </summary>
    public partial class Employe : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LQ43U8B\SQLEXPRESS;Initial Catalog=Booking;Integrated Security=True");
        public Employe()
        {
            InitializeComponent();
        }

       

        //Insert
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Booking values('" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + date.SelectedDate + "', '" + date2.SelectedDate + "', '" + TextBox3.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();            
            MessageBox.Show("Insert Sucessfully");
        }

       
        //Delete
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Booking where ID = '" + TextBox3.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Delete Sucessfully");
        }

        //Display
        private void Button_Click_2(object sender, RoutedEventArgs e)
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
                datagrid.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);



                con.Close();
            }
            catch(Exception)
            {
            }



        }

        //Home Buton
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow win0 = new MainWindow();
            this.Visibility = Visibility.Hidden;
            win0.Show();
        }
    }
}
