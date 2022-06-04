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
    public partial class FormMain : Form
    {
        public static SqlConnection sqlConnection = null;
        public FormMain()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void вручнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain.ActiveForm.Hide();
            FormAppend1 MyForm2 = new FormAppend1();
            MyForm2.ShowDialog();
            Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBPhonePC"].ConnectionString);
            sqlConnection.Open();

            SqlDataAdapter ComboBox1Adapter = new SqlDataAdapter("Select * from Zapros", sqlConnection);
            DataSet ComboSet1 = new DataSet();
            ComboBox1Adapter.Fill(ComboSet1);
            dataGridView1.DataSource = ComboSet1.Tables[0];
        }
    }
}
