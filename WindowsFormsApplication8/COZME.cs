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
                    using (OleDbCommand cmd = new OleDbCommand("Delete * from verikayit where isim = @isim", blnt))
                    {
                        cmd.Parameters.Add("@isim", OleDbType.VarChar).Value = textBox4.Text;
                        MessageBox.Show("Verileriniz başarıyla silindi.");
                    }

                }
                else
                    MessageBox.Show("Resminiz kayıtlardan silinmedi");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG;)|*.BMP;*.JPG;*.JPEG;*.PNG;";
            openFileDialog1.ShowDialog(); string a = openFileDialog1.FileName;
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
            using (OleDbCommand cmd = new OleDbCommand("select eposta from kullaniciveri where ad=@adi", blnt))
            {
                cmd.Parameters.Add("@adi", OleDbType.VarChar).Value = label2.Text;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    frm.label4.Text = rd["eposta"].ToString();
                }
                this.Hide();
                frm.Show();
                frm.label2.Text = label2.Text;

            }

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
                    using (OleDbCommand cmd = new OleDbCommand("select isim from verikayit where isim =@isim", blnt))
                    {
                        cmd.Parameters.Add("@isim", OleDbType.VarChar).Value = a;
                        OleDbDataReader rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            button1.Visible = false;
                            button2.Visible = false;
                            textBox4.Visible = false;
                            label6.Visible = false;
                            richTextBox1.Visible = true;
                            System.Threading.Thread.Sleep(100);
                            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
                            Bitmap bmp2 = new Bitmap(pictureBox3.Image);
                            progressBar1.Maximum = bmp1.Height;
                            for (int i = 0; i < bmp2.Height; i++)
                            {                      //yükseklik y

                                (progressBar1.Value)++;
                                for (int j = 0; j < bmp2.Width; j++)
                                {                    //genişlik x
                                    Color clr1 = bmp1.GetPixel(j, i);
                                    //satır sütun               x,y 
                                    Color clr2 = bmp2.GetPixel(j, i);
                                    if (clr1 != clr2)//iki pikselin rengini kontrol ettik
                                    {
                                        //OleDbCommand cnd = new OleDbCommand("select veri from verikayit where satir = '" + j.ToString() + "' and sutun ='" + i.ToString() + "' and isim = '" + a + "'", blnt);
                                        using (OleDbCommand cnd = new OleDbCommand(@"select veri from verikayit where 
                                           satir = @satir and 
                                               sutun = @sutun and 
                                                   isim = @isim", blnt))
                                        {
                                            cnd.Parameters.Add("@satir", OleDbType.VarChar).Value = j;
                                            cnd.Parameters.Add("@sutun", OleDbType.VarChar).Value = i;
                                            cnd.Parameters.Add("@isim", OleDbType.VarChar).Value = a;
                                            /*  cnd.Parameters.AddWithValue("@satir", j);
                                              cnd.Parameters.AddWithValue("@sutun", i);
                                              cnd.Parameters.AddWithValue("@isim", a);*/
                                            var result = (string)cnd.ExecuteScalar();//veri cekme
                                            string lastresult = "";

                                            //
                                            #region sifrecozme
                                            if (result == "Z") lastresult = "q";
                                            else if (result == "X") lastresult = "w";
                                            else if (result == "C") lastresult = "e";
                                            else if (result == "V") lastresult = "r";
                                            else if (result == "B") lastresult = "t";
                                            else if (result == "N") lastresult = "y";
                                            else if (result == "M") lastresult = "u";
                                            else if (result == "Ö") lastresult = "ı";
                                            else if (result == "Ç") lastresult = "o";
                                            else if (result == "A") lastresult = "p";
                                            else if (result == "S") lastresult = "ğ";
                                            else if (result == "D") lastresult = "ü";
                                            else if (result == "F") lastresult = "a";
                                            else if (result == "G") lastresult = "s";
                                            else if (result == "H") lastresult = "d";
                                            else if (result == "J") lastresult = "f";
                                            else if (result == "k") lastresult = "g";
                                            else if (result == "l") lastresult = "h";
                                            else if (result == "ş") lastresult = "j";
                                            else if (result == "i") lastresult = "k";
                                            else if (result == "q") lastresult = "l";
                                            else if (result == "w") lastresult = "ş";
                                            else if (result == "e") lastresult = "i";
                                            else if (result == "r") lastresult = "z";
                                            else if (result == "t") lastresult = "x";
                                            else if (result == "y") lastresult = "c";
                                            else if (result == "u") lastresult = "v";
                                            else if (result == "ı") lastresult = "b";
                                            else if (result == "o") lastresult = "n";
                                            else if (result == "p") lastresult = "m";
                                            else if (result == "ğ") lastresult = "ö";
                                            else if (result == "ü") lastresult = "ç";
                                            else if (result == "z") lastresult = "Q";
                                            else if (result == "x") lastresult = "W";
                                            else if (result == "c") lastresult = "E";
                                            else if (result == "v") lastresult = "R";
                                            else if (result == "b") lastresult = "T";
                                            else if (result == "n") lastresult = "Y";
                                            else if (result == "m") lastresult = "U";
                                            else if (result == "ö") lastresult = "I";
                                            else if (result == "ç") lastresult = "O";
                                            else if (result == "a") lastresult = "P";
                                            else if (result == "s") lastresult = "Ğ";
                                            else if (result == "d") lastresult = "Ü";
                                            else if (result == "f") lastresult = "A";
                                            else if (result == "g") lastresult = "S";
                                            else if (result == "h") lastresult = "D";
                                            else if (result == "j") lastresult = "F";
                                            else if (result == "K") lastresult = "G";
                                            else if (result == "L") lastresult = "H";
                                            else if (result == "Ş") lastresult = "J";
                                            else if (result == "İ") lastresult = "K";
                                            else if (result == "Q") lastresult = "L";
                                            else if (result == "W") lastresult = "Ş";
                                            else if (result == "E") lastresult = "İ";
                                            else if (result == "R") lastresult = "Z";
                                            else if (result == "T") lastresult = "X";
                                            else if (result == "Y") lastresult = "C";
                                            else if (result == "U") lastresult = "V";
                                            else if (result == "I") lastresult = "B";
                                            else if (result == "O") lastresult = "N";
                                            else if (result == "P") lastresult = "M";
                                            else if (result == "Ğ") lastresult = "Ö";
                                            else if (result == "Ü") lastresult = "Ç";
                                            else if (result == ".") lastresult = ",";
                                            else if (result == ",") lastresult = ".";
                                            else if (result == "<") lastresult = ">";
                                            else if (result == ">") lastresult = "<";
                                            else lastresult = result;
                                            #endregion
                                            //

                                            richTextBox1.Text += lastresult;

                                        }

                                    }

                                }

                            }
                            MessageBox.Show("Resminiz başarıyla cozumlendi");
                            baglan();

                            timer1.Stop();
                        }

                        else
                        {
                            MessageBox.Show("Böyle bir kayıt bulunamadı lütfen kontrol ederek tekrar deneyiniz..." + blnt);
                        }
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