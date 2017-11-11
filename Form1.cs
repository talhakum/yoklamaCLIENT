using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Dynamic;
using System.Net.Http;
using System.Globalization;

namespace CoffeeMachine
{
    public partial class Form1 : Form
    {
        string[] ports = SerialPort.GetPortNames();
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string port in ports)
            {
                portCombo.Items.Add(port); // Port isimlerini combobox1'de gösteriyoruz.
                portCombo.SelectedIndex = 0;
            }
            baudCombo.Items.Add("2400");  // Baudrate'leri kendimiz combobox2'ye giriyoruz.
            baudCombo.Items.Add("4800");
            baudCombo.Items.Add("9600");
            baudCombo.Items.Add("19200");
            baudCombo.Items.Add("115200");
            baudCombo.SelectedIndex = 2;

            // Fill bolum combobox
            string htmlBolum = string.Empty;
            string urlBolum = @"http://localhost:8080/eyoklama/bolum";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlBolum);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                htmlBolum = reader.ReadToEnd();
            }

            dynamic dynBolum = JsonConvert.DeserializeObject<JArray>(htmlBolum);

            for (int i = 0; i < dynBolum.Count; i++) {
                bolumCombo.Items.Add(dynBolum[i].isim);
            }

            
        }
            
       

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            try
            {
                string sonuc = serialPort1.ReadExisting();//Serial.print kodu ile gelen analog veriyi alıyoruz,string formatında sonuc'a atıyoruz

                Regex regkhv1 = new Regex("Card UID: [0-F][0-F] [0-F][0-F] [0-F][0-F] [0-F][0-F]");
                string CardUID=regkhv1.Match(sonuc).Value;
                if(CardUID!=null && CardUID.Length>20) {
					string uid = String.Concat(CardUID[10], CardUID[11], CardUID[13], CardUID[14], CardUID[16], CardUID[17], CardUID[19], CardUID[20]);
                    ogrenciKayit(uid);
                    Console.WriteLine(uid);
                }
            }
            catch (Exception ex)
            {
                timerMAIN.Stop();
                MessageBox.Show("Zamanlayıcı hatası : "+ex.Message);
                
                
            }
        }

        private void ogrenciKayit(string uid) {
            
            // Add roll call

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/eyoklama/yoklama");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"tarih\":\""+DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)+"\"," +
                              "\"rfid\":\""+uid+"\"," +
                                                      "\"ders_name\":\""+dersCombo.SelectedItem.ToString()+"\"," +
                                                   "\"saat\":\""+ DateTime.Now.ToString("hh:mm:ss")+"\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

        }

        private bool isFormFilled()
        {
            bool flag=true;
            if (portCombo.SelectedIndex > -1)
            {
                errorProviderPort.Clear();
            }
            else
            {
                errorProviderPort.SetError(portCombo, "Lütfen bir port seçiniz");
                flag = false;
            }
            if (baudCombo.SelectedIndex > -1)
            {
                errorProviderRate.Clear();
            }
            else
            {
                errorProviderRate.SetError(baudCombo, "Lütfen bağlantı hızını seçiniz");
                flag = false;
            }
            if (bolumCombo.SelectedIndex > -1)
            {
                errorProviderBolum.Clear();
            }
            else
            {
                errorProviderBolum.SetError(bolumCombo, "Lütfen bir bölüm seçiniz");
                flag = false;
            }
            if (ogretimGorevlisiCombo.SelectedIndex > -1)
            {
                errorProviderHoca.Clear();
            }
            else
            {
                errorProviderHoca.SetError(ogretimGorevlisiCombo, "Lütfen öğretim görevlisi alanını doldurunuz");
                flag = false;
            }
            if (dersCombo.SelectedIndex > -1)
            {
                errorProviderDers.Clear();
            }
            else
            {
                errorProviderDers.SetError(dersCombo, "Lütfen bir ders seçiniz");
                flag = false;
            }



            return flag;
        }

        private void baglanButton_Click(object sender, EventArgs e)
        {
            // Check if form is filled

            if (!isFormFilled())
            {
                return;
            }
            
            timerMAIN.Start(); 
            if (serialPort1.IsOpen == false)
            {
                if (portCombo.Text == "")
                    return;

                serialPort1.PortName = portCombo.Text; 
                //serialPort1.PortName = "/dev/cu.wchusbserial1410";
				serialPort1.BaudRate = Convert.ToInt16(baudCombo.Text); 
                

                try
                {
                    serialPort1.Open(); //Haberleşme için port açılıyor
                    durumLabel.ForeColor = Color.Green;
                    durumLabel.Text = "Bağlantı Açık";
                    baglanButton.Enabled = false;
                    koparButton.Enabled = true;
                    baudCombo.Enabled = false;
                    portCombo.Enabled = false;

                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata : " + hata.Message);
                   
                    
                }
            }
            else
            {
                durumLabel.Text = "Bağlantı kurulu !!!";
            }
        }

        private void koparButton_Click(object sender, EventArgs e)
        {
            timerMAIN.Stop();
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
                durumLabel.ForeColor = Color.Red;
                durumLabel.Text = "Bağlantı Kapalı";
                baglanButton.Enabled = true;
                baudCombo.Enabled = true;
                portCombo.Enabled = true;
                koparButton.Enabled = false;
            }
        }

      

        private void baudCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void bolumCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill ogretimGorevlisi combobox
            ogretimGorevlisiCombo.Items.Clear();
            string htmlBolum = string.Empty;
            string urlBolum = @"http://localhost:8080/eyoklama/ogretimgorevlisi/"+bolumCombo.SelectedItem+"";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri.EscapeUriString(urlBolum));
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                htmlBolum = reader.ReadToEnd();
            }

            dynamic dynBolum = JsonConvert.DeserializeObject<JArray>(htmlBolum);

            for (int i = 0; i < dynBolum.Count; i++)
            {
                ogretimGorevlisiCombo.Items.Add(dynBolum[i][0].ad + " " + dynBolum[i][0].soyad);
            }
        }

        private void ogretimGorevlisiCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill ders combobox
            dersCombo.Items.Clear();

            var selectedItem = ogretimGorevlisiCombo.SelectedItem.ToString();
            var hocaSoyad = selectedItem.Split(' ').Last();

            string htmlBolum = string.Empty;
            string urlBolum = @"http://localhost:8080/eyoklama/ders/"+hocaSoyad+"";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri.EscapeUriString(urlBolum));
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                htmlBolum = reader.ReadToEnd();
            }

            dynamic dynBolum = JsonConvert.DeserializeObject<JArray>(htmlBolum);

            for (int i = 0; i < dynBolum.Count; i++)
            {
                dersCombo.Items.Add(dynBolum[i][1].ad);
            }

            
        }

        private void dersCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
