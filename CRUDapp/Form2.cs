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
    public partial class Form2 : Form
    {
        MySqlConnection connection;
        public Form2(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            Download();
        }
        
        void Download()
        {
            string sql = "SELECT * FROM student";
            try
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Login error", "Error!");
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Download();
        }
    }
}
