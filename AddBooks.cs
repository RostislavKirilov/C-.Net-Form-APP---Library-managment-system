using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagmentSystem
{
    public partial class AddBooks : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\35989\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");

        public AddBooks()
        {
            InitializeComponent();
            displayBooks();
            clearFields();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayBooks();
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }

        private void addBook_ImpBtn_Click(object sender, EventArgs e)
        {
            String imagePath = " ";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    addBooks_picture.ImageLocation = imagePath;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addBooks_btn_Click(object sender, EventArgs e)
        {
            if (addBooks_picture.Image == null
                || addBooks_Title.Text == ""
                || addBooks_Author.Text == ""
                || addBooks_Published.Value == null
                || addBooks_Status.Text == ""
                || addBooks_picture.Image == null)
            {
                MessageBox.Show("Моля, попълнете празните полета.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        DateTime today = DateTime.Today;
                        connect.Open();
                        String insertData = "INSERT INTO books " +
                            "(book_title, author, published_date, status, image, date_insert) " +
                            "VALUES(@Title, @Author, @Published, @Status, @Image, @DateInsert)";

                        string safeDate = today.ToString("yyyyMMdd");

                        string safeTitle = string.Join("_", addBooks_Title.Text.Split(Path.GetInvalidFileNameChars()));
                        string safeAuthor = string.Join("_", addBooks_Author.Text.Split(Path.GetInvalidFileNameChars()));

                        string path = Path.Combine(@"C:\Users\35989\Documents\LibraryManagmentSystem\Books_Directory",
                            $"{safeTitle}_{safeAuthor}_{safeDate}.jpg");

                        string directoryPath = Path.GetDirectoryName(path);
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        string imageLocation = addBooks_picture.ImageLocation;
                        if (string.IsNullOrWhiteSpace(imageLocation) || !File.Exists(imageLocation))
                        {
                            throw new FileNotFoundException("Image file not found", imageLocation);
                        }

                        File.Copy(imageLocation, path, true);

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@Title", addBooks_Title.Text.Trim());
                            cmd.Parameters.AddWithValue("@Author", addBooks_Author.Text.Trim());
                            cmd.Parameters.AddWithValue("@Published", addBooks_Published.Value.Date);
                            cmd.Parameters.AddWithValue("@Status", addBooks_Status.Text.Trim());
                            cmd.Parameters.AddWithValue("@image", path);
                            cmd.Parameters.AddWithValue("@DateInsert", today);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Успешно добавено!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayBooks();
                            clearFields();

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
        public void displayBooks()
        {
            try
            {
                DataAddBooks dab = new DataAddBooks();
                List<DataAddBooks> listData = dab.addBooksData();

                dataGridView1.DataSource = listData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на данни: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearFields()
        {
            addBooks_Title.Text = " ";
            addBooks_Author.Text = " ";
            addBooks_picture.Image = null;
            addBooks_Status.SelectedIndex = -1;
        }

        private int bookID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int id))
                {
                    bookID = id;
                    addBooks_Title.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                    addBooks_Author.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                    addBooks_Published.Value = DateTime.TryParse(row.Cells[3].Value?.ToString(), out DateTime publishedDate) ? publishedDate : DateTime.Today;
                    addBooks_Status.Text = row.Cells[5].Value?.ToString() ?? string.Empty;

                    string imagePath = row.Cells[4].Value?.ToString();
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        addBooks_picture.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        addBooks_picture.Image = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Невалиден индекс на ред.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void addBooks_ClearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addBooks_UpdateBtn_Click(object sender, EventArgs e)
        {
            if (addBooks_picture.Image == null
               || addBooks_Title.Text == ""
               || addBooks_Author.Text == ""
               || addBooks_Published.Value == null
               || addBooks_Status.Text == ""
               || addBooks_picture.Image == null)
            {
                MessageBox.Show("Моля, първо изберете.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    DialogResult check = MessageBox.Show("Сигурни ли сте, че искате да направите промяна " +
                        "на книга с номер: " + bookID + " ?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (check == DialogResult.Yes)
                    {
                        try
                        {
                            connect.Open();
                            DateTime today = DateTime.Today;
                            string UpdateData = "UPDATE books SET book_title = @Title, author = @Author, " +
                                                "published_date = @Published, status = @Status, " +
                                                "date_update = @DateUpdate WHERE id = @ID";

                            using (SqlCommand cmd = new SqlCommand(UpdateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@Title", addBooks_Title.Text.Trim());
                                cmd.Parameters.AddWithValue("@Author", addBooks_Author.Text.Trim());
                                cmd.Parameters.AddWithValue("@Published", addBooks_Published.Value);
                                cmd.Parameters.AddWithValue("@Status", addBooks_Status.Text.Trim());
                                cmd.Parameters.AddWithValue("@DateUpdate", today);
                                cmd.Parameters.AddWithValue("@ID", bookID);

                                cmd.ExecuteNonQuery();

                                displayBooks();
                                MessageBox.Show("Успешно обновено!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
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
                    else
                    {
                        MessageBox.Show("Операцията отказана.", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void addBooks_DeleteBtn_Click(object sender, EventArgs e)
        {
            if (addBooks_picture.Image == null
               || addBooks_Title.Text == ""
               || addBooks_Author.Text == ""
               || addBooks_Published.Value == null
               || addBooks_Status.Text == ""
               || addBooks_picture.Image == null)
            {
                MessageBox.Show("Моля, първо изберете.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    DialogResult check = MessageBox.Show("Сигурни ли сте, че искате да изтриете книга с номер " +
                         + bookID + " ?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (check == DialogResult.Yes)
                    {
                        try
                        {
                            connect.Open();
                            DateTime today = DateTime.Today;
                            string UpdateData = "UPDATE books SET date_delete = @dateDelete WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(UpdateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@dateDelete", today);
                                cmd.Parameters.AddWithValue("@id", bookID);


                                cmd.ExecuteNonQuery();

                                displayBooks();
                                MessageBox.Show("Успешно обновено!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
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
                    else
                    {
                        MessageBox.Show("Операцията отказана.", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }
    }
}
