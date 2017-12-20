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
        }

        // Getter Methods:
        public Point[] GetCoords()
        {
            Point[] coordinates = new Point[3] { this.topCoord, this.rightCoord, this.leftCoord };
            return coordinates;
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

            this.topCoord = new Point(Convert.ToInt32(topX), Convert.ToInt32(topY));
            this.leftCoord = new Point(Convert.ToInt32(leftX), Convert.ToInt32(leftY));
            this.rightCoord = new Point(Convert.ToInt32(rightX), Convert.ToInt32(rightY));

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

        public void Bounds(int top, int bottom, int left, int right)
        {

        }

        public void ApplyMovement(int direction)
        {
            switch (direction)
            {
                case 1: // Up

                    this.velY -= this.movementForce;

                    break; 
                case 2: // Down

                    this.velY += this.movementForce;

                    break;
                case 3: // Left

                    this.velX -= this.movementForce;

                    break;
                case 4: // Right

                    this.velX += this.movementForce;

                    break;
            }
        }

        public void Rotate(int direction)
        {
            switch (direction)
            {
                case 1: // Up



                    break;
                case 2: // Down



                    break;
                case 3: // Left



                    break;
                case 4: // Right


                    break;
            }
        }
    }
}