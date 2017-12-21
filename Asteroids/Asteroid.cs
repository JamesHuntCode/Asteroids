using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Asteroid
    {
        // Properties:
        double posX;
        double posY;
        double size;
        int health = 200;

        // Movement Mechanics:
        double velX;
        double velY;

        // Constructor:
        public Asteroid(int x, int y, int s, double vX, double vY)
        {
            this.posX = x;
            this.posY = y;
            this.size = s;
            this.velX = vX;
            this.velY = vY;
        }

        // Setter Methods:


        // Getter Methods:
        public double GetX()
        {
            return this.posX;
        }

        public double GetY()
        {
            return this.posY;
        }

        public double GetS()
        {
            return this.size;
        }

        public int GetHealth()
        {
            return this.health;
        }

        // Custom Methods:
        public void Move()
        {
            this.posX += this.velX;
            this.posY += this.velY;
        }

        public void Bounds(int top, int left, int bottom, int right)
        {
            // Check screen position of asteroid
        }

        public bool HitsPlayer(Spaceship that)
        {
            // Come back to this (write intersection method)
            return true;
        }
    }
}
