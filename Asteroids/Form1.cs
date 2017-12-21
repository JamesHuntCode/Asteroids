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
        #region setup 

        Spaceship playerIcon;
        private List<Asteroid> asteroids = new List<Asteroid>();
        private List<Bullet> bullets = new List<Bullet>();

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

        #endregion

        #region prepare game (load objects)

        private void initGame()
        {
            // Initialize player icon
            this.playerIcon = new Spaceship(this.Width / 2, this.Height / 2, ((this.Width / 2) - 20), ((this.Height / 2) + 40), ((this.Width / 2) + 20), ((this.Height / 2) + 40));

            // Initialize asteroids
            Random rnd = new Random();
            for (int i = 0; i < 1; i++)
            {
                this.asteroids.Add(new Asteroid(0, 0, 100, rnd.Next(1), rnd.Next(1)));
            }

            // Timer to draw game
            Timer refreshGame = new Timer();
            refreshGame.Interval = 30;
            refreshGame.Tick += new EventHandler(draw);
            refreshGame.Start();
        }

        #endregion

        #region draw (play game)

        private void draw(object sender, EventArgs e)
        {
            // Draw canvas
            Graphics asteroids = this.picCanvas.CreateGraphics();
            asteroids.Clear(ColorTranslator.FromHtml("#333"));

            // Colors used
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Pen whitePen = new Pen(Color.White);

            // Draw asteroids
            for (int i = 0; i < this.asteroids.Count; i++)
            {
                asteroids.DrawEllipse(whitePen, Convert.ToInt32(this.asteroids[i].GetX()), Convert.ToInt32(this.asteroids[i].GetY()), Convert.ToInt32(this.asteroids[i].GetS()), Convert.ToInt32(this.asteroids[i].GetS()));
            }

            // Draw player icon (spaceship)
            asteroids.FillPolygon(whiteBrush, this.playerIcon.GetCoords());
            this.playerIcon.UpdatePos();
            this.playerIcon.Fly();
            this.playerIcon.Bounds(0, this.Height, 0, this.Width);

            // Draw bullets

        }

        #endregion 

        #region movement control 

        private void keyPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    this.playerIcon.ApplyMovement(1);
                    break;
                case Keys.Down:
                    this.playerIcon.ApplyMovement(2);
                    break;
                case Keys.Left:
                    this.playerIcon.ApplyMovement(3);
                    break;
                case Keys.Right:
                    this.playerIcon.ApplyMovement(4);
                    break;
                case Keys.Space:
                    // Shoot
                    break;
            }
        }

        #endregion 
    }
}
