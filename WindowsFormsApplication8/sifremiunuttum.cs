using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;
namespace WindowsFormsApplication8
{
    public partial class sifremiunuttum : Form
    {

        

        public sifremiunuttum()
        {
            InitializeComponent();
        }
        OleDbConnection blnt = new OleDbConnection("provider=microsoft.ace.oledb.12.0; Data source =sifreleme.accdb");
         void baglan()
        {
            if (blnt.State == ConnectionState.Closed) blnt.Open();
        }
         int sayi;
         Random rnd = new Random();
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kodunuz e-postanıza gönderiliyor lütfen bekleyiniz...");
            baglan();
            OleDbCommand cmd = new OleDbCommand("select * from kullaniciveri where ad = '" + textBox1.Text + "'and eposta = '" + textBox2.Text + "'", blnt);
            OleDbDataReader rd = cmd.ExecuteReader();
            if(rd.Read())
            {
                try
                {
                    sayi = rnd.Next(100000, 900000);
                    MailMessage msj = new MailMessage();
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("onaylandiniz@gmail.com", "49036396640sa");
                    client.Port = 587;
                    client.Host = " smtp.gmail.com";
                    client.EnableSsl = true;
                    msj.To.Add(textBox2.Text);
                    msj.From = new MailAddress("onaylandiniz@gmail.com");
                    msj.Subject = "GÜVENLİK KODU";
                    msj.Body = sayi.ToString();
                    client.Send(msj);
                    MessageBox.Show("KOD GÖNDERİLDİ E-POSTANIZI KONTROL EDİNİZ...");
                    label3.Enabled = true;
                    textBox3.Enabled = true;
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                MessageBox.Show("Böyle bir kayıt bulunamadı bilgilerinizi kontrol ediniz");
            }

        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text==sayi.ToString())
            {
                
                button1.Enabled = true;
                button2.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                label4.Enabled = true;
                label5.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan();
            try
            {

                if (textBox4.Text == textBox5.Text)
                {
                    OleDbCommand cmd = new OleDbCommand("update kullaniciveri set sifre ='" + textBox4.Text + "'where eposta ='" + textBox2.Text + "'", blnt);
                    cmd.ExecuteNonQuery();
                    DialogResult drg = MessageBox.Show("Şifreniz değiştirildi şimdi giriş sayfasına yönlendirileceksiniz ", "BAŞARILI", MessageBoxButtons.OK);
                    if (drg == DialogResult.OK)
                    {
                        kullanicigiris frm = new kullanicigiris();
                        this.Hide();
                        frm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Uyuşmuyor");
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        
        }

        private void sifremiunuttum_Load(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(this, "Konumlandırmak için tıklayın ve fareyi oynatın");
            pictureBox2.ImageLocation = "anasayfa.jpg";
            pictureBox4.ImageLocation = "exit.png";
            pictureBox5.ImageLocation = "simgedrm.png";
            textBox1.Focus();
            textBox3.MaxLength = 6;
            label3.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult drg = MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult drg = MessageBox.Show("Girişe dönmek istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                kullanicigiris frm = new kullanicigiris();
                frm.Show();
                this.Hide();
            }
         
        }
        int _Move;
        int Mouse_X;
        int Mouse_Y;
        private void sifremiunuttum_MouseDown(object sender, MouseEventArgs e)
        {
            _Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;   
        }

        private void sifremiunuttum_MouseUp(object sender, MouseEventArgs e)
        {
            _Move = 0;
        }

        private void sifremiunuttum_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Move == 1)
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
