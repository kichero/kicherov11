using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace workshop
{
    public partial class masterVIew : Form
    {
        private SqlConnection sqlConnection = null;
        public masterVIew()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            listView1.Visible = true;
            listView2.Visible = false;
            listView2.Items.Clear();

            SqlDataReader dataReader = null;

            try
            {
                
                SqlCommand sqlCommand1 = new SqlCommand("select * from komplekt", sqlConnection);
               
                
                dataReader = sqlCommand1.ExecuteReader();

                ListViewItem item = null;

                while(dataReader.Read())
                {
                    item = new ListViewItem(new string[] { Convert.ToString(dataReader[0]),
                    Convert.ToString(dataReader[1]),
                    });

                    listView2.Items.Add(item);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(dataReader!=null&&!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void masterVIew_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);
            sqlConnection.Open();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            listView2.Visible = true;
            listView1.Items.Clear();

            SqlDataReader dataReader = null;

            try
            {
                //SqlCommand sqlCommand = new SqlCommand("select  concat([Фамлия],' ',[Имя],' ',[Отчество]) from mastera", sqlConnection);
                SqlCommand sqlCommand1 = new SqlCommand("select * from zakaz1", sqlConnection);


                dataReader = sqlCommand1.ExecuteReader();

                ListViewItem item = null;

                while (dataReader.Read())
                {
                    item = new ListViewItem(new string[] { Convert.ToString(dataReader[0]),
                    Convert.ToString(dataReader[1]),
                    Convert.ToString(dataReader[2]),
                    Convert.ToString(dataReader[3]),
                    Convert.ToString(dataReader[4]),
                    Convert.ToString(dataReader[5]),
                    });

                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
    }
}
