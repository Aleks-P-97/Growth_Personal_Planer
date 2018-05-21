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
using System.Data.SQLite;

namespace Growth
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

        void CheckQuery(object sender, RoutedEventArgs e)
        {
            //In arrray - Name, type, 
            string createQuery = CreateTable("List", new string[] { "[StudentName]", " TEXT,", " [HourlyRate] ", "REAL, " });
            string select = Select("List");
            SQLiteConnection connection = new SQLiteConnection("Data Source=GrowthDB.db");
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(select, connection);
            command.ExecuteNonQuery();
            SQLiteDataReader reader = command.ExecuteReader();
            connection.Close();

            testTB.Text = reader.GetName(1);
        }


        string Select(string tableName)
        {
            string query = "SELECT * FROM [" + tableName + "];";

            return query;
        }

        string CreateTable(string tableName, string[] data)
        {
            string query = "CREATE TABLE [" + tableName + "]("; 
            query += "[Id] INTEGER NOT NULL,";

            foreach(string value in data)
            {
                query += value;
            }
            query += "CONSTRAINT [PK_"+ tableName + "] PRIMARY KEY ([Id])";
            query += ");"; //Query end

            return query;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            testTB.Text = "";
        }
    }
}
