using System.Windows;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        //Calling Window1------- Display Packages for customers
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Window1 win1 = new Window1();
            this.Visibility = Visibility.Hidden;
            win1.Show();
            
        }

       
        //Calling Employee window to make packages
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Employe win2 = new Employe();
            this.Visibility = Visibility.Hidden;
            win2.Show();
        }
    }
}
