using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Asteroid
    {
        // Properties:
        double posX;
        double posY;
        double size;

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

        // Custom Methods:
        public void Move()
        {
            this.posX += this.velX;
            this.posY += this.velY;
        }

        public void Bounds(int top, int left, int bottom, int right)
        {
            if (this.posX > right)
            {
                this.posX = left - this.size;
            }
            else if (this.posX + this.size < left)
            {
                this.posX = right;
            }

            if (this.posY > bottom)
            {
                this.posY = top - this.size;
            }
            else if (this.posY + this.size < top)
            {
                this.posY = bottom;
            }
        }

        public bool HitsPlayer(Spaceship that)
        {
            return !(this.posY > that.GetGeneralPosY() + 40 ||
                this.posY + this.size < that.GetGeneralPosY() ||
                this.posX > that.GetGeneralPosX() + 10 ||
                this.posX + this.size < that.GetGeneralPosX() - 10);
        }
    }
}
