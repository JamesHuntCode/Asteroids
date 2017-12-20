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
        int topX;
        int topY;

        Point leftCoord;
        int leftX;
        int leftY;

        Point rightCoord;
        int rightX;
        int rightY;

        // Flight Mechanics:
        int velocity = 0;
        int gravity = 0;
        int acceleration = 0;

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

        public void Fly(int direction)
        {
            switch (direction)
            {
                case 1: // Up

                    this.topY -= 20;
                    this.leftY -= 20;
                    this.rightY -= 20;

                    this.topCoord = new Point(topX, topY);
                    this.leftCoord = new Point(leftX, leftY);
                    this.rightCoord = new Point(rightX, rightY);

                    break; 
                case 2: // Down

                    this.topY += 20;
                    this.leftY += 20;
                    this.rightY += 20;

                    this.topCoord = new Point(topX, topY);
                    this.leftCoord = new Point(leftX, leftY);
                    this.rightCoord = new Point(rightX, rightY);

                    break;
                case 3: // Left

                    this.topX -= 20;
                    this.leftX -= 20;
                    this.rightX -= 20;

                    this.topCoord = new Point(topX, topY);
                    this.leftCoord = new Point(leftX, leftY);
                    this.rightCoord = new Point(rightX, rightY);

                    break;
                case 4: // Right

                    this.topX += 20;
                    this.leftX += 20;
                    this.rightX += 20;

                    this.topCoord = new Point(topX, topY);
                    this.leftCoord = new Point(leftX, leftY);
                    this.rightCoord = new Point(rightX, rightY);

                    break;
            }
        }
    }
}