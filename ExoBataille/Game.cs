using ExoBataille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBataille
{
    public class Game
    {
        PaquetCarte p1 = new PaquetCarte(new List<Carte>());
        PaquetCarte p2 = new PaquetCarte(new List<Carte>());
        PaquetCarte pileDeJeu = new PaquetCarte(new List<Carte>());
        int resultatFinal;

        public Game()
        {
            PaquetCarte pioche = new PaquetCarte();
            pioche.Distribuer([p1, p2]); ;
            Console.WriteLine("Les cartes ont été distribuées.");
            p1.Affichage();
            p2.Affichage();
        }

        public void Jouer()
        {
            while (p1.NombreCarte > 0 && p2.NombreCarte > 0)
            {
                int resultTour = JouerTour();
                if (resultTour == 0)
                {
                    break;
                }
            }
            AfficherResultatFinal();
        }

        public int JouerTour()
        {
            Carte carteP1 = p1.PrendreCarte(pileDeJeu);
            Carte carteP2 = p2.PrendreCarte(pileDeJeu);
            Console.WriteLine($"P1 a jouer {carteP1.Valeur} P2 a jouer {carteP2.Valeur}");
            if (carteP1.Valeur > carteP2.Valeur)
            {
                pileDeJeu.Transferer(p1);
                AfficherDetailsManche();
                return 1;
            }
            else if (carteP1.Valeur < carteP2.Valeur)
            {
                pileDeJeu.Transferer(p2);
                AfficherDetailsManche();
                return 2;
            }
            else
            {
                if (p1.NombreCarte < 2 || p2.NombreCarte < 2)
                {
                    return 0;
                }
                Console.WriteLine("BATAILLE");
                p1.PrendreCarte(pileDeJeu);
                p2.PrendreCarte(pileDeJeu);
                int resultManche = JouerTour();
                PaquetCarte? gagnant = resultManche == 1 ? p1 : resultManche == 2 ? p2 : null;
                if (gagnant != null)
                {
                    pileDeJeu.Transferer(gagnant);
                }
                return resultManche;
            }
        }

        private void AfficherDetailsManche()
        {
            Console.WriteLine($"Carte du joueurs 1 :{p1.NombreCarte}    Carte du joueurs 2 : {p2.NombreCarte}  ");
        }

        private void AfficherResultatFinal()
        {
            if (p1.NombreCarte > p2.NombreCarte)
            {
                Console.WriteLine("Player 1 win");
            }
            else
            {
                Console.WriteLine("Player 2 win");
            }
        }
    }
}











//using ExoBataille;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ExoBataille
//{
//    public class Game
//    {
//        PaquetCarte p1 = new PaquetCarte(new List<Carte>());
//        PaquetCarte p2 = new PaquetCarte(new List<Carte>());
//        int resultatFinal;

//        public Game()
//        {
//            PaquetCarte pioche = new PaquetCarte();
//            pioche.Distribuer([this.p1, this.p2]);
//            Console.WriteLine($"Les cartes ont été distribuer");
//        }

//        public void Jouer()
//        {
//            while (p1.Count > 0 && p2.Count > 0)
//            {
//                resultatFinal = JouerTour();
//                AfficherResultatFinal(resultatFinal);

//            }

//            // Afficher le résultat final
//            //AfficherResultatFinal();
//        }

//        public int JouerTour()
//        {
//            int result = 5;
//            while (p1.Count > 0 && p2.Count > 0)
//            {
//                if (p1.Count > 0 && p2.Count > 0)
//                {
//                    Carte carteP1 = p1.PrendreCarte();
//                    Carte carteP2 = p2.PrendreCarte();

//                    if (carteP1.Valeur > carteP2.Valeur)
//                    {
//                        // Le joueur 1 gagne le tour, remettez les cartes dans son paquet
//                        p1.AjouterCarte(carteP1);
//                        p1.AjouterCarte(carteP2);
//                    }
//                    else if (carteP1.Valeur < carteP2.Valeur)
//                    {
//                        // Le joueur 2 gagne le tour, remettez les cartes dans son paquet
//                        p2.AjouterCarte(carteP1);
//                        p2.AjouterCarte(carteP2);
//                    }
//                    else
//                    {
//                        // Égalité, rien ne se passe
//                        result = 0;
//                    }
//                }

//            }
//            if (p1.Count == 0)
//            {
//                return 1;
//            }
//            return 0;
//        }

//        public int Egality()
//        {

//        }


//        private void AfficherResultatFinal(int result)
//        {
//            if (result == 1)
//            {
//                Console.WriteLine("Le joueur 1 remporte la partie !");
//                return;
//            }
//            Console.WriteLine("Le joueur 2 remporte la partie !");
//            }
//        }
//    }




