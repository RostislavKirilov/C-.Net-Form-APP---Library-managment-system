using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagmentSystem
{
    internal class DataAddBooks
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\35989\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");
        public int ID {  get; set; }  
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Published { get; set; }
        public string image { get; set; }
        public string status { get; set; }

        public List<DataAddBooks> addBooksData()
        {
            List<DataAddBooks> listData = new List<DataAddBooks> ();
            if(connect.State != ConnectionState.Open) {

                try
                {
                    connect.Open();


                    string selectData = "SELECT * FROM books WHERE date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();


                        while (reader.Read())
                        {
                            DataAddBooks dab = new DataAddBooks();
                            dab.ID = (int)reader["id"];
                            dab.BookTitle = reader["book_title"].ToString();
                            dab.Author = reader["author"].ToString();
                            dab.Published = reader["published_date"].ToString();
                            dab.image = reader["image"].ToString();
                            dab.status = reader["status"].ToString();

                            listData.Add(dab);

                        }
                        reader.Close(); 

                    }

                }
                catch(Exception ex) 
                {
                    Console.WriteLine("Грешка при свързването с базата данни:" + ex);
                }
                finally
                {
                    connect.Close ();   
                }
            
            }
            return listData;
        }
    }
}
