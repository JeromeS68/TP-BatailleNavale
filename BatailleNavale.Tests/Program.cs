using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatailleNavale.Domain;

namespace BatailleNavale.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *    PERMIERS ESSAIS 
             */

            // Création d'un navire horizontal aux coordonnées (2, 5), de taille 3
            //Ship b = new Ship(2, 5, 3, Orientations.Horizontal);

            // IsAtCoordinates() doit renvoyer true si le bateau est aux coordonnées données
            /*
            System.Console.WriteLine(b.IsAtCoordinates(2, 5));
            System.Console.WriteLine(b.IsAtCoordinates(3, 5));
            System.Console.WriteLine(b.IsAtCoordinates(4, 5));
            */
            
            // IsAtCoordinates() doit renvoyer false si le bateau n'est pas aux coordonnées données
            /*
            System.Console.WriteLine(b.IsAtCoordinates(1, 5));
            System.Console.WriteLine(b.IsAtCoordinates(5, 5));
            System.Console.WriteLine(b.IsAtCoordinates(2, 6));
            */

            
            // Création d'une grille vierge
            //BattleGrid g = new BattleGrid();
            // Ajout du navire à la grille
            //g.AddShip(b);

            // Vérification qu'il y a de l'eau dans toutes les cases (doit renvoyer Water)
            /*
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    System.Console.WriteLine(x + "," + y + "=" + g.States[x, y]);
            */

            // Vérification de l'état des cases (doit tjs renvoyer true)
            /*
            System.Console.WriteLine(g.States[2, 5] == GridStates.Ship);
            System.Console.WriteLine(g.States[3, 5] == GridStates.Ship);
            System.Console.WriteLine(g.States[4, 5] == GridStates.Ship);
            System.Console.WriteLine(g.States[1, 5] == GridStates.Water);
            System.Console.WriteLine(g.States[5, 5] == GridStates.Water);
            */
            
            //Affichage de la grille en console
            //g.Draw();

            /*
            // On doit pouvoir ajouter un petit navire en haut à gauche
            System.Console.WriteLine(g.CanAddShip(new Ship(0, 0, 2, Orientations.Horizontal)));
            // On ne doit pas pouvoir ajouter un navire qui en chevauche un autre
            System.Console.WriteLine(g.CanAddShip(new Ship(1, 5, 2, Orientations.Horizontal)));
            // On ne doit pas pouvoir ajouter un navire qui déborde
            System.Console.WriteLine(g.CanAddShip(new Ship(9, 1, 2, Orientations.Horizontal)));
            */

            /*
            // Un tir dans l'eau marque la case comme manquée
            System.Console.WriteLine(g.Shoot(0, 0));
            // Outre la valeur de retour, la grille doit être modifiée
            System.Console.WriteLine(g.States[0, 0]);
            // Tir sur un navire
            System.Console.WriteLine(g.Shoot(2, 5));
            */

            /*
            // A ce moment, le jeu ne fait que commencer
            System.Console.WriteLine("Game over : " + g.GameOver());
            g.Shoot(2, 5);
            g.Shoot(3, 5);
            g.Shoot(4, 5);
            // Toutes les positions ont été tirées
            System.Console.WriteLine("Game over : " + g.GameOver());
            */

            /*
             *   MODELISATION D'UN JOUEUR AUTOMATIQUE
             */

            /*
            BattleGrid g = new BattleGrid();
            g.AddShip(new Ship(1, 0, 3, Orientations.Horizontal));
            IPlayer player = new StupidPlayer();
            */

            /*
            // Dans l'eau !
            player.Play(g);
            
            // Touche trois fois d'affilée
            player.Play(g);
            player.Play(g);
            player.Play(g);
            
            // Il doit avoir gagné après trois coups d'affilée
            System.Console.WriteLine(g.GameOver());
            */

            /*
            g.AddShip(new Ship(2, 5, 3, Orientations.Horizontal));
            int comptage = 0;
            g.Draw();
            while (!g.GameOver())
            {
                player.Play(g);
                comptage++;
            }
            System.Console.WriteLine(comptage);
            g.Draw();
            */

            // Création d'une grille avec génération aléatoire puis affichage
            
            BattleGrid g = new BattleGrid();
            IPlayer player = new StupidPlayer();
            g.NewGrid();
            g.Draw();

            while (!g.GameOver())
            {
                player.Play(g);
            }

            g.Draw();

            Console.Read();
        }
    }
}
