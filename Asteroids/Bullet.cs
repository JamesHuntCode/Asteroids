using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Bullet
    {
        // Properties
        int posX;
        int posY;
        int height = 5;
        int width = 5;
        int velX;
        int velY;
        bool isActive = true;

        // Constructor:
        public Bullet(int x, int y, int vX, int vY)
        {
            this.posX = x;
            this.posY = y;
            this.velX = vX;
            this.velY = vY;
        }

        // Getter Methods:
        public int GetPosX()
        {
            return this.posX;
        }

        public int GetPosY()
        {
            return this.posY;
        }

        public int GetH()
        {
            return this.height;
        }

        public int GetW()
        {
            return this.width;
        }

        public bool GetStatus()
        {
            return this.isActive;
        }

        // Setter Methods:
        public void SetStatus(bool newCondition)
        {
            this.isActive = newCondition;
        }

        // Custom Methods:
        public void Move()
        {
            this.posX += this.velX;
            this.posY += this.velY;
        }

        public bool OffScreen(int left, int right, int top, int bottom)
        {
            // Check left & right
            if (this.posX + this.width < left || this.posX > right)
            {
                return true;
            }

            // Check top & bottom
            if (this.posY + this.height < top || this.posY > bottom)
            {
                return true;
            }
            return false;
        }

        public bool HitsAsteroid(Asteroid asteroid)
        {
            return (this.posY > asteroid.GetY() && this.posY < asteroid.GetY() + asteroid.GetS() &&
                this.posX > asteroid.GetX() && this.posX < asteroid.GetX() + asteroid.GetS());
        }
    }
}
