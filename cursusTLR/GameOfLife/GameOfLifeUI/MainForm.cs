using GameOfLife;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaOfLifeUI
{
    public partial class MainForm : Form
    {

        private readonly PictureBox pictureBox1 = new();
        private readonly SeaOflife seaOfLife = new(134,87);
        private readonly Timer timer = new();

        public MainForm()
        {
            InitializeComponent();

            // Dock the PictureBox to the form and set its background to white.
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.Gray;
            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new(this.pictureBox1_Paint);

            // Add the PictureBox control to the Form.
            this.Controls.Add(pictureBox1);

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seaOfLife.CalculateNextState();
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
            var whitePen = new Pen(Color.FromArgb(255, 255, 255, 255), 5);

            foreach (var amoube in seaOfLife.Amoubes)
            {
                e.Graphics.DrawRectangle(amoube.CurrentState ? blackPen : whitePen, 10 + amoube.X + (9*amoube.X), 10 + amoube.Y + (9 * amoube.Y), 4, 4);
            }
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                this.timer.Stop();
                this.button1.Text = "Start";
            } else
            {
                this.timer.Start();
                this.button1.Text = "Stop";
            }
        }
    }
}
