using newBilisim.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using newBilisim.DL;

namespace newBilisim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConn bag = new SqlConn();

        void kullaniciDoldur()
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Bilgi", bag.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns[1].HeaderText = "Adı";
                dataGridView1.Columns[2].HeaderText = "Soyadı";
                dataGridView1.Columns[3].HeaderText = "Telefon No";
                dataGridView1.Columns[4].HeaderText = "Email Adresi";

                dataGridView1.Columns[1].Width = 60;
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].Width = 80;
                
            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();  
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komutt = new SqlCommand("delete from Bilgi where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", bag.baglan());
            komutt.ExecuteNonQuery();
            MessageBox.Show("Silme İşlemi Başarılı");

            kullaniciDoldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kullaniciDoldur();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Bilgi where ad LIKE '%" + textBox1.Text + "%'", bag.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns[1].HeaderText = "Adı";
                dataGridView1.Columns[2].HeaderText = "Soyadı";
                dataGridView1.Columns[3].HeaderText = "Telefon No";
                dataGridView1.Columns[4].HeaderText = "Email Adresi";

                dataGridView1.Columns[1].Width = 60;
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].Width = 80;


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
