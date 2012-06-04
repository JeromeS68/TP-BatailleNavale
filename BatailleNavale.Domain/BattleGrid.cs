using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatailleNavale.Domain
{
    public class BattleGrid
    {
        /* Grille de 10 par 10 */
        public const int ROWS = 10;
        public const int COLS = 10;
        public GridStates[,] States {
            get;
            private set;
        }
        private List<Ship> ships;

        public BattleGrid()
        {
            States = new GridStates[COLS, ROWS];
            ships = new List<Ship>();
        }

        // On ajoute un bateau
        public void AddShip(Ship s)
        {
            ships.Add(s);
            for(int i=0; i<s.GetSize(); i++)
            {
                if (s.GetOrientation() == Orientations.Horizontal)
                    States[i+s.GetCoordinateX(), s.GetCoordinateY()] = GridStates.Ship;
                else
                    States[s.GetCoordinateX(), i + s.GetCoordinateY()] = GridStates.Ship;
            }

        }

        // On vérifie si on peut ajouter un ship (et non pas shit)
        public bool CanAddShip(Ship s)
        {
            for (int i = 0; i < s.GetSize(); i++)
            {
                if (s.GetOrientation() == Orientations.Horizontal)
                {
                    if (!(s.GetCoordinateX() + i < 10))
                        return false;
                    else
                    {
                        if (!(States[i + s.GetCoordinateX(), s.GetCoordinateY()] == GridStates.Water))
                            return false;
                    }
                }
                else
                    if (!(s.GetCoordinateY() + i < 10))
                        return false;
                    else
                    {
                        if (!(States[s.GetCoordinateX(), i + s.GetCoordinateY()] == GridStates.Water))
                            return false;
                    }
            }
            return true;
        }

        // On trace une grille pas trop moche
        public void Draw()
        {
            for (int y = -1; y < 10; y++)
            {
                if (!(y == -1))
                    System.Console.Write(y);
                else
                    System.Console.Write(" ");
                for (int x = 0; x < 10; x++)
                {
                    if (y == -1)
                        System.Console.Write(x);
                    else
                    {
                        if (States[x, y] == GridStates.Water)
                            System.Console.Write(" ");
                        else if (States[x, y] == GridStates.Ship)
                            System.Console.Write("s");
                        else if (States[x, y] == GridStates.Missed)
                            System.Console.Write("-");
                        else // Hit
                            System.Console.Write("x");
                    }
                }
                System.Console.WriteLine();
            }
        }

        // On essaye de faire une tir...
        public GridStates Shoot(int x, int y)
        {
            // Si on tire dans l'eau
            if (States[x, y] == GridStates.Water)
            {
                States[x, y] = GridStates.Missed;
                //Console.WriteLine("Plouf");
            }
            // Si on tire dans le Ship
            else if (States[x, y] == GridStates.Ship)
            {
                States[x, y] = GridStates.Hit;
                //Console.WriteLine("Touché");
            }
            
            return States[x, y];
        }

        // Quand c'est la fin du jeu
        public bool GameOver()
        {
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    if (States[x,y] == GridStates.Ship)
                        return false;
            return true;
        }

        // Génération aléatoire des navires
        public void NewGrid()
        {
            Random r = new Random();
            int x, y, size;
            Orientations o;
            bool essai = true;
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                    size = 5;   // un porte-avion de 5
                else if (i == 1)
                    size = 4;   // un croiseur de 4
                else if (i == 2 || i == 3)
                    size = 3;   // un contre-torpilleur et un sous-marin de 3
                else
                    size = 2;   // un torpilleur de 2
                while (essai)
                {
                    x = r.Next(0, 10);
                    y = r.Next(0, 10);
                    if (r.Next(0, 2) == 0)
                        o = Orientations.Horizontal;
                    else
                        o = Orientations.Vertical;
                    if (this.CanAddShip(new Ship(x, y, size, o)))
                    {
                        essai = false;
                        this.AddShip(new Ship(x, y, size, o));
                    }
                }
                essai = true;
            }
            
        }
    }
}
