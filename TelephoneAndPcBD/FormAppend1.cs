using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TelephoneAndPcBD
{
    public partial class FormAppend1 : Form
    {
        public FormAppend1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAppend1.ActiveForm.Hide();
            FormMain MyForm2 = new FormMain();
            MyForm2.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Zapros](FIO,Object_adress, Lic_number, Last_TO, Oborudovanie, Date) VALUES (@FIO, @Object_adress, @Lic_number, @Last_TO, @Oborudovanie, @Date)", FormMain.sqlConnection);
                command.Parameters.AddWithValue("FIO", textBox1.Text);
                command.Parameters.AddWithValue("Date", DateTime.Now);
                command.Parameters.AddWithValue("Object_adress", textBox2.Text);
                command.Parameters.AddWithValue("Lic_number", textBox3.Text);
                command.Parameters.AddWithValue("Last_TO", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                command.Parameters.AddWithValue("Oborudovanie", textBox5.Text);
                command.ExecuteNonQuery();
                try { 
                    MessageBox.Show("Запрос успешно добавлен!", "Успех");
                }
                catch { MessageBox.Show("Ошибка создания запроса", "Неудача"); }

            }
            else {
                SqlCommand command = new SqlCommand("INSERT INTO [Zapros](FIO,Object_adress, Lic_number, Oborudovanie, Date) VALUES (@FIO,@Object_adress, @Lic_number, @Oborudovanie, @Date)", FormMain.sqlConnection);
                command.Parameters.AddWithValue("FIO", textBox1.Text);
                command.Parameters.AddWithValue("Date", DateTime.Now);
                command.Parameters.AddWithValue("Object_adress", textBox2.Text);
                command.Parameters.AddWithValue("Lic_number", textBox3.Text);
                command.Parameters.AddWithValue("Oborudovanie", textBox5.Text);
                try { command.ExecuteNonQuery();
                    MessageBox.Show("Запрос успешно добавлен!", "Успех");
                }
                catch { MessageBox.Show("Ошибка создания запроса", "Неудача"); }
            }



        }

        private void FormAppend1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.Date.ToString());

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
