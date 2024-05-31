using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace LibraryManagmentSystem
{
    public partial class RegisterForm : Form
    {

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\35989\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void signIn_btn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();  
            loginForm.ShowDialog();
            this.Hide();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            if (register_email.Text == "" || register_username.Text == "" || register_pass.Text == "")
            {
                MessageBox.Show("Моля, попълнете всички полета, за да се регистрирате!", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(connect.State != ConnectionState.Open)
                { 
                    try
                    {
                        connect.Open();
                        String checkUsername = "SELECT COUNT(*) FROM users WHERE username = @username";

                        using (SqlCommand CheckCMD = new SqlCommand(checkUsername, connect))
                        { 
                            CheckCMD.Parameters.AddWithValue("username", register_username.Text.Trim());
                            int count = (int)CheckCMD.ExecuteScalar();
                            if(count >= 1) 
                            {
                                MessageBox.Show(register_username.Text.Trim() + 
                                    " е вече заето.", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           }
                            else
                            {
                                //Да вземем сегашния ден 
                                DateTime day = DateTime.Today;
                                String insertData = "INSERT INTO users (email, username, password)" +
                                    "VALUES(@email, @username, @password)";

                                using (SqlCommand insertCMD = new SqlCommand(insertData, connect))
                                { 
                                    insertCMD.Parameters.AddWithValue("@email", register_email.Text.Trim());
                                    insertCMD.Parameters.AddWithValue("@username", register_username.Text.Trim());
                                    insertCMD.Parameters.AddWithValue("@password", register_pass.Text.Trim());
                                    insertCMD.Parameters.AddWithValue("@date", day.ToString());
                                    insertCMD.ExecuteNonQuery();

                                    MessageBox.Show("Регистрацията е успешна!", "Information Message", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Information    );

                                    LoginForm loginForm = new LoginForm();
                                    loginForm.Show();
                                    this.Hide();


                                }
                            }

                        }

                    }catch(Exception ex)
                    {
                        MessageBox.Show("Грешка при свързването с базата данни: " + ex, "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        connect.Close();    
                    }
                }
            }
        }

        private void register_showPass_CheckedChanged(object sender, EventArgs e)
        {
            register_pass.PasswordChar = register_showPass.Checked ? '\0' : '*';
        }
    }
}
