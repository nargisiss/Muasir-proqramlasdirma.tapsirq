
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace bomba.oyun
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<Panel> paneller = new List<Panel>();
        int count = 0;

        public Form1()
        {
            InitializeComponent();

            button2.Click += button2_Click;
            button3.Click += button3_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            label2.Text = count.ToString();

            Panel p = new Panel();
            p.Size = new Size(60, 60);

            p.Location = new Point(
                random.Next(0, Math.Max(1, this.ClientSize.Width - 60)),
                random.Next(0, Math.Max(1, panel1.Top - 60))
            );

            p.BackColor = Color.FromArgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256)
            );

            this.Controls.Add(p);
            paneller.Add(p);

            pictureBox1.BringToFront();
            panel1.BringToFront();

            if (p.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                GameOver();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(
                random.Next(0, Math.Max(1, this.ClientSize.Width - pictureBox1.Width)),
                random.Next(0, Math.Max(1, panel1.Top - pictureBox1.Height))
            );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GameOver()
        {
            MessageBox.Show("Oyun bitdi!", "Bildiriş",
                MessageBoxButtons.OK);

            foreach (Panel p in paneller)
            {
                this.Controls.Remove(p);
                p.Dispose();
            }

            paneller.Clear();

            count = 0;
            label2.Text = "0";
        }
    }
}
