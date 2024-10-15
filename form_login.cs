using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Library_Managment_System_VDW
{
    public partial class form_login : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";

        public form_login()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            // Check that the username and password are not empty
            if (string.IsNullOrWhiteSpace(text_username.Text))
            {
                MessageBox.Show("Please enter a valid username.");
                return;
            }

            if (string.IsNullOrWhiteSpace(text_password.Text))
            {
                MessageBox.Show("Please enter a valid password.");
                return;
            }

            // Query the database to check if the user exists and the password is correct
            string query = "SELECT COUNT(*) FROM Register WHERE User_Name=@username AND Password=@password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", text_username.Text);
                command.Parameters.AddWithValue("@password", text_password.Text);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Login successful
                        form_work_interface form_login = new form_work_interface();
                        form_login.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Login failed
                        MessageBox.Show("Invalid username or password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void link_register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form_register form_register = new form_register();
            form_register.Show();
            this.Hide();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }















    }
}
