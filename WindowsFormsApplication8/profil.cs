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
using System.Net.Mail;
using System.Net;
using Microsoft.VisualBasic;
using System.IO;

namespace WindowsFormsApplication8
{
    public partial class profil : Form
    {
        public profil()
        {
            InitializeComponent();
        }
        SqlConnection blnt = new SqlConnection("Data Source=desktop-6crttdm;Initial Catalog=sifreleme;Integrated Security=True");

        void baglan()
        {
            if (blnt.State == ConnectionState.Closed) { blnt.Open(); }
        }

        int b = 0, c = 0, d = 0;

        int sayi1;
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            string z;
            MessageBox.Show("İlk E-Postanıza gelen kodu onaylayın");
            try
            {
                sayi1 = rnd.Next(100000, 900000);
                MailMessage msj = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("onaylandiniz@gmail.com", "onaylandiniz123");
                client.Port = 587;
                client.Host = " smtp.gmail.com";
                client.EnableSsl = true;
                msj.To.Add(label4.Text);
                msj.From = new MailAddress("onaylandiniz@gmail.com");
                msj.Subject = "GÜVENLİK KODU";
                msj.Body = sayi1.ToString();
                client.Send(msj);
                z = Interaction.InputBox(label4.Text + " ADRESİNE KOD GÖNDERİLDİ KODU GİRİNİZ", "ONAY KODU");
                if (z == sayi1.ToString())
                {
                    MessageBox.Show("E-Postanızı değiştirebilirsiniz");
                    label5.Visible = true;
                    textBox1.Visible = true;
                    button1.Visible = true;
                    label5.Text = "Yeni eposta giriniz";
                    b++;
                }
                else
                {
                    DialogResult asd = MessageBox.Show("Kod geçersiz tekrar denemek istermisiniz", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (DialogResult.Yes == asd)
                    {
                        z = Interaction.InputBox(label4.Text + " ADRESİNE KOD GÖNDERİLDİ KODU GİRİNİZ", "ONAY KODU");
                        if (z == sayi1.ToString())
                        {
                            MessageBox.Show("E-Postanızı değiştirebilirsiniz");
                            label5.Visible = true;
                            textBox1.Visible = true;
                            button1.Visible = true;
                            label5.Text = "Yeni eposta giriniz";
                            b++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("E-Postanız değiştirilmedi");
                        label5.Visible = false;
                        textBox1.Visible = false;
                        button1.Visible = false;
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();
            string a = openFileDialog1.FileName;

            if (a != "openFileDialog1")
            {
                pictureBox1.ImageLocation = a;
                button1.Visible = true;
                button1.Text = "Resmi Kaydet";
                c++;

            }
            else
                MessageBox.Show("Resminiz değiştirilmedi");

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                textBox1.Clear();
                textBox2.Clear();
                button1.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox2.Visible = true;
                textBox1.Visible = true;
                button2.Visible = true;
                label5.Text = "Eski şifrenizi  giriniz.";
                label6.Text = "Yeni şifrenizi  giriniz.";
                d++;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan();
            if (b == 1)
            {
                baglan();
                try
                {
                    string z;
                    sayi = rnd.Next(100000, 900000);
                    MailMessage msj = new MailMessage();
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("onaylandiniz@gmail.com", "onaylandiniz123");
                    client.Port = 587;
                    client.Host = " smtp.gmail.com";
                    client.EnableSsl = true;
                    msj.To.Add(textBox1.Text);
                    msj.From = new MailAddress("onaylandiniz@gmail.com");
                    msj.Subject = "GÜVENLİK KODU";
                    msj.Body = sayi.ToString();
                    client.Send(msj);
                    z = Interaction.InputBox(textBox1.Text + " ADRESİNE KOD GÖNDERİLDİ KODU GİRİNİZ", "ONAY KODU");
                    if (z == sayi.ToString())
                    {
                        SqlCommand cmd = new SqlCommand("update kullaniciveri set eposta ='" + textBox1.Text + "'where eposta ='" + label4.Text + "'", blnt);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("E-Postanız başarılı bir şekilde değitirildi.");
                        label5.Visible = false;
                        textBox1.Clear();
                        textBox1.Visible = false;
                        button1.Visible = false;
                        b--;
                    }
                    else
                    {
                        DialogResult asd = MessageBox.Show("Kod geçersiz tekrar denemek istermisiniz", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (DialogResult.Yes == asd)
                        {
                            z = Interaction.InputBox(textBox1.Text + " ADRESİNE KOD GÖNDERİLDİ KODU GİRİNİZ", "ONAY KODU"); ;
                            if (z == sayi.ToString())
                            {
                                SqlCommand cmd = new SqlCommand("update kullaniciveri set eposta ='" + textBox1.Text + "'where eposta ='" + label4.Text + "'", blnt);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("E-Postanız başarılı bir şekilde değitirildi.");
                                label5.Visible = false;
                                textBox1.Clear();
                                textBox1.Visible = false;
                                button1.Visible = false;
                                b--;
                            }
                            else
                            {
                                MessageBox.Show("E-Postanız değiştirilemedi");
                                label5.Visible = false;
                                textBox1.Visible = false;
                                button1.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("E-Postanız değiştirilmedi");
                            label5.Visible = false;
                            textBox1.Visible = false;
                            button1.Visible = false;
                        }
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            if (c == 1)
            {
                if (pictureBox1.ImageLocation != "")
                {
                    DialogResult asd = MessageBox.Show("Resmi kaydetmek istiyormusunuz?", "", MessageBoxButtons.YesNo);
                    if (asd == DialogResult.Yes)
                    {
                        if (System.IO.File.Exists(@"kullaniciresimleri/" + label2.Text + ".jpg"))
                        {
                            System.IO.File.Delete(@"kullaniciresimleri/" + label2.Text + ".jpg");
                        }
                        pictureBox1.Image.Save("kullaniciresimleri/" + label2.Text + ".jpg");
                        MessageBox.Show("Resminiz başarıyla değiştirildi");
                        button1.Visible = false;
                        c--;
                    }
                    button1.Visible = false;
                    c--;
                }
                else
                {
                    MessageBox.Show("Lütfen resim seçin");
                    c--;
                }

            }
            if (d == 1)
            {
                try
                {
                    baglan();
                    SqlCommand cnd = new SqlCommand("select * from kullaniciveri where sifre = '" + textBox1.Text + "'", blnt);
                    SqlDataReader rd = cnd.ExecuteReader();
                    if (rd.Read())
                    {
                        if (!(textBox2.Text.Length < 7))
                        {
                            SqlCommand cmd = new SqlCommand("update kullaniciveri set sifre = '" + textBox2.Text + "'where sifre = '" + textBox1.Text + "'", blnt);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Şifreniz başarıyla değiştirildi");
                            button1.Visible = false;
                            label5.Visible = false;
                            label6.Visible = false;
                            textBox2.Visible = false;
                            textBox1.Visible = false;
                            d--;
                        }
                        else
                        {
                            MessageBox.Show("Şifrenizin uzunluğu uygun değil");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Eski şifreniz doğru değil");

                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
        }

        private void profil_Load(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(this, "Konumlandırmak için tıklayın ve fareyi oynatın");
            pictureBox2.ImageLocation = "anasayfa.jpg";
            pictureBox4.ImageLocation = "exit.png";
            pictureBox5.ImageLocation = "simgedrm.png";
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            timer1.Start();
        }
        int sayi;
        Random rnd = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "kullaniciresimleri/" + label2.Text + ".jpg";
            timer1.Stop();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ANASAYFA frm = new ANASAYFA();
            frm.Show();
            frm.label3.Text = label2.Text;
            frm.pictureBox1.ImageLocation = "kullaniciresimleri/" + label2.Text + ".jpg";
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            button1.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
            button2.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult drg = MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void profil_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void profil_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void profil_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
