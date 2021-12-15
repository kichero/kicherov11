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
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        SqlDataAdapter adapter;
        DataSet dataSet;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);
            sqlConnection.Open();
            if (EmailText.Text == "")
            {
                if (PasswordText.Text == "")
                {
                    MessageBox.Show("Заполните поля");
                }
                else
                {
                    MessageBox.Show("Введите логин");
                }
            }
            else
            {
                if (PasswordText.Text == "")
                {
                    MessageBox.Show("Введите пароль");
                }
            }
            
            
                adapter = new SqlDataAdapter("select* from Worker", sqlConnection);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
                string Role;
           
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    if (EmailText.Text == dataSet.Tables[0].Rows[i][0].ToString())
                    {
                        if (PasswordText.Text == dataSet.Tables[0].Rows[i][1].ToString())
                        {
                            Role = dataSet.Tables[0].Rows[i][2].ToString();
                            switch (Role)
                            {
                                case "Администратор":
                                    {
                                        MessageBox.Show("Авторизирован", "Авторизирован");
                                        Administrator AdminF = new Administrator();
                                        AdminF.Show();
                                        this.Hide();
                                    } break;
                                case "Сотрудник":
                                    {
                                        MessageBox.Show("Авторизирован", "Авторизирован");
                                        masterVIew workerF = new masterVIew();
                                        workerF.Show();
                                        this.Hide();
                                    }
                                    break;
                            }
                        }
                    }
                }
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            masterVIew AdminF = new masterVIew();
            AdminF.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
