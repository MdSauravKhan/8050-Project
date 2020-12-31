using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace WPFDemo
{
    
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LQ43U8B\SQLEXPRESS;Initial Catalog=Customer;Integrated Security=True");
        public Booking()
        {
            InitializeComponent();
        }


        //Booking Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into customer values('" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Booking added Sucessfully");
        }

        //Packages Button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            this.Visibility = Visibility.Hidden;
            win1.Show();
        }

        //Cancel Booking
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from customer where ID = '" + TextBox5.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Booking Cancelled Sucessfully");
        }
    }
}
