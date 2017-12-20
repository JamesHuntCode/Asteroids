using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Setup game:
            this.Text = "Asteroids - James Hunt";
            this.Height = 740;
            this.Width = 715;
            this.picCanvas.Height = 700;
            this.picCanvas.Width = 700;
            this.picCanvas.Location = new Point(0, 0);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.initGame();
        }

        private void initGame()
        {
            // Timer to draw game
            Timer refreshGame = new Timer();
            refreshGame.Interval = 20;
            refreshGame.Tick += new EventHandler(draw);
            refreshGame.Start();
        }

        private void draw(object sender, EventArgs e)
        {
            // Draw canvas
            Graphics asteroids = this.picCanvas.CreateGraphics();
            asteroids.Clear(ColorTranslator.FromHtml("#333"));
            
            // Draw asteroids


            // Draw player icon (spaceship)


            // Draw bullets

        }
    }
}
