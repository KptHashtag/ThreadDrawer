using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ThreadDrawer
{
    public partial class Form1 : Form
    {
        Bitmap ba = new Bitmap(256, 256);
        Bitmap bb = new Bitmap(256, 256);
        Bitmap bc = new Bitmap(256, 256);
        Bitmap bd = new Bitmap(256, 256);
        private System.Windows.Forms.Timer tt;
        public void InitTimer()
        {
            tt = new System.Windows.Forms.Timer();
            tt.Tick += new EventHandler(tt_Tick);
            tt.Interval = 1000;
            tt.Start();
        }
        private void tt_Tick(object sender, EventArgs e)
        {
            /*
            pictureBox1.Image = ba;
            pictureBox2.Image = bb;
            pictureBox3.Image = bc;
            pictureBox4.Image = bd;
            */
        }
        public Form1()
        {
            InitializeComponent();
        }
        public void Draw(PictureBox p, Bitmap x)
        {

            int xx = 0, yy = 0;
            Random rd = new Random();
            while (true)
            {
                
                xx = rd.Next(1, 255);
                yy = rd.Next(1, 255);
                this.Invoke((MethodInvoker)delegate {
                    x.SetPixel(xx, yy, Color.FromArgb(xx, yy, xx/2 + yy/2));
                p.Image = x;
                });
                Thread.Sleep(1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread ta = new Thread(x => { Draw(pictureBox1, ba); });
            ta.Start();
            Thread tb = new Thread(x => { Draw(pictureBox2, bb); });
            tb.Start();
            Thread tc = new Thread(x => { Draw(pictureBox3, bc); });
            tc.Start();
            Thread td = new Thread(x => { Draw(pictureBox4, bd); });
            td.Start();
            Thread.Sleep(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap merged = new Bitmap(256, 256);
        }
    }
}
