using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatailleNavale.Domain
{
    public class Ship
    {
        private Orientations o;
        private int x;
        private int y;
        private int size;
        private int[] plage;    // Permet de définir la plage de coordonnées (en fonction de l'orientation) dans laquelle le bateau est situé

        public Ship(int x, int y, int size, Orientations o)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.o = o;
            this.plage = new int[this.size];
            for (int i = 0; i < this.size; i++)
            {
                if (o == Orientations.Horizontal)
                    plage[i] = this.x + i;
                else
                    plage[i] = this.y + i;
            }
        }

        public bool IsAtCoordinates(int x, int y)
        {
            if (o == Orientations.Horizontal)
            {
                return (y == this.y && this.plage.Contains(x));
            }
            else
            {
                return (x == this.x && this.plage.Contains(y));
            }
        }

        public int GetCoordinateX()
        {
            return x;
        }
        public int GetCoordinateY()
        {
            return y;
        }
        public int[] GetPlage()
        {
            return plage;
        }
        public int GetSize()
        {
            return size;
        }
        public Orientations GetOrientation()
        {
            return o;
        }

    }
}
