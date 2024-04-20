using System;
using static ExoBataille.Program;

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

        public static int PlayCard(List<Carte> cartesP1, List<Carte> cartesP2)
        {   
            Carte firstCardP1 = cartesP1.First();
            Carte firstCardP2 = cartesP2.First();
            cartesP1.RemoveAt(0);
            cartesP2.RemoveAt(0);
            
            if (firstCardP1.Valeur > firstCardP2.Valeur)
            {
                cartesP1.Add(firstCardP1);
                cartesP1.Add(firstCardP2);
                return 1;
            }
            if (firstCardP1.Valeur < firstCardP2.Valeur)
            {
                cartesP2.Add(firstCardP2);
                cartesP2.Add(firstCardP1);
                return 2;
            }
           

            if (cartesP1.Count < 2 && cartesP2.Count < 2)
            {
                return 0;
            }

            Carte stockCardP1 = cartesP1[0];
            Carte stockCardP2 = cartesP2[0];
            cartesP1.RemoveAt(0);
            cartesP2.RemoveAt(0);
            int resultManche = PlayCard(cartesP1,cartesP2);


            if (resultManche == 1) 
            {   
                cartesP1.Add(stockCardP1);
                cartesP1.Add(stockCardP2);
                cartesP1.Add(firstCardP1);
                cartesP1.Add(firstCardP2);
            }
            else
            {
                cartesP2.Add(stockCardP1);
                cartesP2.Add(stockCardP2);
                cartesP2.Add(firstCardP2);
                cartesP2.Add(firstCardP1);
            }
            return resultManche;
        }

        //public int Egality(List<Carte> cartesP1, List<Carte> cartesP2)
        //{
           
        //}

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
            Random rand = new Random();
            int random;
            Carte temp = new Carte();
            for (int i = 0; i < tasCarte.Length; i++)
            {
                random = rand.Next(0, 51);
                temp = tasCarte[i];
                tasCarte[i] = tasCarte[random];
                tasCarte[random] = temp;
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

            // Duel de carte
            int result = 5;
           
            while (carteP1.Count > 0 && carteP2.Count > 0)
            {
                result = PlayCard(carteP1,carteP2);
                if (result == 0)
                {
                    if (carteP1.Count > carteP2.Count)
                    {
                        result = 1;
                        break;
                    }
                    result = 2;
                    break;
                }

                Console.WriteLine($"Player 1 nb carte :{carteP1.Count} Player 2 nb carte :{carteP2.Count} ");
            }
            if (result == 1) 
            {
                Console.WriteLine("Le joueurs 1 gagne la partie");
                return;
            }
            Console.WriteLine("Le joueurs 2 gagne la partie");
        }
    }
}