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
namespace WindowsFormsApplication8
{
    public partial class kullanicigiris : Form
    {
        public kullanicigiris()
        {
            InitializeComponent();
        }
        OleDbConnection blnt = new OleDbConnection("provider=microsoft.ace.oledb.12.0; Data source =sifreleme.accdb");
        //veritabanın adı
        void baglan()
        {
            if (blnt.State == ConnectionState.Closed) { blnt.Open(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan();
            OleDbCommand cmd = new OleDbCommand("select * from kullaniciveri where ad = '" + textBox1.Text + "' and sifre = '" + textBox2.Text + "'", blnt);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ANASAYFA rsm = new ANASAYFA();
                rsm.Show();
                this.Hide();
                rsm.label3.Text = textBox1.Text;
                rsm.pictureBox1.ImageLocation = "kullaniciresimleri/" + textBox1.Text + ".jpg";
            }
            else
            {
                MessageBox.Show("Kullanıcı girişi başarısız bilgilerinizi kontrol ediniz.");textBox2.Clear();
                if (textBox1.Text == null)
                    textBox1.Focus();
                else textBox1.Focus();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kullnicikayit frm = new kullnicikayit();
            frm.Show();
            this.Hide();
        }



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult drg = MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void kullanicigiris_Load(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(this, "Konumlandırmak için tıklayın ve fareyi oynatın");
            pictureBox5.ImageLocation = "simgedrm.png";
            textBox1.Focus();
            pictureBox4.ImageLocation = "exit.png";
            pictureBox3.ImageLocation = "goz.png";
            textBox2.PasswordChar = '*';
            label1.Visible = false;
            label2.Visible = false;
            if (textBox2.Text == "Şifre")
            {
                textBox2.PasswordChar = '\0';
            }
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifremiunuttum frm = new sifremiunuttum();
            this.Hide();
            frm.Show();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifremiunuttum frm = new sifremiunuttum();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

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

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Clear();
                label1.Visible = true;
            }


            if (textBox2.Text == "")
            {
                label2.Visible = false;
                textBox2.Text = "Şifre";
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
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*'; label2.Visible = true;

            }
                
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "Kullanıcı Adı")
            {
                label1.Visible = true;

            }
        }

        private void kullanicigiris_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;   
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void kullanicigiris_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void kullanicigiris_MouseMove(object sender, MouseEventArgs e)
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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }
    }
}
