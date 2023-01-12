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
using newBilisim.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace newBilisim.UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConn bag = new SqlConn();
        SqlCommand komut;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains(".com"))
                {
                    komut = new SqlCommand("insert into Bilgi (ad,soyad,telefon,eposta) values('" + txtAd.Text + "','" + txtSoyad.Text + "','" + maskedTxtTel.Text + "','" + txtEmail.Text + "')", bag.baglan());
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Ekleme Başarılı");

                    txtAd.Text = "";
                    txtSoyad.Text = "";
                    txtEmail.Text= "";
                    maskedTxtTel.Text = "";

                 }
                    

                else
                {
                    MessageBox.Show("Lütfen Gerçek Bir Email Giriniz");
                }


            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hatanız var ! " + hata.Message);
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
