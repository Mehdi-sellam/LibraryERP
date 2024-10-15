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
    public partial class form_register : Form
    {
        public form_register()
        {
            InitializeComponent();
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            // Get the connection string for the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";

            // Check that the username is not empty (so there will be no corrupted data in the database)
            if (string.IsNullOrWhiteSpace(text_username.Text))
            {
                MessageBox.Show("Please enter a valid username.");
                return;
            }

            // Check that the full name is not empty
            if (string.IsNullOrWhiteSpace(text_fullname.Text))
            {
                MessageBox.Show("Please enter a valid full name.");
                return;
            }

            // Check that the password is not empty
            if (string.IsNullOrWhiteSpace(text_password.Text))
            {
                MessageBox.Show("Please enter a valid password.");
                return;
            }

            // Check that the license ID number is not empty
            if (string.IsNullOrWhiteSpace(text_licenseidnumber.Text))
            {
                MessageBox.Show("Please enter a valid license ID number.");
                return;
            }

            // Check that the license ID number is a valid integer
            if (!int.TryParse(text_licenseidnumber.Text, out int licenseID))
            {
                MessageBox.Show("Please enter a valid license ID number.");
                return;
            }

            // Check if the username already exists in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Register WHERE User_Name = @UserName", connection);
                command.Parameters.AddWithValue("@UserName", text_username.Text);

                int userCount = (int)command.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                    return;
                }

                connection.Close();
            }

            // Open a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SQL command to insert data into the Register table
                SqlCommand command = new SqlCommand("INSERT INTO Register (User_Name, Full_Name, Password, Liecese_ID_Number) VALUES (@UserName, @FullName, @Password, @LicenseID)", connection);

                // Add parameter values for the SQL command
                command.Parameters.AddWithValue("@UserName", text_username.Text);
                command.Parameters.AddWithValue("@FullName", text_fullname.Text);
                command.Parameters.AddWithValue("@Password", text_password.Text);
                command.Parameters.AddWithValue("@LicenseID", licenseID);

                // Execute the SQL command to insert data into the Register table
                int rowsAffected = command.ExecuteNonQuery(); //(it returns number ())

                // Close the database connection
                connection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registration successful!");
                }
                else
                {
                    MessageBox.Show("Registration failed.");
                }

                // ...
            }

            // Display the login form and hide the registration form
            form_login form_register = new form_login();
            form_register.Show();
            this.Hide();
        }


        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_go_backto_login_Click(object sender, EventArgs e)
        {
            // Display the login form and hide the registration form
            form_login form_register = new form_login();
            form_register.Show();
            this.Hide();
        }
    }
}
