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
using System.Net;

namespace WindowsFormsApplication8
{
    public partial class kullnicikayit : Form
    {
        public kullnicikayit()
        {
            InitializeComponent();
        }

        OleDbConnection blnt = new OleDbConnection("provider=microsoft.ace.oledb.12.0; Data source =sifreleme.accdb");

        void baglan()
        {
            if (blnt.State == ConnectionState.Closed) blnt.Open();
        }

        private void kullnicigiris_Load(object sender, EventArgs e)
        {
            ToolTip tpp = new ToolTip();
            tpp.SetToolTip(this, "Konumlandırmak için tıklayın ve fareyi oynatın");
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox2.PasswordChar = '\0';
            textBox3.PasswordChar = '\0';
            pictureBox5.ImageLocation = "goz.png";
            pictureBox3.ImageLocation = "goz.png";
            pictureBox4.ImageLocation = "exit.png";
            pictureBox6.ImageLocation = "anasayfa.jpg";
            pictureBox7.ImageLocation = "user.png";
            pictureBox8.ImageLocation = "simgedrm.png";
            label6.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            ToolTip tp = new ToolTip();
            tp.IsBalloon = true;
            tp.SetToolTip(textBox1, "Kullanıcı adınızı iyi seçin bir daha değiştiremezsiniz");
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        string k_adi, sifre1, sifre2, eposta;

        private void button1_Click(object sender, EventArgs e)
        {
            if (label7.Visible == true && label6.Visible == true)
                textBox1.Focus();
            else if (label6.Visible == true)
                textBox1.Focus();
            else if (label7.Visible == true)
                textBox4.Focus();
            else
            {
                try
                {
                    k_adi = textBox1.Text;
                    sifre1 = textBox2.Text;
                    sifre2 = textBox3.Text;
                    eposta = textBox4.Text;
                    if (sayi == int.Parse(textBox5.Text))
                    {
                        if (sifre1 == sifre2 && sifre1.Length >= 8)
                        {
                            baglan();
                            string asdf = pictureBox7.ImageLocation;
                            if (asdf == "user.png")
                            {
                                DialogResult a = MessageBox.Show("Resimsiz devam etmek istediğinize eminmisiniz?", "onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (a == DialogResult.Yes)
                                { 
                                                                   
                                    pictureBox7.Image.Save("kullaniciresimleri/" + textBox1.Text.ToString() + ".jpg");
                                    OleDbCommand cmd = new OleDbCommand("INSERT INTO kullaniciveri VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + "kullaniciresimleri/" + textBox1.Text.ToString() + ".jpg" + "')", blnt);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Kayıt Başarılı Giriş Sayfasına Yönlendiriliyorsunuz...");
                                    kullanicigiris frm = new kullanicigiris();
                                    frm.Show();
                                    this.Hide();
                                }                             

                            }
                            else
                            {
                                pictureBox7.Image.Save("kullaniciresimleri/" + textBox1.Text.ToString() + ".jpg");
                                OleDbCommand cmd = new OleDbCommand("INSERT INTO kullaniciveri VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + "kullaniciresimleri/" + textBox1.Text.ToString() + ".jpg" + "')", blnt);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Kayıt Başarılı Giriş Sayfasına Yönlendiriliyorsunuz...");
                                kullanicigiris frm = new kullanicigiris();
                                frm.Show();
                                this.Hide();
                            }
                                               
                         
                        }
                        else if (!(sifre1 == sifre2) && sifre1.Length >= 8)
                            MessageBox.Show("Şifreler birbiriyle uyuşmuyor");

                        else
                            MessageBox.Show("şifrenizin uzunluğu uygun değil");

                    }
                    else
                        MessageBox.Show("kodu kontrol ediniz");

                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
            if (textBox3.Text != textBox2.Text)
                label8.Visible = true;
            else label8.Visible = false;
            if (textBox3.Text == "")
                pictureBox2.Visible = false;
            else
                pictureBox2.Visible = true;
            if (!(textBox3.Text == textBox2.Text) && !(textBox3.Text == "Şifre Tekrar"))
                pictureBox2.ImageLocation = "false.png";
            if (textBox3.Text == textBox2.Text && !(textBox3.Text == "Şifre Tekrar"))
                pictureBox2.ImageLocation = "true.png";
            if (textBox3.Text == "Şifre Tekrar")
            {
                textBox3.PasswordChar = '\0';
            }
            else
                textBox3.PasswordChar = '*';
            if(textBox2.Text=="Şifre"&&textBox3.Text=="Şifre Tekrar")
            {    pictureBox2.ImageLocation = "";
            pictureBox1.ImageLocation = "";}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            if (textBox2.Text == "")
            {
                pictureBox1.Visible = false;
                label9.Visible = false;
            }
            else if (textBox2.Text.Length < 8&&!(textBox2.Text=="Şifre"))
            {
                label9.Visible = true;
                pictureBox1.ImageLocation = "false.png";
            }
            else if (textBox2.Text != "Şifre")
            {
                label9.Visible = false;
                pictureBox1.Visible = true;
                pictureBox1.ImageLocation = "true.png";
            }
            if(textBox2.Text=="Şifre")
            {
                textBox2.PasswordChar = '\0';
            }
            else
                textBox2.PasswordChar = '*';
            if (textBox2.Text == "Şifre" && textBox3.Text == "Şifre Tekrar")
            {  pictureBox2.ImageLocation = "";
            pictureBox1.ImageLocation = "";}

        }
        int sayi;
        Random rnd = new Random();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sayi = rnd.Next(100000, 900000);
                MailMessage msj = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("onaylandiniz@gmail.com", "onaylandiniz123");
                client.Port = 587;
                client.Host = " smtp.gmail.com";
                client.EnableSsl = true;
                msj.To.Add(textBox4.Text);
                msj.From = new MailAddress("onaylandiniz@gmail.com");
                msj.Subject = "GÜVENLİK KODU";
                msj.Body = sayi.ToString();
                client.Send(msj);
                MessageBox.Show("KOD GÖNDERİLDİ E-POSTANIZI KONTROL EDİNİZ...");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {               
                baglan();
                if (!(textBox1.Text == null))
                {
                    OleDbCommand cmd = new OleDbCommand("select * from kullaniciveri where ad ='" + textBox1.Text + "'", blnt);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        label6.Visible = true;
                    }
                    else
                    {
                        label6.Visible = false;
                    }
                }
                if (textBox1.Text != "Kullanıcı Adı")
                    label1.Visible = true;

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult drg = MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kullanicigiris frm = new kullanicigiris();
            this.Hide();
            frm.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {

                baglan();
                if (!(textBox1.Text == null))
                {

                    OleDbCommand cmd = new OleDbCommand("select * from kullaniciveri where eposta ='" + textBox4.Text + "'", blnt);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        label7.Visible = true;
                        button2.Enabled = false;
                    }
                    else
                    {
                        label7.Visible = false;
                        button2.Enabled = true;
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
                  
            if (textBox5.Text == sayi.ToString())
                button1_Click(button1, new EventArgs());
        }

        int a = 0;

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (a == 0)
            {
                textBox2.PasswordChar = '\0';
                a = 1;
            }
            else
            {
                textBox2.PasswordChar = '*';
                a = 0;
            }

        }

        int b = 0;

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (b == 0)
            {
                textBox3.PasswordChar = '\0';
                b = 1;
            }
            else
            {
                textBox3.PasswordChar = '*';
                b = 0;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
                textBox1.Clear();
                label1.Visible = true;
            
            if (textBox2.Text == "")
            {
                label2.Visible = false;
                textBox2.Text = "Şifre";
            }
            if (textBox3.Text == "")
            {
                label3.Visible = false;
                textBox3.Text = "Şifre Tekrar";
            }
            if (textBox4.Text == "")
            {
                label4.Visible = false;
                textBox4.Text = "E-Posta";
            }
            if (textBox5.Text == "")
            {
                label5.Visible = false;
                textBox5.Text = "Doğrulama";
            }

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (label2.Visible == false)
            {
                textBox2.Clear();
                label2.Visible = true;
            }
            if (textBox1.Text == "")
            {
                label1.Visible = false;
                textBox1.Text = "Kullanıcı Adı";
            }
            if (textBox3.Text == "")
            {
                label3.Visible = false;
                textBox3.Text = "Şifre Tekrar";
            }
            if (textBox4.Text == "")
            {
                label4.Visible = false;
                textBox4.Text = "E-Posta";
            }
            if (textBox5.Text == "")
            {
                label5.Visible = false;
                textBox5.Text = "Doğrulama";
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if(label3.Visible==false)
            {
            textBox3.Clear();
            label3.Visible = true;
            }
            if (textBox1.Text == "")
            {
                label1.Visible = false;
                textBox1.Text = "Kullanıcı Adı";
            }
            if (textBox2.Text == "")
            {
                label2.Visible = false;
                textBox2.Text = "Şifre";
            }
            if (textBox4.Text == "")
            {
                label4.Visible = false;
                textBox4.Text = "E-Posta";
            }
            if (textBox5.Text == "")
            {
                label5.Visible = false;
                textBox5.Text = "Doğrulama";
            }
            
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if (label4.Visible == false)
            {
                textBox4.Clear();
                label4.Visible = true;
            }
            if (textBox1.Text == "")
            {
                label1.Visible = false;
                textBox1.Text = "Kullanıcı Adı";
            }
            if (textBox3.Text == "")
            {
                label3.Visible = false;
                textBox3.Text = "Şifre Tekrar";
            }
            if (textBox2.Text == "")
            {
                label2.Visible = false;
                textBox2.Text = "Şifre";
            }
            if (textBox5.Text == "")
            {
                label5.Visible = false;
                textBox5.Text = "Doğrulama";
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            if (label5.Visible == false)
            {
                textBox5.Clear();
                label5.Visible = true;
            }
            if (textBox1.Text == "")
            {
                label1.Visible = false;
                textBox1.Text = "Kullanıcı Adı";
            }
            if (textBox3.Text == "")
            {
                label3.Visible = false;
                textBox3.Text = "Şifre Tekrar";
            }
            if (textBox2.Text == "")
            {
                label2.Visible = false;
                textBox2.Text = "Şifre";
            }
            if (textBox4.Text == "")
            {
                label4.Visible = false;
                textBox4.Text = "E-Posta";
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult drg = MessageBox.Show("Girişe dönmek istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                kullanicigiris frm = new kullanicigiris();             
                frm.Show();
                this.Hide();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Focus())
            {
                textBox1.Clear();
                label1.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string a = openFileDialog1.FileName;
            if (a != "openFileDialog1")
            {
                pictureBox7.ImageLocation = a;   
            }
            else
                MessageBox.Show("Resim seçilmedi");
        }

        private void kullnicikayit_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;   
        }

        private void kullnicikayit_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void kullnicikayit_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
     
    }
}
