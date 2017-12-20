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
        Spaceship playerIcon;

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

            this.KeyDown += this.keyPressed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.initGame();
        }

        private void initGame()
        {
            // Initialize player icon
            this.playerIcon = new Spaceship(this.Width / 2, this.Height / 2, ((this.Width / 2) + 20), ((this.Height / 2) + 40), ((this.Width / 2) - 20), ((this.Height / 2) + 40));

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

            // Brushes used
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            // Draw asteroids


            // Draw player icon (spaceship)
            
            asteroids.FillPolygon(whiteBrush, this.playerIcon.GetCoords());

            // Draw bullets

        }

        private void keyPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    this.playerIcon.Fly(1);
                    break;
                case Keys.Down:
                    this.playerIcon.Fly(2);
                    break;
                case Keys.Left:
                    this.playerIcon.Fly(3);
                    break;
                case Keys.Right:
                    this.playerIcon.Fly(4);
                    break;
            }
        }
    }
}
