using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace CRUDapp
{
    public partial class FormLog1 : Form
    {
        public FormLog1()
        {
            InitializeComponent();
            textBoxServer.Text = "adamcieslak.cba.pl";
            textBoxDatabase.Text = "ajdachoo";
            textBoxUID.Text = "adambaza";
            textBoxPassword.Text = "Adambaza@2000";
        }
        private void Login()
        {
            string myConnection = "SERVER=" + textBoxServer.Text + ";" + "DATABASE=" + textBoxDatabase.Text + ";" + "UID=" + textBoxUID.Text + ";" + "PASSWORD=" + textBoxPassword.Text + ";";
            MySqlConnection connection = new MySqlConnection(myConnection);

            try
            {
                connection.Open();
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Login error", "Error!");
            }
            connection.Close();

            Form2 form2 = new Form2(connection);
            form2.Show();

            this.Hide();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
