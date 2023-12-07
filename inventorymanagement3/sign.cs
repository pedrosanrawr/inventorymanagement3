using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace inventorymanagement3
{
    public partial class sign : Form
    {
        private string username;
        private string email;
        private string password;
        private string reenterpassword;

        private User currentUser;

        public sign()
        {
            InitializeComponent();
            textBox3.PasswordChar = '•';
            textBox4.PasswordChar = '•';
            this.StartPosition = FormStartPosition.CenterScreen;
            currentUser = new User();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            email = textBox2.Text;
            password = textBox3.Text;
            reenterpassword = textBox4.Text;

            // Perform validation
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Passwords do not match. Please re-enter your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveToFile(username, email, password);
            MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            currentUser.IsAuthenticated = true;

            main main = new main(currentUser);
            main.Show();
            this.Hide();
        }

        private void SaveToFile(string username, string email, string password)
        {
            // Specify the file path (adjust as needed)
            string filePath = "user_data.txt";

            // Create a string with the user information
            string userData = $"{username},{email},{password}";

            try
            {
                // Append the user information to the file
                File.AppendAllText(filePath, userData + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            // Clear all the textboxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
