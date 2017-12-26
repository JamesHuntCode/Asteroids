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

        private Spaceship playerIcon;
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
            int randomS;
            int randomX, randomY;
            int randomVelX, randomVelY;
            int tempVelX = -1, tempVelY = -1;

            for (int i = 0; i < 5; i++)
            {
                randomVelX = rnd.Next(-3, 3);
                randomVelY = rnd.Next(-3, 3);
                randomS = rnd.Next(100, 150);
                randomX = rnd.Next(0, this.Width);
                randomY = rnd.Next(0, this.Height);

                while (randomVelX == tempVelX || randomVelX == 0)
                {
                    randomVelX = rnd.Next(1, 3);
                }

                while (randomVelY == tempVelY || randomVelY == 0)
                {
                    randomVelY = rnd.Next(1, 3);
                }

                while (randomX > (this.Width / 2) && randomX < (this.Width / 2) + 50)
                {
                    randomX = rnd.Next(0, this.Width);
                }

                while (randomY > (this.Height / 2) && randomY < (this.Height) / 2 + 50)
                {
                    randomY = rnd.Next(0, this.Height);
                }

                this.asteroids.Add(new Asteroid(randomX, randomY, randomS, randomVelX, randomVelY));

                tempVelX = randomVelX;
                tempVelY = randomVelY;
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
            whitePen.Width = 3;

            // Draw asteroids
            for (int i = 0; i < this.asteroids.Count; i++)
            {
                asteroids.DrawEllipse(whitePen, Convert.ToInt32(this.asteroids[i].GetX()), Convert.ToInt32(this.asteroids[i].GetY()), Convert.ToInt32(this.asteroids[i].GetS()), Convert.ToInt32(this.asteroids[i].GetS()));

                this.asteroids[i].Move();
                this.asteroids[i].Bounds(0, 0, this.Height, this.Width);

                if (this.asteroids[i].HitsPlayer(this.playerIcon))
                {
                    Application.Restart();
                    Environment.Exit(0);
                }
            }

            // Draw player icon (spaceship)
            asteroids.FillPolygon(whiteBrush, this.playerIcon.GetCoords());

            this.playerIcon.UpdatePos();
            this.playerIcon.Fly();
            this.playerIcon.Bounds(0, this.Height, 0, this.Width);

            // Draw bullets
            for (int i = 0; i < this.bullets.Count; i++)
            {
                if (this.bullets[i].GetStatus())
                {
                    asteroids.FillRectangle(whiteBrush, this.bullets[i].GetPosX(), this.bullets[i].GetPosY(), this.bullets[i].GetW(), this.bullets[i].GetH());
                    this.bullets[i].Move();

                    if (this.bullets[i].OffScreen(0, this.Width, 0, this.Height))
                    {
                        this.bullets.Remove(this.bullets[i]);
                    }
                    else
                    {
                        Random rnd = new Random();
                        for (int j = 0; j < this.asteroids.Count; j++)
                        {
                            if (this.bullets[i].HitsAsteroid(this.asteroids[j]))
                            {
                                if (this.asteroids[j].GetS() >= 100)
                                {
                                    // Add 2 new asteroids 
                                    int velX = rnd.Next(-3, 3), velY = rnd.Next(-3, 3), velX2 = rnd.Next(-3, 3), velY2 = rnd.Next(-3, 3);
                                    while (velX == 0 || velY == 0 || velX == velX2 || velY == velY2)
                                    {
                                        velX = rnd.Next(-3, 3); 
                                        velY = rnd.Next(-3, 3);
                                        velX2 = rnd.Next(-3, 3);
                                        velY2 = rnd.Next(-3, 3);
                                    }
                                    this.asteroids.Add(new Asteroid(Convert.ToInt32(this.asteroids[j].GetX()), Convert.ToInt32(this.asteroids[j].GetY()), Convert.ToInt32(this.asteroids[j].GetS()) / 2, velX, velY));
                                    this.asteroids.Add(new Asteroid(Convert.ToInt32(this.asteroids[j].GetX()), Convert.ToInt32(this.asteroids[j].GetY()), Convert.ToInt32(this.asteroids[j].GetS()) / 2, velX2, velY2));
                                    this.asteroids.Remove(this.asteroids[j]);
                                } 
                                else
                                {
                                    this.asteroids.Remove(this.asteroids[j]);
                                }
                                this.bullets[i].SetStatus(false);
                            }
                        }
                    }
                }
                else
                {
                    this.bullets.Remove(this.bullets[i]);
                }
            }
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

                    if (this.playerIcon.GetRotateValue() == 1) // Shoot up
                    {
                        this.bullets.Add(new Bullet(Convert.ToInt32(this.playerIcon.GetGeneralPosX() + 5), Convert.ToInt32(this.playerIcon.GetGeneralPosY()), 0, -20));
                    }
                    else if (this.playerIcon.GetRotateValue() == 2) // Shoot down
                    {
                        this.bullets.Add(new Bullet(Convert.ToInt32(this.playerIcon.GetGeneralPosX() - 30), Convert.ToInt32(this.playerIcon.GetGeneralPosY()), 0, 20));
                    }
                    else if (this.playerIcon.GetRotateValue() == 3) // Shoot left
                    {
                        this.bullets.Add(new Bullet(Convert.ToInt32(this.playerIcon.GetGeneralPosX()) - 30, Convert.ToInt32(this.playerIcon.GetGeneralPosY()), -20, 0));
                    }
                    else // Shoot right
                    {
                        this.bullets.Add(new Bullet(Convert.ToInt32(this.playerIcon.GetGeneralPosX()), Convert.ToInt32(this.playerIcon.GetGeneralPosY()), 20, 0));
                    }

                    break;
            }
        }

        #endregion 
    }
}
