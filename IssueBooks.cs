using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace LibraryManagmentSystem
{
    public partial class IssueBooks : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\35989\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");

        public IssueBooks()
        {
            InitializeComponent();
            DataBookTitle();
            displayBookIssueData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayBookIssueData();
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        public void displayBookIssueData()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string selectData = "SELECT issue_id, full_name, contact, email, book_title, author, issue_date, return_date, status FROM issues WHERE date_delete IS NULL";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void bookIssue_addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bookIssue_id.Text) ||
                string.IsNullOrEmpty(bookIssue_name.Text) ||
                string.IsNullOrEmpty(bookIssue_contact.Text) ||
                string.IsNullOrEmpty(bookIssue_email.Text) ||
                string.IsNullOrEmpty(bookIssue_author.Text) ||
                bookIssue_issueDate.Value == null ||
                bookIssue_returnDate.Value == null ||
                string.IsNullOrEmpty(bookIssue_status.Text) ||
                bookIssue_picture.Image == null)
            {
                MessageBox.Show("Моля, попълнете празните полета.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        DateTime today = DateTime.Today;
                        connect.Open();
                        string insertData = "INSERT INTO issues (issue_id, full_name, contact, email, book_title, author, status, issue_date, return_date, date_insert) " +
                                            "VALUES (@issueID, @fullname, @contact, @email, @booktitle, @author, @status, @issueDate, @returnDate, @dateInsert)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@issueID", bookIssue_id.Text.Trim());
                            cmd.Parameters.AddWithValue("@fullname", bookIssue_name.Text.Trim());
                            cmd.Parameters.AddWithValue("@contact", bookIssue_contact.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", bookIssue_email.Text.Trim());
                            cmd.Parameters.AddWithValue("@booktitle", bookIssue_bookTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@author", bookIssue_author.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", bookIssue_status.Text.Trim());
                            cmd.Parameters.AddWithValue("@issueDate", bookIssue_issueDate.Value);
                            cmd.Parameters.AddWithValue("@returnDate", bookIssue_returnDate.Value);
                            cmd.Parameters.AddWithValue("@dateInsert", today);

                            cmd.ExecuteNonQuery();
                            displayBookIssueData();

                            MessageBox.Show("Успешна операция!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        public void clearFields()
        {
            bookIssue_id.Text = "";
            bookIssue_name.Text = "";
            bookIssue_contact.Text = "";
            bookIssue_email.Text = "";
            bookIssue_bookTitle.SelectedIndex = -1;
            bookIssue_author.SelectedIndex = -1;
            bookIssue_issueDate.Value = DateTime.Now;
            bookIssue_returnDate.Value = DateTime.Now;
            bookIssue_status.SelectedIndex = -1;
            bookIssue_picture.Image = null;
        }

        public void DataBookTitle()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string selectData = "SELECT * FROM books WHERE status = 'Available' AND date_delete IS NULL";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    bookIssue_bookTitle.DataSource = table;
                    bookIssue_bookTitle.DisplayMember = "book_title";
                    bookIssue_bookTitle.ValueMember = "id";
                }

                if (bookIssue_bookTitle.Items.Count > 0)
                {
                    bookIssue_bookTitle.SelectedIndex = 0;
                    LoadSelectedBookImage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void bookIssue_bookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedBookImage();
        }

        private void LoadSelectedBookImage()
        {
            if (bookIssue_bookTitle.SelectedValue != null)
            {
                if (bookIssue_bookTitle.SelectedValue is DataRowView dataRowView)
                {
                    int selectID = Convert.ToInt32(dataRowView["id"]);
                    LoadBookImage(selectID);
                }
                else if (bookIssue_bookTitle.SelectedValue is int selectID)
                {
                    LoadBookImage(selectID);
                }
            }
        }

        private void LoadBookImage(int bookID)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string selectData = "SELECT * FROM books WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@id", bookID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        bookIssue_author.DataSource = table;
                        bookIssue_author.DisplayMember = "author";
                        bookIssue_author.ValueMember = "id";

                        string getImage = table.Rows[0]["image"].ToString();

                        if (!string.IsNullOrEmpty(getImage) && File.Exists(getImage))
                        {
                            bookIssue_picture.Image = Image.FromFile(getImage);
                            bookIssue_picture.Tag = getImage;  // Store image path in Tag property
                        }
                        else
                        {
                            bookIssue_picture.Image = null;
                            bookIssue_picture.Tag = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                bookIssue_id.Text = row.Cells["issue_id"].Value?.ToString() ?? string.Empty;
                bookIssue_name.Text = row.Cells["full_name"].Value?.ToString() ?? string.Empty;
                bookIssue_contact.Text = row.Cells["contact"].Value?.ToString() ?? string.Empty;
                bookIssue_email.Text = row.Cells["email"].Value?.ToString() ?? string.Empty;
                bookIssue_bookTitle.Text = row.Cells["book_title"].Value?.ToString() ?? string.Empty;
                bookIssue_author.Text = row.Cells["author"].Value?.ToString() ?? string.Empty;
                bookIssue_issueDate.Text = row.Cells["issue_date"].Value?.ToString() ?? string.Empty;
                bookIssue_returnDate.Text = row.Cells["return_date"].Value?.ToString() ?? string.Empty;
                bookIssue_status.Text = row.Cells["status"].Value?.ToString() ?? string.Empty;
            }
        }

        private void bookIssue_updateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bookIssue_id.Text) ||
                 string.IsNullOrEmpty(bookIssue_name.Text) ||
                 string.IsNullOrEmpty(bookIssue_contact.Text) ||
                 string.IsNullOrEmpty(bookIssue_email.Text) ||
                 string.IsNullOrEmpty(bookIssue_author.Text) ||
                 bookIssue_issueDate.Value == null ||
                 bookIssue_returnDate.Value == null ||
                 string.IsNullOrEmpty(bookIssue_status.Text) ||
                 bookIssue_picture.Image == null)
            {
                MessageBox.Show("Моля, първо изберете.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                DialogResult check = MessageBox.Show("Сигурни ли сте, че искате да направите промяна " +
                    "на книга с номер: " + bookIssue_id.Text + " ?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        DateTime today = DateTime.Today;
                        string updateData = "UPDATE issues SET full_name = @fullName, contact = @contact," +
                            "email = @email, book_title = @bookTitle, author = @author, status = @status," +
                            "issue_date = @issueDate, return_date = @returnDate, date_update = @dateUpdate " +
                            "WHERE issue_id = @issueID";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@fullName", bookIssue_name.Text.Trim());
                            cmd.Parameters.AddWithValue("@contact", bookIssue_contact.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", bookIssue_email.Text.Trim());
                            cmd.Parameters.AddWithValue("@bookTitle", bookIssue_bookTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@author", bookIssue_author.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", bookIssue_status.Text.Trim());
                            cmd.Parameters.AddWithValue("@issueDate", bookIssue_issueDate.Value);
                            cmd.Parameters.AddWithValue("@returnDate", bookIssue_returnDate.Value);
                            cmd.Parameters.AddWithValue("@dateUpdate", today);
                            cmd.Parameters.AddWithValue("@issueID", bookIssue_id.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                displayBookIssueData();
                                MessageBox.Show("Успешна операция!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                            else
                            {
                                MessageBox.Show("Не е намерен запис с този ID.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else
                {
                    MessageBox.Show("Операцията отказана.", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bookIssue_deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bookIssue_id.Text) ||
                string.IsNullOrEmpty(bookIssue_name.Text) ||
                string.IsNullOrEmpty(bookIssue_contact.Text) ||
                string.IsNullOrEmpty(bookIssue_email.Text) ||
                string.IsNullOrEmpty(bookIssue_author.Text) ||
                bookIssue_issueDate.Value == null ||
                bookIssue_returnDate.Value == null ||
                string.IsNullOrEmpty(bookIssue_status.Text) ||
                bookIssue_picture.Image == null)
            {
                MessageBox.Show("Моля, първо изберете.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                DialogResult check = MessageBox.Show(
                    $"Сигурни ли сте, че искате да изтриете книга с номер {bookIssue_id.Text.Trim()} ?",
                    "Confirmation message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        DateTime today = DateTime.Today;
                        string UpdateData = "UPDATE issues SET date_delete = @dateDelete WHERE issue_id = @issueID";

                        using (SqlCommand cmd = new SqlCommand(UpdateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@dateUpdate", today);
                            cmd.Parameters.AddWithValue("@issueID", bookIssue_id.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayBookIssueData();
                            MessageBox.Show("Успешно изтрито!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
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
                else
                {
                    MessageBox.Show("Операцията отказана.", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bookIssue_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}

