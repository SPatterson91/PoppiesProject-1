using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PoppiesProject_1
{
    public partial class Form1 : Form
    {
        string conn_string = "Provider = Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source= C:\Users\Samuel\Desktop\Poppies Database_090517.accdb";
        string error_msg = "You are not connected to the Database";
        string q = "";
        OleDbConnection conn = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectToolStripMenuItem.PerformClick();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new OleDbConnection(conn_string);
                conn.Open();
                disconnectToolStripMenuItem.Enabled = true;
                connectToolStripMenuItem.Enabled = false;
                MessageBox.Show("Database connected");


            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                disconnectToolStripMenuItem.Enabled = false;
                connectToolStripMenuItem.Enabled = true;
            }

            catch (Exception ex) { MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void run_Query()
        {
            error_msg = "";
            q = query_box.Text;
            try
            {
                OleDbCommand cmd = new OleDbCommand(q, conn);
                OleDbDataAdapter a = new OleDbDataAdapter(cmd);

                DataTable dt = new DataTable();

                a.SelectCommand = cmd;
                a.Fill(dt);

                results.DataSource = dt;
                results.AutoResizeColumns();

                
                
            }

            catch (Exception ex)
            {
                error_msg = ex.Message;
                MessageBox.Show(error_msg);


            }
        }

        private void results_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void runQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            run_Query();
            this.Cursor = Cursors.Default; 
        }
    }
}
       

