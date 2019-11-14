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
using Microsoft.VisualBasic;

namespace WindowsFormsApplication8
{
    public partial class SIFRELEME : Form
    {
        public SIFRELEME()
        {
            InitializeComponent();
        }
        OleDbConnection blnt = new OleDbConnection("provider=microsoft.ace.oledb.12.0; Data source =sifreleme.accdb");

        void baglan()
        {
            if (blnt.State == ConnectionState.Closed) { blnt.Open(); }
        }

        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "" || richTextBox1.Text == "")
                    MessageBox.Show("Boş alan bırakmayınız.");
                else
                {
                    baglan();
                    Bitmap bmp1 = new Bitmap(pictureBox1.Image);
                    //resmimizi bitmape atadık               
                    string[,] bpmpixeli = new string[bmp1.Height, bmp1.Width];
                    //                                    satır   sütun      
                    string sivrelencek = richTextBox1.Text;
                    char[] harfler = sivrelencek.ToCharArray();
                    string sifrelenecek_Ad = textBox3.Text;
                    progressBar1.Maximum = richTextBox1.TextLength;
                    using (OleDbCommand cmd = new OleDbCommand("select isim from verikayit  where isim = @isim", blnt))
                    {
                        cmd.Parameters.Add("@isim", OleDbType.VarChar).Value = sifrelenecek_Ad;
                        OleDbDataReader rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            MessageBox.Show("\"" + rd["isim"].ToString() + "\"" + " Adındaki çözme kodu daha önce alınmış lütfen başka bir çözme kodu giriniz...");
                        }
                        else
                        {

                            #region metni değiştirme

                            for (int i = 0; i <= harfler.Length - 1; i++)
                            {
                                if (harfler[i] == 'q') harfler[i] = 'Z';
                                else if (harfler[i] == 'w') harfler[i] = 'X';
                                else if (harfler[i] == 'e') harfler[i] = 'C';
                                else if (harfler[i] == 'r') harfler[i] = 'V';
                                else if (harfler[i] == 't') harfler[i] = 'B';
                                else if (harfler[i] == 'y') harfler[i] = 'N';
                                else if (harfler[i] == 'u') harfler[i] = 'M';
                                else if (harfler[i] == 'ı') harfler[i] = 'Ö';
                                else if (harfler[i] == 'o') harfler[i] = 'Ç';
                                else if (harfler[i] == 'p') harfler[i] = 'A';
                                else if (harfler[i] == 'ğ') harfler[i] = 'S';
                                else if (harfler[i] == 'ü') harfler[i] = 'D';
                                else if (harfler[i] == 'a') harfler[i] = 'F';
                                else if (harfler[i] == 's') harfler[i] = 'G';
                                else if (harfler[i] == 'd') harfler[i] = 'H';
                                else if (harfler[i] == 'f') harfler[i] = 'J';
                                else if (harfler[i] == 'g') harfler[i] = 'k';
                                else if (harfler[i] == 'h') harfler[i] = 'l';
                                else if (harfler[i] == 'j') harfler[i] = 'ş';
                                else if (harfler[i] == 'k') harfler[i] = 'i';
                                else if (harfler[i] == 'l') harfler[i] = 'q';
                                else if (harfler[i] == 'ş') harfler[i] = 'w';
                                else if (harfler[i] == 'i') harfler[i] = 'e';
                                else if (harfler[i] == 'z') harfler[i] = 'r';
                                else if (harfler[i] == 'x') harfler[i] = 't';
                                else if (harfler[i] == 'c') harfler[i] = 'y';
                                else if (harfler[i] == 'v') harfler[i] = 'u';
                                else if (harfler[i] == 'b') harfler[i] = 'ı';
                                else if (harfler[i] == 'n') harfler[i] = 'o';
                                else if (harfler[i] == 'm') harfler[i] = 'p';
                                else if (harfler[i] == 'ö') harfler[i] = 'ğ';
                                else if (harfler[i] == 'ç') harfler[i] = 'ü';
                                else if (harfler[i] == 'Q') harfler[i] = 'z';
                                else if (harfler[i] == 'W') harfler[i] = 'x';
                                else if (harfler[i] == 'E') harfler[i] = 'c';
                                else if (harfler[i] == 'R') harfler[i] = 'v';
                                else if (harfler[i] == 'T') harfler[i] = 'b';
                                else if (harfler[i] == 'Y') harfler[i] = 'n';
                                else if (harfler[i] == 'U') harfler[i] = 'm';
                                else if (harfler[i] == 'I') harfler[i] = 'ö';
                                else if (harfler[i] == 'O') harfler[i] = 'ç';
                                else if (harfler[i] == 'P') harfler[i] = 'a';
                                else if (harfler[i] == 'Ğ') harfler[i] = 's';
                                else if (harfler[i] == 'Ü') harfler[i] = 'd';
                                else if (harfler[i] == 'A') harfler[i] = 'f';
                                else if (harfler[i] == 'S') harfler[i] = 'g';
                                else if (harfler[i] == 'D') harfler[i] = 'h';
                                else if (harfler[i] == 'F') harfler[i] = 'j';
                                else if (harfler[i] == 'G') harfler[i] = 'K';
                                else if (harfler[i] == 'H') harfler[i] = 'L';
                                else if (harfler[i] == 'J') harfler[i] = 'Ş';
                                else if (harfler[i] == 'K') harfler[i] = 'İ';
                                else if (harfler[i] == 'L') harfler[i] = 'Q';
                                else if (harfler[i] == 'Ş') harfler[i] = 'W';
                                else if (harfler[i] == 'İ') harfler[i] = 'E';
                                else if (harfler[i] == 'Z') harfler[i] = 'R';
                                else if (harfler[i] == 'X') harfler[i] = 'T';
                                else if (harfler[i] == 'C') harfler[i] = 'Y';
                                else if (harfler[i] == 'V') harfler[i] = 'U';
                                else if (harfler[i] == 'B') harfler[i] = 'I';
                                else if (harfler[i] == 'N') harfler[i] = 'O';
                                else if (harfler[i] == 'M') harfler[i] = 'P';
                                else if (harfler[i] == 'Ö') harfler[i] = 'Ğ';
                                else if (harfler[i] == 'Ç') harfler[i] = 'Ü';

                                else if (harfler[i] == '.') harfler[i] = ',';
                                else if (harfler[i] == ',') harfler[i] = '.';
                                else if (harfler[i] == '<') harfler[i] = '>';
                                else if (harfler[i] == '>') harfler[i] = '<';

                            }
                            #endregion

                            Color r;
                            for (int i = 0; i < harfler.Length; i++)
                            {
                                int a = rnd.Next(0, bmp1.Width);
                                bpmpixeli[i, a] = harfler[i].ToString();
                                //satır sütun                                                            
                                #region Piksel rengini değiştirme
                                r = bmp1.GetPixel(a, i);//rengimizi aldık
                                int A = r.A; //rengimizin alfa kanalını aldık
                                int R = r.R; R = R == 255 ? R - 1 : R + 1;
                                /*renk kodları 0-255 arası oldugu için hata almamak 
                                için kontrol ettirdik renk kodunu 1 arttırdık ve ya 
                                azalttık rengimizin kırmızı RED tonu*/
                                int G = r.G; G = G == 255 ? G - 1 : G + 1;
                                //rengimizin yeşil tonu
                                int B = r.B; B = B == 255 ? B - 1 : B + 1;
                                //rengimizin mavi tonunu aldık 
                                r = Color.FromArgb(A, R, G, B);
                                //düzenlediğimiz renk kodunu tekrar color sınıfından r ye atadık
                                bmp1.SetPixel(a, i, r);
                                //bpm1.SetPixel(a, i, Color.White);
                                pictureBox1.Image = bmp1;
                                #endregion
                                progressBar1.Value += 1;
                                #region gereksizler
                                /* r = bpm2.GetPixel(i, asd);
                                alfa kanalı hariç diğer kanalların tersini al
                                r = Color.FromArgb(r.A, (byte)~r.R, (byte)~r.G, (byte)~r.B);
                                 bpm2.SetPixel(i, a, r);//aynı noktaya tekrar koy   */
                                #endregion
                                OleDbCommand cmd1 = new OleDbCommand(@"INSERT INTO verikayit VALUES (satir,sutun,isim,veri)", blnt);
                                cmd1.Parameters.Add("@satir", OleDbType.VarChar).Value = a;
                                cmd1.Parameters.Add("@sutun", OleDbType.VarChar).Value = i;
                                cmd1.Parameters.Add("@isim", OleDbType.VarChar).Value = sifrelenecek_Ad;
                                cmd1.Parameters.Add("@veri", OleDbType.VarChar).Value = harfler[i];
                                cmd1.ExecuteNonQuery();
                            }
                            pictureBox1.Image.Save("resimlerim/" + textBox3.Text + DosyaUzantisi);
                            MessageBox.Show("Resim başarılı bir şekilde şifrelendi yeni bir şifreleme yapmak istiyorsanız yukarıdaki restart tuşuna basınız.");
                            button1.Enabled = false;
                            button2.Enabled = false;
                            button3.Enabled = false;
                            richTextBox1.Enabled = false;
                            textBox3.Enabled = false;
                            // label6.Visible = false;
                        }
                    }
                }
            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }

        }
        string DosyaUzantisi;
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string a = openFileDialog1.FileName;
            if (a != "openFileDialog1")
            {
                pictureBox1.ImageLocation = a;
                System.IO.FileInfo ff = new System.IO.FileInfo(openFileDialog1.FileName);
                DosyaUzantisi = ff.Extension;
                timer1.Start();
            }
            else
                MessageBox.Show("Resim seçilmedi");

        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void SIFRELEME_Load(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(this, "Konumlandırmak için tıklayın ve fareyi oynatın");
            pictureBox2.ImageLocation = "anasayfa.jpg";
            pictureBox4.ImageLocation = "exit.png";
            pictureBox5.ImageLocation = "restart1.png";
            pictureBox6.ImageLocation = "simgedrm.png";
            ToolTip aciklama = new ToolTip();
            aciklama.ToolTipIcon = ToolTipIcon.Warning;
            aciklama.IsBalloon = true;
            aciklama.SetToolTip(button2, "Burada şifreleceğimiz resmi seçiyoruz.");
            aciklama.SetToolTip(textBox3, "Buradaki kodu not etmeyi unutmayalım daha sonra lazım olacak!!");
            ToolTip aciklama3 = new ToolTip();
            aciklama3.ToolTipIcon = ToolTipIcon.Warning;
            aciklama3.IsBalloon = true;
            aciklama3.ToolTipTitle = "Dikkat";
            aciklama3.SetToolTip(pictureBox2, "Buradan anasayfaya gidebiliriz.");
            aciklama3.SetToolTip(pictureBox5, "Buradan yeni resim şifresi çözmek için yeniden başlatabiliriz.");
            aciklama3.SetToolTip(pictureBox4, "Burada uygulamayı kapatırız.");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult drg = MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult drg = MessageBox.Show("Yeni bir şifreleme yapmak istediğinize eminmisiniz?", "YENİDEN BAŞLAT", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                SIFRELEME frm = new SIFRELEME();
                this.Hide();
                frm.label2.Text = label2.Text;
                frm.pictureBox3.ImageLocation = pictureBox3.ImageLocation;
                frm.Show();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult a = MessageBox.Show("çıkış yapmak istediğine eminmisin?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (a == DialogResult.Yes)
            {
                kullanicigiris frm = new kullanicigiris();
                frm.Show();
                this.Hide();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        int karakter;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bpm = new Bitmap(pictureBox1.Image);
            karakter = bpm.Height;
            richTextBox1.MaxLength = bpm.Height;
            label6.Text = "(Max. " + karakter + "/" + karakter.ToString() + ")";
            timer1.Stop();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            label6.Text = "(Max. " + karakter + "/" + (karakter - richTextBox1.Text.Length).ToString() + ")";
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void SIFRELEME_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void SIFRELEME_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void SIFRELEME_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int krktr_sayisi = int.Parse(Interaction.InputBox(@"Kaç karakterlik veri şifreleyeceksiniz?"
                    , "Karakter Sayısı"));

                Bitmap bmp = new Bitmap(krktr_sayisi, krktr_sayisi);

                for (int i = 0; i < krktr_sayisi; i++)
                {
                    for (int j = 0; j < krktr_sayisi; j++)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                        pictureBox1.Image = bmp;
                    }
                }
                SaveFileDialog sfd = new SaveFileDialog();//yeni bir kaydetme diyaloğu oluşturuyoruz.
                sfd.Filter = "png(*.png)|*.png";//.bmp veya .jpg olarak kayıt imkanı sağlıyoruz.
                sfd.Title = "Kayıt";//diğaloğumuzun başlığını belirliyoruz.
                sfd.FileName = rnd.Next().ToString();//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.
                DialogResult sonuç = sfd.ShowDialog();
                if (sonuç == DialogResult.OK)
                {
                    pictureBox1.Image.Save(sfd.FileName);//Böylelikle resmi istediğimiz yere kaydediyoruz.                  
                    string a = sfd.FileName;
                    pictureBox1.ImageLocation = a;
                    System.IO.FileInfo ff = new System.IO.FileInfo(sfd.FileName);
                    DosyaUzantisi = ff.Extension;
                    timer1.Start();
                }
                else { MessageBox.Show("Resim oluşturulamadı."); pictureBox1.ImageLocation = ""; }
            }
            catch
            {
                MessageBox.Show("Bir hata oluştu lütfen tekrar deneyin.");
            }
        }
    }
}

