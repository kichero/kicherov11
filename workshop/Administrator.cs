using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace workshop
{
    public partial class Administrator : Form
    {
        private SqlConnection sqlConnection = null;
        public Administrator()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from komplekt", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select* from zakaz", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from yslugi", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            newOrder AdminF = new newOrder();
            AdminF.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewWorker worker = new NewWorker();
            worker.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
