using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBataille
{
    public class PaquetCarte
    {
        private List<Carte> paquet;
        public PaquetCarte(List<Carte> paquet)
        {
            this.paquet = paquet;
        }

        public PaquetCarte()
        {
            this.paquet = new List<Carte>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Carte carte = new Carte();
                    carte.Couleur = (Couleurs)i;
                    carte.Valeur = (Valeurs)j + 1;
                    this.paquet.Add(carte);
                }
            }
            this.Melange();
        }

        public void Affichage()
        {
            Console.WriteLine($"il y a {this.paquet.Count} cartes dans le paquet");
            Print();
        }

        public void Print()
        {
            for(int i = 0;i < paquet.Count;i++) 
            {
                Console.Write($"{paquet[i].Valeur} ");
            }
            Console.WriteLine();
        }

        public void Melange()
        {
            Random rand = new Random();
            int random;
            Carte temp = new Carte();
            for (int i = 0; i < this.paquet.Count; i++)
            {
                random = rand.Next(0, this.paquet.Count);
                temp = this.paquet[i];
                this.paquet[i] = this.paquet[random];
                this.paquet[random] = temp;
            }
        }
        public void Distribuer(PaquetCarte[] paquetCartes)
        {
            int cible = 0;
            while (this.paquet.Count > 0)
            {
                paquetCartes[cible].AjouterCarte(this.paquet[0]);
                this.paquet.RemoveAt(0);
                if (++cible == paquetCartes.Length)
                {
                    cible = 0;
                }
            }
        }

        public void Transferer(PaquetCarte paquetDestination)
        {
            while (this.paquet.Count > 0)
            {
                paquetDestination.AjouterCarte(this.paquet[0]);
                this.paquet.RemoveAt(0);
            }
        }

        public void AjouterCarte(Carte carte)
        {
            this.paquet.Add(carte);

        }
        public void SupprimerCarte()
        {
            this.paquet.RemoveAt(0);
        }

        public int NombreCarte
        {
            get { return this.paquet.Count; }
        }

        public Carte PrendreCarte(PaquetCarte pileDeJeu)
        {
            if (this.paquet.Count == 0)
            {
                throw new InvalidOperationException("Le paquet de cartes est vide.");
                // return plutot la victoire pour celui qui a encore des cartes
            }

            Carte carte = this.paquet[0];
            pileDeJeu.AjouterCarte(carte);
            this.paquet.RemoveAt(0);
            return carte;
        }
    }
}
