using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventorymanagement3
{
    public partial class main : Form
    {
        private User currentUser;

        public main(User user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            currentUser = user;

            // Check if the user is authenticated
            if (!currentUser.IsAuthenticated)
            {
                MessageBox.Show("User not authenticated. Redirecting to login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sign sign = new sign();
                sign.Show();
                this.Hide();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inventory inventory = new inventory();
            inventory.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentUser.IsAuthenticated = false;
            sign sign = new sign();
            sign.Show();
            this.Hide();
        }
    }
}
