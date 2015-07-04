using System;
using System.Collections.Generic;
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
using UserControlLibrary;
using System.Data.SqlClient;
namespace DllTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Constr = @"Server=Ram;Database=Revised;Integrated Security=true";

       public SqlDataReader reader;

        public MainWindow()
        {
            InitializeComponent();
            LoadId();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new UserControlLibrary.DBConnection(Constr);

            int id = int.Parse(IdTextBox.Text);

            string name = NameTextBox.Text;

            string query=string.Format("insert into info values('{0}','{1}')", id ,name);

        
            string r = db.Insert(query);
            if (r != "Successfully Inserted")
            {
                MessageBox.Show(r, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(r);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var db = new UserControlLibrary.DBConnection(Constr);

            if (!db.Connect())
                MessageBox.Show("Database Connection Error");

            else
                MessageBox.Show("Database  Connected");
        
        }




        private string LoadId()
        {
            var db = new UserControlLibrary.DBConnection(Constr);

            string query = string.Format("select Id from info");

            db.Connect();

            reader=db.Select(query);


            while (reader.Read())
            {
                int sid = int.Parse(reader[0].ToString());

                IdBox.Items.Add(sid);
            }
        

           return "Good";
        }

        private void RibbonSplitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome","Error",MessageBoxButton.OK,MessageBoxImage.Error);

        }
    }
}
