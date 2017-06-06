using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppiesProject_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ConnectToAccess()
        {
            System.Data.OleDb.OleDbConnection conn = new
                System.Data.OleDb.OleDbConnection();
            //TODO: Modify the connection string and include any
            //additional required properties for your database.
            conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source= C:\Users\Samuel\Desktop\Poppies Database_090517.accdb" +
                @"Poppies Database_090517.accdb";

            try
            {
                conn.Open();
                MessageBox.Show("Connected!!!");
            }

            catch (Exception ex)

            {

                MessageBox.Show("Failed to connect to data source");

            }

            finally
            {
                conn.Close();
            }

        }


    }


}

