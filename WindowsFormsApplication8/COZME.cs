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
using System.IO;
namespace WindowsFormsApplication8
{
    public partial class COZME : Form
    {
        public COZME()
        {
            InitializeComponent();
        }
        OleDbConnection blnt = new OleDbConnection("provider=microsoft.ace.oledb.12.0; Data source =sifreleme.accdb");

        void baglan()
        {
            if (blnt.State == ConnectionState.Closed) { blnt.Open(); }
            
        }
        string DosyaUzantisi;
        void sil()
        {
            DialogResult dgr = MessageBox.Show("Şifrelenmiş resminiz kayıtlardan silinsinmi ?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == dgr)
            {
                DialogResult dgr2 = MessageBox.Show("Bu işlem geri alınamaz", "Sil", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (DialogResult.OK == dgr2)
                {
                    if (System.IO.File.Exists("resimlerim/" + textBox4.Text + DosyaUzantisi) == true)
                        System.IO.File.Delete("resimlerim/" + textBox4.Text + DosyaUzantisi);

                    baglan();
                    OleDbCommand cmd = new OleDbCommand("Delete * from verikayit where isim = '" + textBox4.Text + "'", blnt);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Verileriniz başarıyla silindi.");
                }
                else
                    MessageBox.Show("Resminiz kayıtlardan silinmedi");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string a = openFileDialog1.FileName;
            if (a != "openFileDialog1")
            {
                pictureBox1.ImageLocation = a;
                System.IO.FileInfo ff = new System.IO.FileInfo(openFileDialog1.FileName);
                DosyaUzantisi = ff.Extension;
                textBox4.Enabled = true;
                timer2.Start();
            }
            else
                MessageBox.Show("Resim seçilmedi");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            pictureBox3.ImageLocation = openFileDialog2.FileName;
            textBox4.Enabled = true;

        }



        private void COZME_Load(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            pictureBox2.ImageLocation = "anasayfa.jpg";
            pictureBox4.ImageLocation = "exit.png";
            pictureBox5.ImageLocation = "restart1.png";
            pictureBox7.ImageLocation = "simgedrm.png";
            button1.Enabled = false;
            textBox4.Enabled = false;
            richTextBox1.Enabled = false;
            ToolTip tp = new ToolTip();
            tp.SetToolTip(this, "Konumlandırmak için tıklayın ve fareyi oynatın");
            ToolTip aciklama = new ToolTip();
            aciklama.ToolTipIcon = ToolTipIcon.Warning;
            aciklama.IsBalloon = true;
            aciklama.ToolTipTitle = "Resim seç";
            aciklama.SetToolTip(button2, "Burada daha önceden şifrelediğimiz resmi seçiyoruz.");

            ToolTip aciklama2 = new ToolTip();
            aciklama2.ToolTipIcon = ToolTipIcon.Warning;
            aciklama2.IsBalloon = true;
            aciklama2.ToolTipTitle = "Kod gir";
            aciklama2.SetToolTip(textBox4, "Burada daha önceden not ettiğimiz kodu giriyoruz.");

            ToolTip aciklama3 = new ToolTip();
            aciklama3.ToolTipIcon = ToolTipIcon.Warning;
            aciklama3.IsBalloon = true;
            aciklama3.ToolTipTitle = "Dikkat";
            aciklama3.SetToolTip(button1, "Burada şifreli resmimizi buluyoruz.");

            aciklama3.SetToolTip(pictureBox2, "Buradan anasayfaya gidebiliriz.");
            aciklama3.SetToolTip(pictureBox5, "Buradan yeni resim şifresi çözmek için yeniden başlatabiliriz.");
            aciklama3.SetToolTip(pictureBox4, "Burada uygulamayı kapatırız.");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
                sil();
            DialogResult drg = MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
                sil();
            DialogResult drg = MessageBox.Show("Yeniden başlatmak istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                COZME frm = new COZME();
                this.Hide();
                frm.label2.Text = label2.Text;
                frm.pictureBox6.ImageLocation = pictureBox6.ImageLocation;
                frm.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
                sil();
            DialogResult drg = MessageBox.Show("Anasayfaya dönmek istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                ANASAYFA frm = new ANASAYFA();
                frm.Show();
                frm.label3.Text = label2.Text;
                frm.pictureBox1.ImageLocation = "kullaniciresimleri/" + label2.Text + ".jpg";
                this.Hide();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists("resimlerim/" + textBox4.Text + DosyaUzantisi)) //belirtilen dosyanın mevcut olup olmadıgına bakar
                {
                    pictureBox3.ImageLocation = "resimlerim/" + textBox4.Text + DosyaUzantisi;
                    textBox4.Enabled = false;
                    timer1.Start();
                    timer1.Interval = 500;

                }
                else
                { MessageBox.Show("çözme kodu hatalı veya şifrelenmiş resim yok"); }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox4.Text != "")
                sil();
            baglan();
            profil frm = new profil();
            OleDbCommand cmd = new OleDbCommand("select eposta from kullaniciveri where ad='" + label2.Text + "'", blnt);
            OleDbDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                frm.label4.Text = rd["eposta"].ToString();
            }
            this.Hide();
            frm.Show();
            frm.label2.Text = label2.Text;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox4.Text != "")
                sil();
            DialogResult a = MessageBox.Show("çıkış yapmak istediğine eminmisin?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (a == DialogResult.Yes)
            {
                kullanicigiris frm = new kullanicigiris();
                frm.Show();
                this.Hide();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    
        private void richTextBox1_Click(object sender, EventArgs e)
        {

        }


        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void COZME_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void COZME_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void COZME_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int karakter;
        private void timer2_Tick(object sender, EventArgs e)
        {
            Bitmap bpm = new Bitmap(pictureBox1.Image);
            karakter = bpm.Height;
            timer2.Stop();
        }
        int timerrr = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (timerrr != 0)
                    timer1.Stop();
                else
                {
                    timerrr++;
                    richTextBox1.Enabled = true;
                    baglan();
                    string a = textBox4.Text;
                    OleDbCommand cmd = new OleDbCommand("select isim from verikayit where isim ='" + a + "'", blnt);
                    OleDbDataReader rd = cmd.ExecuteReader();
                    if (!(rd.Read()))
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamadı lütfen kontrol ederek tekrar deneyiniz..." + blnt);
                    }

                    else
                    {
                        button1.Visible = false;
                        button2.Visible = false;
                        textBox4.Visible = false;
                        label6.Visible = false;
                        richTextBox1.Visible = true;
                        System.Threading.Thread.Sleep(100);
                        Bitmap bpm1 = new Bitmap(pictureBox1.Image);
                        Bitmap bpm3 = new Bitmap(pictureBox3.Image);
                        for (int i = 0; i < bpm3.Height; i++)
                        {                      //yükseklik y
                            progressBar1.Maximum = i + 1;
                            progressBar1.Value = i;
                            for (int j = 0; j < bpm3.Width; j++)
                            {                    //genişlik x
                                Color clr1 = bpm1.GetPixel(j, i);
                                //satır sütun               x,y 
                                Color clr2 = bpm3.GetPixel(j, i);
                                if (!(clr1 == clr2))//iki pikselin rengini kontrol ettik
                                {
                                //    OleDbCommand cnd = new OleDbCommand("select veri from verikayit where satir = '" + j.ToString() + "' and sutun ='" + i.ToString() + "' and isim = '" + a + "'", blnt);

                                    OleDbCommand cnd = new OleDbCommand("select veri from verikayit where satir = @satir and sutun = @sutun and isim = @isim", blnt);
                                    cnd.Parameters.Add("@satir", OleDbType.VarChar).Value=j;
                                    cnd.Parameters.Add("@sutun", OleDbType.VarChar).Value = i;
                                    cnd.Parameters.Add("@isim", OleDbType.VarChar).Value =a;
                                  /*  cnd.Parameters.AddWithValue("@satir", j);
                                    cnd.Parameters.AddWithValue("@sutun", i);
                                    cnd.Parameters.AddWithValue("@isim", a);*/
                                    OleDbDataReader dr = cnd.ExecuteReader();
                                    if(dr.Read())
                                    {
                                        string asdf =dr["veri"].ToString();
                                        string qwer = "";

                                        //
                                        #region sifrecozme
                                        if (asdf == "Z") qwer = "q";
                                        else if (asdf == "X") qwer = "w";
                                        else if (asdf == "C") qwer = "e";
                                        else if (asdf == "V") qwer = "r";
                                        else if (asdf == "B") qwer = "t";
                                        else if (asdf == "N") qwer = "y";
                                        else if (asdf == "M") qwer = "u";
                                        else if (asdf == "Ö") qwer = "ı";
                                        else if (asdf == "Ç") qwer = "o";
                                        else if (asdf == "A") qwer = "p";
                                        else if (asdf == "S") qwer = "ğ";
                                        else if (asdf == "D") qwer = "ü";
                                        else if (asdf == "F") qwer = "a";
                                        else if (asdf == "G") qwer = "s";
                                        else if (asdf == "H") qwer = "d";
                                        else if (asdf == "J") qwer = "f";
                                        else if (asdf == "k") qwer = "g";
                                        else if (asdf == "l") qwer = "h";
                                        else if (asdf == "ş") qwer = "j";
                                        else if (asdf == "i") qwer = "k";
                                        else if (asdf == "q") qwer = "l";
                                        else if (asdf == "w") qwer = "ş";
                                        else if (asdf == "e") qwer = "i";
                                        else if (asdf == "r") qwer = "z";
                                        else if (asdf == "t") qwer = "x";
                                        else if (asdf == "y") qwer = "c";
                                        else if (asdf == "u") qwer = "v";
                                        else if (asdf == "ı") qwer = "b";
                                        else if (asdf == "o") qwer = "n";
                                        else if (asdf == "p") qwer = "m";
                                        else if (asdf == "ğ") qwer = "ö";
                                        else if (asdf == "ü") qwer = "ç";
                                        else if (asdf == "z") qwer = "Q";
                                        else if (asdf == "x") qwer = "W";
                                        else if (asdf == "c") qwer = "E";
                                        else if (asdf == "v") qwer = "R";
                                        else if (asdf == "b") qwer = "T";
                                        else if (asdf == "n") qwer = "Y";
                                        else if (asdf == "m") qwer = "U";
                                        else if (asdf == "ö") qwer = "I";
                                        else if (asdf == "ç") qwer = "O";
                                        else if (asdf == "a") qwer = "P";
                                        else if (asdf == "s") qwer = "Ğ";
                                        else if (asdf == "d") qwer = "Ü";
                                        else if (asdf == "f") qwer = "A";
                                        else if (asdf == "g") qwer = "S";
                                        else if (asdf == "h") qwer = "D";
                                        else if (asdf == "j") qwer = "F";
                                        else if (asdf == "K") qwer = "G";
                                        else if (asdf == "L") qwer = "H";
                                        else if (asdf == "Ş") qwer = "J";
                                        else if (asdf == "İ") qwer = "K";
                                        else if (asdf == "Q") qwer = "L";
                                        else if (asdf == "W") qwer = "Ş";
                                        else if (asdf == "E") qwer = "İ";
                                        else if (asdf == "R") qwer = "Z";
                                        else if (asdf == "T") qwer = "X";
                                        else if (asdf == "Y") qwer = "C";
                                        else if (asdf == "U") qwer = "V";
                                        else if (asdf == "I") qwer = "B";
                                        else if (asdf == "O") qwer = "N";
                                        else if (asdf == "P") qwer = "M";
                                        else if (asdf == "Ğ") qwer = "Ö";
                                        else if (asdf == "Ü") qwer = "Ç";                                   
                                        else if (asdf == ".") qwer = ",";
                                        else if (asdf == ",") qwer = ".";
                                        else if (asdf == "<") qwer = ">";
                                        else if (asdf == ">") qwer = "<";
                                        #endregion
                                        //

                                        richTextBox1.Text += qwer;
                                    }

                                }

                            }

                        }
                        MessageBox.Show("Resminiz başarıyla cozumlendi");
                        baglan();

                        timer1.Stop();
                    }
                }
            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

    }
}
