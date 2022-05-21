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
    public partial class Form3 : Form
    {
        MySqlConnection connection;
        public Form3(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void Querry(string sql)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            string sql = string.Format("INSERT INTO student VALUES (NULL, '{0}', '{1}', {2});", textBoxName.Text, textBoxSurname.Text, numericUpDownAge.Text);
            Querry(sql);
            this.Close();
        }
    }
}
