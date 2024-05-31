using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagmentSystem
{
    public partial class Dashboard : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\35989\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");
        Timer refreshTimer;

        public Dashboard()
        {
            InitializeComponent();
            InitializeTimer();
            displayAB();
            displayIB();
            displayRB();
        }

        private void InitializeTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 10000; 
            refreshTimer.Tick += new EventHandler(RefreshDashboard);
            refreshTimer.Start();
        }

        private void RefreshDashboard(object sender, EventArgs e)
        {
            displayAB();
            displayIB();
            displayRB();
        }

        public void displayAB()
        {
            UpdateDashboardLabel("SELECT COUNT(id) FROM books WHERE status = 'Available' AND date_delete IS NULL", dashboard_AB);
        }

        public void displayIB()
        {
            UpdateDashboardLabel("SELECT COUNT(id) FROM issues WHERE date_delete IS NULL", dashboard_IB);
        }

        public void displayRB()
        {
            UpdateDashboardLabel("SELECT COUNT(id) FROM issues WHERE status = 'Return' AND date_delete IS NULL", dashboard_RB);
        }

        private void UpdateDashboardLabel(string query, Label label)
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            label.Text = count.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }
    }
}
