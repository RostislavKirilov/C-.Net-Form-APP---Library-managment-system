using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagmentSystem
{
    public partial class ReturnBooks : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\35989\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");

        public ReturnBooks()
        {
            InitializeComponent();
            displayIssuedBooksData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayIssuedBooksData();
        }

        private void ReturnBooks_Load(object sender, EventArgs e)
        {

        }

        public void displayIssuedBooksData()
        {
            DataIssueBooks dib = new DataIssueBooks();
            List<DataIssueBooks> listData = dib.ReturnIssuedBooksData();

            dataGridView1.DataSource = listData;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                returnBook_issueID.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                returnBooks_name.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                returnBooks_contact.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
                returnBooks_email.Text = row.Cells[4].Value?.ToString() ?? string.Empty;
                returnBooks_bookTitle.Text = row.Cells[5].Value?.ToString() ?? string.Empty;
                returnBooks_author.Text = row.Cells[6].Value?.ToString() ?? string.Empty;
                returnBooks_issueDate.Text = row.Cells[7].Value?.ToString() ?? string.Empty;
            }
        }

        private void returnBooks(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(returnBook_issueID.Text)
                || string.IsNullOrEmpty(returnBooks_name.Text)
                || string.IsNullOrEmpty(returnBooks_contact.Text)
                || string.IsNullOrEmpty(returnBooks_bookTitle.Text)
                || string.IsNullOrEmpty(returnBooks_author.Text)
                || returnBooks_issueDate.Value == null)
            {
                MessageBox.Show("Моля, първо изберете книгата.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    DialogResult check = MessageBox.Show("Сигурни ли сте, че книга с ID: " +
                        returnBook_issueID.Text.Trim() + " е върната обратно?", "Confirmation Message",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (check == DialogResult.Yes)
                    {
                        try
                        {
                            DateTime today = DateTime.Today;
                            connect.Open();

                            string updateData = "UPDATE issues SET status = 'Return', date_update = @dateUpdate " +
                                "WHERE issue_id = @issueID";

                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@status", "Return");
                                cmd.Parameters.AddWithValue("@dateUpdate", today);
                                cmd.Parameters.AddWithValue("@issueID", returnBook_issueID.Text);

                                cmd.ExecuteNonQuery();
                                displayIssuedBooksData();

                                MessageBox.Show("Успешно върната.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ClearFields();

                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Грешка: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }

            }
        }

        private void returnBooks_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            returnBook_issueID.Text = "";
            returnBooks_name.Text = "";
            returnBooks_contact.Text = "";
            returnBooks_email.Text = "";
            returnBooks_bookTitle.Text = "";
            returnBooks_author.Text = "";
        }
    }
}
