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
    public partial class NewWorker : Form
    {
        private SqlConnection sqlConnection = null;
        string kodDol;
        public NewWorker()
        {
            InitializeComponent();
        }

        private void NewWorker_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT Должность, id_должности from [dbo].[Должности]", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string str = (string)reader[0];
                    string str12 = (string)reader[1].ToString();
                    kodDol = str12;
                    comboBox1.Items.Add(str);

                }
            }
            reader.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Fam.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            if (Im.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            if (comboBox1 == null)
            {
                MessageBox.Show("Заполните поля");
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {
                SqlCommand sqlCommand1 = new SqlCommand("INSERT into Сотрудники(Фамлия,Имя,Отчество,Номер_телефона,E_mail,Должность,Пароль,Роль) VALUES (@firstname, @secondname, @surname, @nhone,@email,@Dol,@pass,@role)", sqlConnection);
                sqlCommand1.Parameters.AddWithValue("firstname", Fam.Text);
                sqlCommand1.Parameters.AddWithValue("secondname", Im.Text);
                sqlCommand1.Parameters.AddWithValue("surname", textBox1.Text);
                sqlCommand1.Parameters.AddWithValue("nhone", textBox2.Text);
                sqlCommand1.Parameters.AddWithValue("email", textBox4.Text);
                sqlCommand1.Parameters.AddWithValue("Dol", kodDol);
                sqlCommand1.Parameters.AddWithValue("pass", textBox5.Text);
                sqlCommand1.Parameters.AddWithValue("role", textBox6.Text);
                MessageBox.Show(sqlCommand1.ExecuteNonQuery().ToString());
            }
        }
    }
}
