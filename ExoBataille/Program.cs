using System;

namespace ExoBataille
{
    internal class Program
    {
        public enum Couleurs
        {
            Pique,
            Trèfle,
            Coeur,
            Carreau
        }

        public enum Valeurs
        {
            deux = 2,
            trois = 3,
            quatre = 4,
            cinq = 5,
            six = 6,
            sept = 7,
            huit = 8,
            neuf = 9,
            dix = 10,
            valet = 11,
            dame = 12,
            roi = 13,
            As = 14
        }

        public struct Carte
        {
            public Valeurs Valeur;
            public Couleurs Couleur;
        }

        static void Main(string[] args)
        {
            List<Carte> carteP1 = new List<Carte>();
            List<Carte> carteP2 = new List<Carte>();


            Carte[] tasCarte = new Carte[52];
            int compt = 0;
            // initialisation des cartes
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    tasCarte[compt].Couleur = (Couleurs)i;
                    tasCarte[compt].Valeur = (Valeurs)j+1;
                    compt++;
                }
            }
            // Mélange des cartes
            Random random = new Random();
            int random1;
            int random2;
            Carte temp = new Carte();
            for (int i = 0; i < 10000; i++)
            {
                random1 = random.Next(0, 50);
                random2 = random.Next(0, 50);
                temp = tasCarte[random1];
                tasCarte[random1] = tasCarte[random2];
                tasCarte[random2] = temp;
            }

            // Distribution de cartes


            bool P1 = true;
            for (int i = 0; i < tasCarte.Length; i++)
            {
                if (P1) {carteP1.Add(tasCarte[i]);}
                else { carteP2.Add(tasCarte[i]); }
                P1 = !P1;
            }


            int compterror = 0;
            foreach (var carte in carteP1)
            {
                Console.WriteLine($"{compterror} Valeur : {carte.Valeur}, Couleur : {carte.Couleur}");
                compterror++;
            }
            Console.WriteLine("PLAYER 2 :");
            foreach (var carte in carteP2)
            {
                Console.WriteLine($"{compterror} Valeur : {carte.Valeur}, Couleur : {carte.Couleur}");
                compterror++;
            }



        }
    }
}