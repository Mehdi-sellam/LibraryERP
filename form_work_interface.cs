using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Managment_System_VDW
{
    public partial class form_work_interface : Form
    {
        //public static string con1234 = "x";
        //form_nmae.con1234
        public form_work_interface()
        {
            InitializeComponent();
        }

        private void button_bookmanagement_Click(object sender, EventArgs e)
        {
            panel_book.Visible = true;
            panel_client.Visible = false;
            panel_borrow_book.Visible = false;

            try
            {
                // Open the connection
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    connection.Open();

                    // Create the command to select all books
                    SqlCommand command = new SqlCommand("SELECT * FROM Book", connection);

                    // Create a data adapter and fill the data set
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    // Set the data source of the data grid view to the data set
                    dataGridView_books.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button_clientshandling_Click(object sender, EventArgs e)
        {
            panel_book.Visible = false;
            panel_client.Visible = true;
            panel_borrow_book.Visible = false;

            try
            {
                // Open the connection
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    connection.Open();

                    // Create the command to select all books
                    SqlCommand command = new SqlCommand("SELECT * FROM Client", connection);

                    // Create a data adapter and fill the data set
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    // Set the data source of the data grid view to the data set
                    dataGridView_client.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button_stuffcontrol_Click(object sender, EventArgs e)
        {
            panel_book.Visible = false;
            panel_client.Visible = false;
            panel_borrow_book.Visible = true;

            try
            {
                // Open the connection
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    connection.Open();

                    // Create the command to select all books
                    SqlCommand command = new SqlCommand("SELECT * FROM Borrow", connection);

                    // Create a data adapter and fill the data set
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    // Set the data source of the data grid view to the data set
                    dataGridView_borrow_book.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void link_logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form_login form_work_interface = new form_login();
            form_work_interface.Show();
            this.Hide();
        }

        private void form_work_interface_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet2.Register' table. You can move, or remove it, as needed.
            this.registerTableAdapter.Fill(this.databaseDataSet2.Register);
            // TODO: This line of code loads data into the 'databaseDataSet1.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.databaseDataSet1.Client);
            // TODO: This line of code loads data into the 'databaseDataSet.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.databaseDataSet.Book);

        }


        private void button_add_book_Click(object sender, EventArgs e)
        {
            string bookref = text_book_ref.Text;
            string bookName = text_bookname.Text;
            string gener = comboBox_book_gener.Text;
            string language = comboBox_book_language.Text;
            string author = text_author.Text;
            string shelf = comboBox_book_shell.Text;
            string availability = comboBox_availability.Text;

            // Check if any fields are blank
            if (string.IsNullOrWhiteSpace(bookName) ||
                string.IsNullOrWhiteSpace(bookref) ||
                string.IsNullOrWhiteSpace(gener) ||
                string.IsNullOrWhiteSpace(language) ||
                string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(shelf) ||
                string.IsNullOrWhiteSpace(availability))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            // Check if the entered book reference already exists in the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Book WHERE Book_Ref=@bookRef";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@bookRef", bookref);
                if (dataGridView_books.CurrentRow != null && dataGridView_books.CurrentRow.Cells[0].Value != null)
                {
                    checkCommand.Parameters.AddWithValue("@bookRef2", dataGridView_books.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    checkCommand.Parameters.AddWithValue("@bookRef2", "-1");
                }
                int matchingBookCount = (int)checkCommand.ExecuteScalar();
                if (matchingBookCount > 0)
                {
                    MessageBox.Show("A book with this reference already exists in the database.");
                    return;
                }
            }



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Book (Book_Name, Gener, Language, Author, Shelf, Availability, Book_Ref) VALUES (@BookName, @Gener, @Language, @Author, @Shelf, @Availability, @bookref)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bookref", bookref);
                    command.Parameters.AddWithValue("@BookName", bookName);
                    command.Parameters.AddWithValue("@Gener", gener);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@Author", author);
                    command.Parameters.AddWithValue("@Shelf", shelf);
                    command.Parameters.AddWithValue("@Availability", availability);

                    connection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Book added successfully.");

                        RefreshBookReferenceComboBox();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add book.");
                    }
                }
            }

            // Update the DataGridView to show the new data
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Book";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView_books.DataSource = dataTable;
                }
            }
        }



        private void dataGridView_books_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Open the connection
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    connection.Open();

                    // Create the command to select all books
                    SqlCommand command = new SqlCommand("SELECT * FROM Book", connection);

                    // Create a data adapter and fill the data set
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    // Set the data source of the data grid view to the data set
                    dataGridView_books.DataSource = dataSet.Tables[0];
                    dataGridView_books.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_books.Rows[e.RowIndex];
                text_book_ref.Text = row.Cells["Book_Ref"].Value.ToString();
                text_bookname.Text = row.Cells["Book_Name"].Value.ToString();
                comboBox_book_gener.Text = row.Cells["Gener"].Value.ToString();
                comboBox_book_language.Text = row.Cells["Language"].Value.ToString();
                text_author.Text = row.Cells["Author"].Value.ToString();
                comboBox_book_shell.Text = row.Cells["Shelf"].Value.ToString();
                comboBox_availability.Text = row.Cells["Availability"].Value.ToString();

                button_update_book.Enabled = true;
            }
        }






















        private void RefreshBookReferenceComboBox()
        {
            // Get the current selected item in the combo box
            string selectedValue = comboBox_bookref.SelectedItem?.ToString();

            // Populate the combo box with book reference values from the database
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
            {
                string query = "SELECT Book_Ref FROM Book";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Set the data source of the combo box to the DataTable object
                    comboBox_bookref.DataSource = table;

                    // Set the DisplayMember and ValueMember properties of the combo box
                    comboBox_bookref.DisplayMember = "Book_Ref";
                    comboBox_bookref.ValueMember = "Book_Ref";
                }
            }

            // Restore the previously selected value, if any
            if (selectedValue != null && comboBox_bookref.Items.Contains(selectedValue))
            {
                comboBox_bookref.SelectedItem = selectedValue;
            }
        }


















        private void button_update_book_Click(object sender, EventArgs e)
        {
            string bookRef = text_book_ref.Text;
            string bookName = text_bookname.Text;
            string gener = comboBox_book_gener.Text;
            string language = comboBox_book_language.Text;
            string author = text_author.Text;
            string shelf = comboBox_book_shell.Text;
            string availability = comboBox_availability.Text;

            // Check if any fields are empty
            if (string.IsNullOrEmpty(bookRef) || string.IsNullOrEmpty(bookName) || string.IsNullOrEmpty(gener) ||
                string.IsNullOrEmpty(language) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(shelf) ||
                string.IsNullOrEmpty(availability))
            {
                MessageBox.Show("Please fill in all fields before updating the book.");
                return;
            }

            // Check if the entered book reference already exists in the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Book WHERE Book_Ref=@bookRef AND Book_ID<>@bookID";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@bookRef", bookRef);
                checkCommand.Parameters.AddWithValue("@bookID", dataGridView_books.CurrentRow.Cells[0].Value.ToString());
                int matchingBookCount = (int)checkCommand.ExecuteScalar();
                if (matchingBookCount > 0)
                {
                    MessageBox.Show("A book with this reference already exists in the database.");
                    return;
                }
            }

            // Update the book record in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Define the SQL UPDATE statement
                string updateQuery = "UPDATE Book SET Book_Name=@bookName, Gener=@gener, Language=@language, " +
                                     "Author=@author, Shelf=@shelf, Availability=@availability, " +
                                     "Book_Ref=@bookRef WHERE Book_ID=@bookID";

                // Create a SqlCommand object with the update query and connection
                SqlCommand command = new SqlCommand(updateQuery, connection);

                // Add parameter values to the SqlCommand object
                command.Parameters.AddWithValue("@bookName", bookName);
                command.Parameters.AddWithValue("@gener", gener);
                command.Parameters.AddWithValue("@language", language);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@shelf", shelf);
                command.Parameters.AddWithValue("@availability", availability);
                command.Parameters.AddWithValue("@bookRef", bookRef);
                command.Parameters.AddWithValue("@bookID", dataGridView_books.CurrentRow.Cells[0].Value.ToString());

                // Execute the SQL command
                command.ExecuteNonQuery();

                // Close the database connection
                connection.Close();
            }

            // Clear the text boxes and disable the Update button
            text_book_ref.Text = "";
            text_bookname.Text = "";
            comboBox_book_gener.Text = "";
            comboBox_book_language.Text = "";
            text_author.Text = "";
            comboBox_book_shell.Text = "";
            comboBox_availability.Text = "";

            button_update_book.Enabled = false;

            // Update the DataGridView to show the new data
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Book";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView_books.DataSource = dataTable;
                }
            }
        }


        private void button_delete_book_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";

            // First, check if a row is selected in the DataGridView
            if (dataGridView_books.SelectedRows.Count > 0)
            {
                // Then, confirm with the user that they want to delete the row
                DialogResult result = MessageBox.Show("Are you sure you want to delete this book?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Call the code to delete the row from the database and the DataGridView
                    int rowIndex = dataGridView_books.SelectedRows[0].Index;
                    int bookID = Convert.ToInt32(dataGridView_books.Rows[rowIndex].Cells["Book_ID"].Value);
                    string query = "DELETE FROM Book WHERE Book_ID = @bookID";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@bookID", bookID);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            dataGridView_books.Rows.RemoveAt(rowIndex);
                            MessageBox.Show("Book deleted successfully!");
                            RefreshBookReferenceComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete book. Please try again.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.");
            }
        }

        private void button_clear_book_Click(object sender, EventArgs e)
        {
            if (dataGridView_books.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView_books.SelectedRows[0];
                int bookId = Convert.ToInt32(row.Cells["Book_ID"].Value);
                string bookRef = row.Cells["Book_Ref"].Value.ToString();

                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    string query = "UPDATE Book SET Book_Name = '', Gener = '', Language = '', Author = '', Shelf = '', Availability = '' WHERE Book_ID = @bookId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@bookId", bookId);

                        connection.Open();

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Book data cleared successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to clear book data.");
                        }
                    }
                }

                // Update the DataGridView to show the updated data
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    string query = "SELECT * FROM Book";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView_books.DataSource = dataTable;
                    }
                }

                text_bookname.Clear();
                comboBox_book_gener.SelectedIndex = -1;
                comboBox_book_language.SelectedIndex = -1;
                text_author.Clear();
                comboBox_book_shell.SelectedIndex = -1;
                comboBox_availability.SelectedIndex = -1;


                // Set the Book_Ref text box to the value of the Book_Ref column in the selected row
                text_book_ref.Text = bookRef;
            }
            else
            {
                MessageBox.Show("Please select a row to clear.");
            }
        }

        private void dataGridView_clients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button_add_client_Click(object sender, EventArgs e)
        {
            string clientName = text_fullname_client.Text;
            string phoneNumber = text_phone_number.Text;
            string emailAddress = text_email_address.Text;
            string clientRef = text_client_ref.Text;

            // Check if any fields are blank
            if (string.IsNullOrWhiteSpace(clientName) ||
                string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(emailAddress) ||
                string.IsNullOrWhiteSpace(clientRef))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }


            // Check if the entered book reference already exists in the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Client WHERE Client_Ref=@clientRef";

                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@clientRef", clientRef);
                if (dataGridView_client.CurrentRow != null && dataGridView_client.CurrentRow.Cells[0].Value != null)
                {
                    checkCommand.Parameters.AddWithValue("@ClientID", dataGridView_client.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    checkCommand.Parameters.AddWithValue("@ClientID", "-1");
                }
                int matchingBookCount = (int)checkCommand.ExecuteScalar();
                if (matchingBookCount > 0)
                {
                    MessageBox.Show("A Cleint with this reference already exists in the database.");
                    return;
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Client (Full_Name, Phone_Number, Email_Address, Client_Ref) VALUES (@clientName, @phoneNumber, @emailAddress, @clientRef)";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@clientName", clientName);
                    command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@emailAddress", emailAddress);
                    command.Parameters.AddWithValue("@clientRef", clientRef);


                    connection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Client added successfully.");

                        RefreshClientReferenceComboBox();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add Client.");
                    }
                }
            }

            // Update the DataGridView to show the new data
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Client";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView_client.DataSource = dataTable;
                }
            }
        }




        private void dataGridView_client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Open the connection
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    connection.Open();

                    // Create the command to select all books
                    SqlCommand command = new SqlCommand("SELECT * FROM Client", connection);

                    // Create a data adapter and fill the data set
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    // Set the data source of the data grid view to the data set
                    dataGridView_client.DataSource = dataSet.Tables[0];
                    dataGridView_client.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_client.Rows[e.RowIndex];
                text_client_ref.Text = row.Cells["Client_Ref"].Value.ToString();
                text_fullname_client.Text = row.Cells["Full_Name"].Value.ToString();
                text_phone_number.Text = row.Cells["Phone_Number"].Value.ToString();
                text_email_address.Text = row.Cells["Email_Address"].Value.ToString();


                button_update_client.Enabled = true;
            }

        }













        private void RefreshClientReferenceComboBox()
        {
            // Get the current selected item in the combo box
            string selectedValue = comboBox_clientref.SelectedItem?.ToString();

            // Populate the combo box with client reference values from the database
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
            {
                string query = "SELECT Client_Ref FROM Client";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Set the data source of the combo box to the DataTable object
                    comboBox_clientref.DataSource = table;

                    // Set the DisplayMember and ValueMember properties of the combo box
                    comboBox_clientref.DisplayMember = "Client_Ref";
                    comboBox_clientref.ValueMember = "Client_Ref";
                }
            }

            // Restore the previously selected value, if any
            if (selectedValue != null && comboBox_clientref.Items.Contains(selectedValue))
            {
                comboBox_clientref.SelectedItem = selectedValue;
            }
        }

















        private void button_update_client_Click(object sender, EventArgs e)
        {
            string fullName = text_fullname_client.Text;
            string phoneNumber = text_phone_number.Text;
            string emailAddress = text_email_address.Text;
            string clientRef = text_client_ref.Text;

            // Check if any fields are empty
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(emailAddress) ||
                string.IsNullOrEmpty(clientRef))
            {
                MessageBox.Show("Please fill in all fields before updating the client.");
                return;
            }

            // Check if the entered client reference already exists in the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Client WHERE Client_Ref=@clientRef AND Client_ID<>@clientID";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@clientRef", clientRef);
                checkCommand.Parameters.AddWithValue("@clientID", dataGridView_client.CurrentRow.Cells[0].Value.ToString());
                int matchingClientCount = (int)checkCommand.ExecuteScalar();
                if (matchingClientCount > 0)
                {
                    MessageBox.Show("A client with this reference already exists in the database.");
                    return;
                }
            }

            // Update the client record in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Define the SQL UPDATE statement
                string updateQuery = "UPDATE Client SET Full_Name=@fullName, Phone_Number=@phoneNumber, " +
                                     "Email_Address=@emailAddress, Client_Ref=@clientRef WHERE Client_ID=@clientID";

                // Create a SqlCommand object with the update query and connection
                SqlCommand command = new SqlCommand(updateQuery, connection);

                // Add parameter values to the SqlCommand object
                command.Parameters.AddWithValue("@fullName", fullName);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@emailAddress", emailAddress);
                command.Parameters.AddWithValue("@clientRef", clientRef);
                command.Parameters.AddWithValue("@clientID", dataGridView_client.CurrentRow.Cells[0].Value.ToString());

                // Execute the SQL command
                command.ExecuteNonQuery();

                // Close the database connection
                connection.Close();
            }

            // Clear the text boxes and disable the Update button
            text_fullname_client.Text = "";
            text_phone_number.Text = "";
            text_email_address.Text = "";
            text_client_ref.Text = "";

            button_update_client.Enabled = false;

            // Update the DataGridView to show the new data
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Client";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView_client.DataSource = dataTable;
                }
            }
        }


        private void button_delete_client_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";

            // First, check if a row is selected in the DataGridView
            if (dataGridView_client.SelectedRows.Count > 0)
            {
                // Then, confirm with the user that they want to delete the row
                DialogResult result = MessageBox.Show("Are you sure you want to delete this client?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Call the code to delete the row from the database and the DataGridView
                    int rowIndex = dataGridView_client.SelectedRows[0].Index;
                    int clientid = Convert.ToInt32(dataGridView_client.Rows[rowIndex].Cells["Client_ID"].Value);
                    string query = "DELETE FROM Client WHERE Client_ID=@clientid";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clientid", clientid);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            dataGridView_client.Rows.RemoveAt(rowIndex);
                            MessageBox.Show("client deleted successfully!");

                            RefreshClientReferenceComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete client. Please try again.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a client to delete.");
            }
        }

        private void button_clear_client_Click(object sender, EventArgs e)
        {
            if (dataGridView_client.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView_client.SelectedRows[0];
                int clientId = Convert.ToInt32(row.Cells["Client_ID"].Value);
                string clientRef = row.Cells["Client_Ref"].Value.ToString();

                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    string query = "UPDATE Client SET Full_Name = '', Phone_Number = '', Email_Address = '' WHERE Client_ID = @clientId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clientId", clientId);

                        connection.Open();

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Client data cleared successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to clear client data.");
                        }
                    }
                }

                // Update the DataGridView to show the updated data
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    string query = "SELECT * FROM Client";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView_client.DataSource = dataTable;
                    }
                }

                // Clear the text boxes
                text_fullname_client.Clear();
                text_phone_number.Clear();
                text_email_address.Clear();

                // Set the Client_Ref text box to the value of the Client_Ref column in the selected row
                text_client_ref.Text = clientRef;
            }
            else
            {
                MessageBox.Show("Please select a row to clear.");
            }
        }

        private void comboBox_bookref_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_add_borrowing_Click(object sender, EventArgs e)
        {
            string bookRef = comboBox_bookref.Text;
            string clientRef = comboBox_clientref.Text;
            string userName = comboBox_username.Text;
            DateTime borrowingDate = dateTimePicker_borrowing_date.Value;
            DateTime dueDate = dateTimePicker_due_date.Value;

            // Check if any fields are blank
            if (string.IsNullOrWhiteSpace(bookRef) ||
                string.IsNullOrWhiteSpace(clientRef) ||
                string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Check if the book is available
            int availableBookCount = 0; // Initialize to 0 to avoid using an uninitialized variable
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Book WHERE Book_Ref=@bookRef AND Availability='Available'";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@bookRef", bookRef);
                availableBookCount = (int)checkCommand.ExecuteScalar();
                if (availableBookCount == 0)
                {
                    MessageBox.Show("The book is not available in the library.");
                    return;
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Borrow (Book_Ref, Client_Ref, User_Name, Borrowing_Date, Due_Date) VALUES (@BookRef, @ClientRef, @UserName, @BorrowingDate, @DueDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookRef", bookRef);
                    command.Parameters.AddWithValue("@ClientRef", clientRef);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@BorrowingDate", borrowingDate);
                    command.Parameters.AddWithValue("@DueDate", dueDate);

                    connection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // Update the Availability column in the Book table
                        string updateQuery = "UPDATE Book SET Availability='Taken' WHERE Book_Ref=@bookRef";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@bookRef", bookRef);
                        updateCommand.ExecuteNonQuery();

                        // Update the DataGridView to show the new data
                        string selectQuery = "SELECT * FROM Borrow";

                        using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView_borrow_book.DataSource = dataTable;
                        }

                        MessageBox.Show("Borrowing order added successfully.");

                        RefreshBookReferenceComboBox();
                        RefreshClientReferenceComboBox();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add borrowing order.");
                    }
                }
            }
        }



        private void button_return_book_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView_borrow_book.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order.");
                return;
            }

            // Get the selected book reference number
            string bookRef = dataGridView_borrow_book.SelectedRows[0].Cells["Book_Ref"].Value.ToString();

            // Get the connection string for the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";

            // Create a new SQL connection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection to the database
                connection.Open();

                // Update the Availability column in the Book table
                string updateQuery = "UPDATE Book SET Availability='Available' WHERE Book_Ref=@bookRef";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@bookRef", bookRef);
                updateCommand.ExecuteNonQuery();

                // Close the database connection
                connection.Close();

                MessageBox.Show("Book returned successfully.");
            }
        }

        private void button_delete_order_Click(object sender, EventArgs e)
        {
            if (dataGridView_borrow_book.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            // Get the Book_Ref of the selected row
            string bookRef = dataGridView_borrow_book.SelectedRows[0].Cells["Book_Ref"].Value.ToString();

            // Get the connection string for the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True";

            // Delete the selected row from the database
            string deleteQuery = "DELETE FROM Borrow WHERE Book_Ref=@bookRef";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@bookRef", bookRef);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        // Update the Availability column in the Book table
                        string updateQuery = "UPDATE Book SET Availability='Available' WHERE Book_Ref=@bookRef";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@bookRef", bookRef);
                            updateCommand.ExecuteNonQuery();
                        }

                        // Update the DataGridView to show the new data
                        string selectQuery = "SELECT * FROM Borrow";
                        using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView_borrow_book.DataSource = dataTable;
                        }

                        MessageBox.Show("Order returned and deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to return and deleting the order.");
                    }
                }
            }
        }

        private void button_clear_order_Click(object sender, EventArgs e)
        {
            if (dataGridView_borrow_book.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView_borrow_book.SelectedRows[0];
                int ordernum = Convert.ToInt32(row.Cells["Order_Number"].Value);

                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    string query = "UPDATE Borrow SET Book_Ref = '', Client_Ref = '', User_Name = '', Borrowing_Date = '', Due_Date = '' WHERE Order_Number = @ordernum";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ordernum", ordernum);

                        connection.Open();

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Borrow data cleared successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to clear borrow data.");
                        }
                    }
                }

                // Update the DataGridView to show the updated data
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    string query = "SELECT * FROM Borrow";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView_borrow_book.DataSource = dataTable;
                    }
                }

                // Clear the combo boxes
                comboBox_bookref.SelectedIndex = -1;
                comboBox_clientref.SelectedIndex = -1;
                comboBox_username.SelectedIndex = -1;
                dateTimePicker_borrowing_date.Checked = false;
                dateTimePicker_due_date.Checked = false;
            }
            else
            {
                MessageBox.Show("Please select a row to clear.");
            }
        }

        private void button_update_order_Click(object sender, EventArgs e)
        {
            if (dataGridView_borrow_book.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView_borrow_book.SelectedRows[0];
                int orderNum = Convert.ToInt32(row.Cells["Order_Number"].Value);


                // Update the database
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    string query = "UPDATE Borrow SET Book_Ref = @bookRef, Client_Ref = @clientRef, User_Name = @userName, Borrowing_Date = @borrowDate, Due_Date = @dueDate WHERE Order_Number = @orderNum";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@bookRef", comboBox_bookref.Text);
                        command.Parameters.AddWithValue("@clientRef", comboBox_clientref.Text);
                        command.Parameters.AddWithValue("@userName", comboBox_username.Text);
                        command.Parameters.AddWithValue("@borrowDate", dateTimePicker_borrowing_date.Value);
                        command.Parameters.AddWithValue("@dueDate", dateTimePicker_due_date.Value);
                        command.Parameters.AddWithValue("@orderNum", orderNum);

                        connection.Open();

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Order updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update order.");
                        }
                    }
                }

                // Update the DataGridView to show the updated data
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
                {
                    string query = "SELECT * FROM Borrow";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView_borrow_book.DataSource = dataTable;
                    }
                }

                // Clear the text boxes
                comboBox_bookref.SelectedIndex = -1;
                comboBox_clientref.SelectedIndex = -1;
                comboBox_username.SelectedIndex = -1;
                dateTimePicker_borrowing_date.Value = DateTime.Now;
                dateTimePicker_due_date.Value = DateTime.Now.AddDays(7);
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void dataGridView_borrow_book_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Open the connection
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))

                {
                    connection.Open();

                    // Create the command to select all clients
                    SqlCommand command = new SqlCommand("SELECT * FROM Borrow", connection);

                    // Create a data adapter and fill the data set
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    // Set the data source of the data grid view to the data set
                    dataGridView_borrow_book.DataSource = dataSet.Tables[0];
                    dataGridView_borrow_book.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_borrow_book.Rows[e.RowIndex];
                comboBox_bookref.Text = row.Cells["Book_Ref"].Value.ToString();
                comboBox_clientref.Text = row.Cells["Client_Ref"].Value.ToString();
                comboBox_username.Text = row.Cells["User_Name"].Value.ToString();
                dateTimePicker_borrowing_date.Text = row.Cells["Borrowing_Date"].Value.ToString();
                dateTimePicker_due_date.Text = row.Cells["Due_Date"].Value.ToString();

                button_update_client.Enabled = true;
            }
        }

        private void button_searchbar_borrow_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM Borrow WHERE Client_Ref LIKE '%' + @searchText + '%';";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(searchQuery, connection))
                {
                    command.Parameters.AddWithValue("@searchText", textBox_searchbar_borrow.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView_borrow_book.DataSource = table;
                }
            }
        }

        private void button_S_B_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM Borrow WHERE Book_Ref LIKE '%' + @searchText + '%';";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(searchQuery, connection))
                {
                    command.Parameters.AddWithValue("@searchText", textBox_S_B.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView_borrow_book.DataSource = table;
                }
            }
        }

        private void button_Search_Book_PanelBook_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM Book WHERE Book_Ref LIKE '%' + @searchText + '%';";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(searchQuery, connection))
                {
                    command.Parameters.AddWithValue("@searchText", textBox_Search_Book_PanelBook.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView_books.DataSource = table;
                }
            }
        }

        private void button_Search_client_panelclient_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM Client WHERE Client_Ref LIKE '%' + @searchText + '%';";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(searchQuery, connection))
                {
                    command.Parameters.AddWithValue("@searchText", textBox_Search_client_panelclient.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView_client.DataSource = table;
                }
            }
        }

        private void comboBox_clientref_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Search_Bookname_PanelBook_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM Book WHERE Book_Name LIKE '%' + @searchText + '%';";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(searchQuery, connection))
                {
                    command.Parameters.AddWithValue("@searchText", textBox_Search_Bookname_PanelBook.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView_books.DataSource = table;
                }
            }
        }

        private void button_Search_clientname_panelclient_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM Client WHERE Full_Name LIKE '%' + @searchText + '%';";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(searchQuery, connection))
                {
                    command.Parameters.AddWithValue("@searchText", textBox_Search_clientname_panelclient.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView_client.DataSource = table;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM Borrow WHERE User_Name LIKE '%' + @searchText + '%';";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Library_Managment_System_VDWd\Library_Managment_System_VDW\MyDB\Database.mdf;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(searchQuery, connection))
                {
                    command.Parameters.AddWithValue("@searchText", textBox_S_B_S.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView_borrow_book.DataSource = table;
                }
            }
        }
    }
}

