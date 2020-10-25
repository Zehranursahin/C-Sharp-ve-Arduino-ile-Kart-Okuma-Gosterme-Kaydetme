using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ArduinoGirisCikisKontrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public MySqlConnection mysqlbaglan = new MySqlConnection("Server=localhost;Database=dbBilgiler;Uid=root;Pwd='87654321';");

        private void Form1_Load(object sender, EventArgs e)
        {
            /*try
            {
                mysqlbaglan.Open();
                if (mysqlbaglan.State != ConnectionState.Closed)
                {
                    MessageBox.Show("Bağlantı Başarılı Bir Şekilde Gerçekleşti");
                }
                else
                {
                    MessageBox.Show("Maalesef Bağlantı Yapılamadı...!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hata! " + err.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // bağlantıyı açalım
                mysqlbaglan.Open();
                // ekleme komutunu tanımladım ve insert sorgusunu yazdım.
                MySqlCommand ekle = new MySqlCommand("insert into kisibilgileri (ad,soyad,foto,telNo) values ('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "','"+ textBox4.Text +"' )", mysqlbaglan);
                // sorguyu çalıştırıyorum.
                object sonuc = null;
                sonuc = ekle.ExecuteNonQuery(); // sorgu çalıştı ve dönen değer objec türünden değişkene geçti eğer değişken boş değilse eklendi boşşsa eklenmedi.
                if (sonuc != null)
                    MessageBox.Show("Sisteme başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sisteme eklenemedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // bağlantıyı kapatalım
                mysqlbaglan.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (Exception HataYakala)
            {
                MessageBox.Show("Hata: " + HataYakala.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
