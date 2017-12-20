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
        int sideLength;
        Point topCoord;
        Point leftCoord;
        Point rightCoord;
        

        // Constructor:
        public Spaceship(int sLen, int topX, int topY, int leftX, int leftY, int rightX, int rightY)
        {
            this.sideLength = sLen;
            this.topCoord = new Point(topX, topY);
            this.leftCoord = new Point(leftX, leftY);
            this.rightCoord = new Point(rightX, rightY);
        }

        // Setter Methods:


        // Getter Methods:
        public int GetSideLength()
        {
            return this.sideLength;
        }

        public Point[] GetCoords()
        {
            Point[] coordinates = new Point[3] { this.topCoord, this.rightCoord, this.leftCoord };
            return coordinates;
        }
        
        // Custom Methods:
        public void Rotate(int direction)
        {
            
        }
    }
}