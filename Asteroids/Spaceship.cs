using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Spaceship
    {
        // Properties:
        Point topCoord;
        double topX;
        double topY;

        Point leftCoord;
        double leftX;
        double leftY;

        Point rightCoord;
        double rightX;
        double rightY;

        // Flight Mechanics:
        double velX = 0;
        double velY = 0;
        double resistance = 0.5;
        double movementForce = 10;

        // Rotation Mechanics:
        double rotateVal = 1;
        double centerX;
        double centerY;

        // Constructor:
        public Spaceship(int topX, int topY, int leftX, int leftY, int rightX, int rightY)
        {
            this.topX = topX;
            this.topY = topY;
            this.topCoord = new Point(topX, topY);

            this.leftX = leftX;
            this.leftY = leftY;
            this.leftCoord = new Point(leftX, leftY);

            this.rightX = rightX;
            this.rightY = rightY;
            this.rightCoord = new Point(rightX, rightY);

            this.centerX = Convert.ToInt32(this.rightX) - 10;
            this.centerY = Convert.ToInt32(this.topY) - 20;
        }

        // Getter Methods:
        public Point[] GetCoords()
        {
            return new Point[3] { this.topCoord, this.rightCoord, this.leftCoord };
        }
        
        // Custom Methods:
        public void Fly()
        {
            this.topX += this.velX;
            this.leftX += this.velX;
            this.rightX += this.velX;
      
            this.topY += this.velY;
            this.leftY += this.velY;
            this.rightY += this.velY;

            if (this.velY < 0)
            {
                this.velY += this.resistance;
            }
            else if (this.velY > 0)
            {
                this.velY -= this.resistance;
            }

            if (this.velX < 0)
            {
                this.velX += this.resistance;
            }
            else if (this.velX > 0)
            {
                this.velX -= this.resistance;
            }
        }

        public void UpdatePos()
        {
            this.topCoord = new Point(Convert.ToInt32(this.topX), Convert.ToInt32(this.topY));
            this.leftCoord = new Point(Convert.ToInt32(this.leftX), Convert.ToInt32(this.leftY));
            this.rightCoord = new Point(Convert.ToInt32(this.rightX), Convert.ToInt32(this.rightY));
        }

        public void Bounds(int top, int bottom, int left, int right)
        {
            /*if ()
            {
                this.topCoord = new Point();
                this.leftCoord = new Point();
                this.rightCoord = new Point();
            }

            if ()
            {
                this.topCoord = new Point();
                this.leftCoord = new Point();
                this.rightCoord = new Point();
            }

            if ()
            {
                this.topCoord = new Point();
                this.leftCoord = new Point();
                this.rightCoord = new Point();
            }

            if (ALL 3 POINTS ARE OVER THE EDGE - USE THIS FOR ALL)
            {
                this.topCoord = new Point();
                this.leftCoord = new Point();
                this.rightCoord = new Point();
            }*/
        }

        public void ApplyMovement(int direction)
        {
            switch (direction)
            {
                case 1: // Up
                    this.Rotate(1);
                    this.rotateVal = 1;
                    this.velY -= this.movementForce;
                    break; 
                case 2: // Down
                    this.Rotate(2);
                    this.rotateVal = 2;
                    this.velY += this.movementForce;                    
                    break;
                case 3: // Left
                    this.Rotate(3);
                    this.rotateVal = 3;
                    this.velX -= this.movementForce;
                    break;
                case 4: // Right
                    this.Rotate(4);
                    this.rotateVal = 4;
                    this.velX += this.movementForce;
                    break;
            }
        }

        public void Rotate(int direction)
        {
            switch (direction)
            {
                case 1: // Up

                    if (this.rotateVal != 1)
                    {
                        this.topY = this.topY - 40;
                        this.leftX = topX - 20;
                        this.leftY = topY + 40;

                        this.rightX = topX + 20;
                        this.rightY = topY + 40;
                    }
             
                    break;
                case 2: // Down

                    if (this.rotateVal != 2)
                    {
                        this.topY = this.topY + 40;
                        this.leftX = topX + 20;
                        this.leftY = topY - 40;

                        this.rightX = topX - 20;
                        this.rightY = topY - 40;
                    }

                    break;
                case 3: // Left

                    if (this.rotateVal != 3)
                    {
                        this.topX = this.topX - 40;
                        this.leftX = topX + 40;
                        this.leftY = topY + 20;

                        this.rightX = topX + 40;
                        this.rightY = topY - 20;
                    }
                    
                    break;
                case 4: // Right

                    if (this.rotateVal != 4)
                    {
                        this.topX = this.topX + 40;
                        this.leftX = topX - 40;
                        this.leftY = topY - 20;

                        this.rightX = topX - 40;
                        this.rightY = topY + 20;
                    }

                    break;
            }
        }
    }
}