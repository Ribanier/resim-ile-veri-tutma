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
    public partial class ANASAYFA : Form
    {
        public ANASAYFA()
        {
            InitializeComponent();
        }

        OleDbConnection blnt = new OleDbConnection("provider=microsoft.ace.oledb.12.0; Data source =sifreleme.accdb");
        void baglan()
        {
            if (blnt.State == ConnectionState.Closed) { blnt.Open(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SIFRELEME sfr = new SIFRELEME();
            sfr.Show();
            this.Hide();
            sfr.label2.Text = label3.Text;
            sfr.pictureBox3.ImageLocation = "kullaniciresimleri/" + label3.Text + ".jpg";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            COZME sfr = new COZME();
            sfr.Show();
            this.Hide();
            sfr.label2.Text = label3.Text;
            sfr.pictureBox6.ImageLocation = "kullaniciresimleri/" + label3.Text + ".jpg";

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult drg = MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (drg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ANASAYFA_Load(object sender, EventArgs e)
        {
            pictureBox4.ImageLocation = "exit.png";
            pictureBox2.ImageLocation = "simgedrm.png";
            ToolTip tp = new ToolTip();
            tp.SetToolTip(this, "Konumlandırmak için tıklayın ve fareyi oynatın");

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            baglan();
            profil frm = new profil();
            using (OleDbCommand cmd = new OleDbCommand("select eposta from kullaniciveri where ad=@adi", blnt))
            {
                cmd.Parameters.Add("adi", OleDbType.VarChar).Value = label3.Text;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    frm.label4.Text = rd["eposta"].ToString();
                }
                this.Hide();
                frm.Show();
                frm.label2.Text = label3.Text;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int _move;
        int Mouse_X;
        int Mouse_Y;
        private void ANASAYFA_MouseUp(object sender, MouseEventArgs e)
        {
            _move = 0;
        }

        private void ANASAYFA_MouseMove(object sender, MouseEventArgs e)
        {
            if (_move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void ANASAYFA_MouseDown(object sender, MouseEventArgs e)
        {
            _move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
