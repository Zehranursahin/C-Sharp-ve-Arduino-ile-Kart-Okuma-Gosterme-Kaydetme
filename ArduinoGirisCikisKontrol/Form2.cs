using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO.Ports;

namespace ArduinoGirisCikisKontrol
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public MySqlConnection mysqlbaglan = new MySqlConnection("Server=localhost;Database=dbbilgiler;Uid=root;Pwd='87654321';");
        Boolean acikMi=true;
        string mesaj="";
        void kisiBilgileriGetir(string kartNo)
        {
            try
            {
                mysqlbaglan.Open();
                MySqlCommand cmd = new MySqlCommand("select * from kisibilgileri where kartNo = '" + kartNo + "'  ", mysqlbaglan);
                int Count = Convert.ToInt32(cmd.ExecuteScalar());

                if (Count != 0)
                {

                    MySqlDataReader oku = cmd.ExecuteReader();
                    while (oku.Read())
                    {
                        label1.Text = oku["ad"].ToString();
                        label2.Text = oku["soyad"].ToString();
                        pictureBox1.LoadAsync(oku["foto"].ToString());
                        label3.Text = oku["telNo"].ToString();
                        mesaj= oku["ad"].ToString() + " Başarıyla Giriş Yaptı\n" + DateTime.Now.ToString("dd/MM/yyyy H:mm");
                        label4.Text = mesaj;
                        GetSourceCode("https://bahadirduzcan.com.tr/smsApi.php?telNo="+ oku["telNo"].ToString() + "&kod=123654");
                    }

                    mysqlbaglan.Close();

                    {
                        try
                        {
                            mysqlbaglan.Open();
                            MySqlCommand ekle = new MySqlCommand("insert into log (logText) values ('" + mesaj + "')", mysqlbaglan);
                            ekle.ExecuteNonQuery();
                            mysqlbaglan.Close();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        static string GetSourceCode(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader sRead = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
            {
                return sRead.ReadToEnd();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();  //Seri portları diziye ekleme
            foreach (string port in ports)
                comboBox1.Items.Add(port);               //Seri portları comboBox1'e ekleme

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived); //DataReceived eventini oluşturma
        }

        private string data;

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();                      //Veriyi al
            this.Invoke(new EventHandler(displayData_event));
        }

        private void displayData_event(object sender, EventArgs e)
        {
            if(acikMi)
            {
                listBox1.Items.Add(data.Trim());
                kisiBilgileriGetir(data.Trim());
                timer1.Enabled = true;
                acikMi = false;
            }
            //DateTime.Now.ToString() + "        " + data + "\n"; //Gelen veriyi textBox içine güncel zaman ile ekle
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;  //ComboBox1'de seçili nesneyi port ismine ata
                serialPort1.BaudRate = 9600;            //BaudRate 9600 olarak ayarla
                serialPort1.Open();                     //Seri portu aç
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");    //Hata mesajı göster
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Close();        //Seri Portu kapa
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();    //Seri port açıksa kapat
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            acikMi = true;
            timer1.Enabled = false;
        }
    }
}
