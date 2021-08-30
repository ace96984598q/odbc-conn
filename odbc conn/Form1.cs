using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace odbc_conn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string connString = "User ID = uID;Password= pw;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=HOST)(PORT=PORT)))(CONNECT_DATA=(SERVICE_NAME=SERVICE_NAME)))";
        OracleConnection connection = new OracleConnection(connString);
        private void button1_Click(object sender, EventArgs e)
        {
            textin.Enabled = true;
            connection.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        public string get_data()
        {
            OracleCommand cmd = new OracleCommand(textin.Text.ToString(), connection);
            OracleDataReader reader = cmd.ExecuteReader();
            //string NOS = "";
            //while (reader.Read())
            //{
            //    NOS = reader.GetOracleString
            //}
            reader.Read();
            string NOS = reader.GetString(0);
            return NOS;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = get_data();
            label1.Visible = true;
            //label2.Visible = true;
            //label3.Visible = true;
            label1.Text = a;
            //label2.Text = reader.GetString(1);
            //label3.Text = reader.GetString(2);
            //connection.Dispose();
            //GC.Collect();
        }
    }
}
