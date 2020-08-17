using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // dosya işlemleri için gerekli kütüphanedir(StreamWriter sınıfı)

namespace Kişisel_Bilgi_Form
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent(); //dateTimerPicher incele.

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Seydişehir");
            comboBox1.Items.Add("Beyşehir");
            comboBox1.Items.Add("Selçuklu");
            comboBox1.Items.Add("Karatay");
            comboBox1.Items.Add("Meram");
            comboBox1.Items.Add("Karapınar");
            comboBox1.Items.Add("Bozkır");
            comboBox1.Items.Add("Ilgın");
            comboBox1.Items.Add("Sarayönü");
            comboBox1.Items.Add("Doğanhisar");
            // comboBox1.SelectedIndex = 0; // ComboBox içindeki ilk veriyi seçili getirir.

        }

        private void textBoxTcKimlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // TextBox'a karakter girişi engellendi.
        }

        private void textBoxAdı_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar); // TextBox'a dışarıdan harf girişi engellendi.

        }

        private void textBoxSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBoxDTarih_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // TextBox'a karakter girişi engellendi."
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("TC Kimlik No:");
            listBox1.Items.Add(textBoxTcKimlik.Text);
            listBox1.Items.Add("----------------------------------------------");

            listBox1.Items.Add("Adı:");
            listBox1.Items.Add(textBoxAd.Text);
            listBox1.Items.Add("----------------------------------------------");

            listBox1.Items.Add("Soyadı:");
            listBox1.Items.Add(textBoxSoyad.Text);
            listBox1.Items.Add("----------------------------------------------");

            listBox1.Items.Add("Doğum Tarihi:");
            listBox1.Items.Add(dateTimePicker1.Text);
            listBox1.Items.Add("----------------------------------------------");

            listBox1.Items.Add("Adres:");
            listBox1.Items.Add(textBoxAdres.Text);
            listBox1.Items.Add("-----------------------------------------------");

            listBox1.Items.Add("İlçe:");
            var result = comboBox1.SelectedValue; // ComboBox'tan seçilen veriyi bir result değişkenine atıyoruz.
            listBox1.Items.Add(comboBox1.Text); // ComboBox'tan seçilen veriyi listBox'a yazıyoruz.

            listBox1.Items.Add("-----------------------------------------------");

            if (radioButtonKız.Checked == true)
            {
                listBox1.Items.Add("Cinsiyet:");
                listBox1.Items.Add(radioButtonKız.Text);
            }
            if (radioButtonErkek.Checked == true)
            {
                listBox1.Items.Add("Cinsiyet:");
                listBox1.Items.Add(radioButtonErkek.Text);
            }

            listBox1.Items.Add("------------------------------------------------");

            if (radioButtonIlkOgretim.Checked == true)
            {
                listBox1.Items.Add("Egitim Durumu:");
                listBox1.Items.Add(radioButtonIlkOgretim.Text);

            }
            if (radioButtonLise.Checked == true)
            {
                listBox1.Items.Add("Egitim Durumu:");
                listBox1.Items.Add(radioButtonLise.Text);

            }
            if (radioButtonOnLisans.Checked == true)
            {
                listBox1.Items.Add("Egitim Durumu:");
                listBox1.Items.Add(radioButtonOnLisans.Text);

            }
            if (radioButtonLisans.Checked == true)
            {
                listBox1.Items.Add("Egitim Durumu:");
                listBox1.Items.Add(radioButtonLisans.Text);

            }

            listBox1.Items.Add("--------------------------------------------------");

            listBox1.Items.Add("Hobiler:");

            foreach (Control kontrol in this.groupBoxHobiler.Controls)
            //for (int i = 0; i < this.groupBoxHobiler.Controls.Count; i++)
            {
                if (kontrol is CheckBox)
                {
                    if (((CheckBox)kontrol).Checked == true)
                    {
                        listBox1.Items.Add(((CheckBox)kontrol).Text.ToString());
                    }
                }
            }
        }
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        // dosyaya kaydetme
        private void buttonDosyaKaydet_Click(object sender, EventArgs e)
        {

            if (listBox1.Items.Count == 0) /* listBox bir dizi gibi çalıştığı için "listBox1.Text" yazarsak görmez ve hata verir. 
                                            bu yüzden Count yapmalıyız.*/
            {
                listBox1.BackColor = Color.Green;

                MessageBox.Show(" Dosya Kaydedilemedi !! \n ListBox'ın içi boş");
            }
            else
            {
                StreamWriter SW = new StreamWriter("C:\\dosyayaKaydet.txt");

                foreach (var item in listBox1.Items) // listBox^taki bütüm Item'ları teker teker dosyaya kaydeden döngü.
                {
                    SW.WriteLine(item.ToString());
                }
                SW.Close();


                MessageBox.Show("Kayıtlar Başarıyla Eklendi");
            }
        }

        private void buttonVarOlanKayıt_Click(object sender, EventArgs e) // Varolan kaydı getirme.
        {


           // string[] veri = new string[14];
            string veriler = "";
            //for (int i = 0; i < veri.Length; i++)
            //{
            //    veriler += veri[i];
            //}

            string[] hepsi = File.ReadAllLines("C:\\dosyayaKaydet.txt");

            foreach (string n in hepsi)
            {
                veriler += n;
            }
            MessageBox.Show(veriler);

            

           
        }
    }
}
// listboxı gez her bir stringi içine at 
