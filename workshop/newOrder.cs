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
    public partial class newOrder : Form
    {
        private SqlConnection sqlConnection = null;
        
        public newOrder()
        {
            InitializeComponent();
        }
        string kodKlient, kodYsluga,kodSotrudnik;
        public void newOrder_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT ID_Кликнта, CONCAT([Фамлия],' ', [Имя],' ', [Отчество]) from [dbo].[Клиенты]", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    string str12 = (string)reader[0].ToString();
                    string str = (string)reader[1];
                    kodKlient =str12;
                    comboBox1.Items.Add(str);
                    
                }
            }
            reader.Close();
            SqlCommand command1 = new SqlCommand("select Название,id_Услуги from Услуги", sqlConnection);
            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    string str1 = (string)reader1[0];
                    string str2 = (string)reader1[1].ToString(); 
                    comboBox2.Items.Add(str1);
                     kodYsluga=str2;
                    
                }
            }
            reader1.Close();
            SqlCommand command2 = new SqlCommand("select [id_сотрудники], concat([Фамлия],' ',[Имя],' ',[Отчество]) from mastera", sqlConnection);
            SqlDataReader reader2 = command2.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    string str2 = (string)reader2[1];
                    string str3 = (string)reader2[0].ToString();
                    comboBox3.Items.Add(str2);
                    kodSotrudnik=str3;
                  

                }
            }
            reader2.Close();
        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            Fam.Visible = true;
            Im.Visible = true;
            Otc.Visible = true;
            nt.Visible = true;
            button4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            Fam.Visible = false;
            Im.Visible = false;
            Otc.Visible = false;
            nt.Visible = false;
            button4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1 == null)
            {
                MessageBox.Show("Заполните поля");
            }
            if (comboBox2 == null)
            {
                MessageBox.Show("Заполните поля");
            }
            if (comboBox3 == null)
            {
                MessageBox.Show("Заполните поля");
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {


                string q = "false";
                DateTime curDate = DateTime.Now;
                SqlCommand sqlCommand = new SqlCommand("INSERT into Заказа(Клиент,Услуга,Сотрудник,Дата_заявки,Статуc,[Доп.Информация])VALUES(@klient,@yslugi,@sotrudnik,@date,@statys,@info)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@klient", kodKlient);
                sqlCommand.Parameters.AddWithValue("@yslugi", kodYsluga);
                sqlCommand.Parameters.AddWithValue("@sotrudnik", kodSotrudnik);
                sqlCommand.Parameters.AddWithValue("@date", curDate);
                sqlCommand.Parameters.AddWithValue("@statys", q);
                sqlCommand.Parameters.AddWithValue("@info", textBox1.Text);
                MessageBox.Show(sqlCommand.ExecuteNonQuery().ToString());
            }
            
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            if (Fam.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            if (Im.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            if (Otc.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            if (nt.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {
                SqlCommand sqlCommand1 = new SqlCommand("INSERT into Клиенты(Фамлия,Имя,Отчество,Номер_телефона) VALUES (@firstname, @secondname, @surname, @nhone)", sqlConnection);
                sqlCommand1.Parameters.AddWithValue("firstname", Fam.Text);
                sqlCommand1.Parameters.AddWithValue("secondname", Im.Text);
                sqlCommand1.Parameters.AddWithValue("surname", Otc.Text);
                sqlCommand1.Parameters.AddWithValue("nhone", nt.Text);

                MessageBox.Show(sqlCommand1.ExecuteNonQuery().ToString());

                comboBox1.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                Fam.Visible = false;
                Im.Visible = false;
                Otc.Visible = false;
                nt.Visible = false;
                button4.Visible = false;

                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("SELECT ID_Кликнта, CONCAT([Фамлия],' ', [Имя],' ', [Отчество]) from [dbo].[Клиенты]", sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string str12 = (string)reader[0].ToString();
                        string str = (string)reader[1];
                        kodKlient = str12;
                        comboBox1.Items.Add(str);

                    }
                }
                reader.Close();
            }
           
        }
    }
}

    

