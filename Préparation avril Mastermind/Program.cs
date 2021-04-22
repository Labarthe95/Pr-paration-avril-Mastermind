using System;
using System.Collections.Generic;

namespace Préparation_avril_Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Couleurs> listeOrdi = new List<Couleurs>(); //collection qui va servir à stocker les couleurs de l'ordinateur
            List<Couleurs> listeUser = new List<Couleurs>(); //collection qui va servir à stocker les couleurs de l'utilisateur


            listeOrdi.AddRange(new Couleurs[] { Couleurs.Bleu, Couleurs.Mauve, Couleurs.Orange, Couleurs.Vert }); //ajouter 4 couleurs dans collection ordi

            Console.WriteLine("Bonjour, vous allez affronter l'ordinateur au jeu du Mastermind.");
            Console.WriteLine("Règle du jeu : En début de partie, parmi 8 couleurs, l’ordinateur sélectionne 4 couleurs différentes pour composer un code couleur ordonné. Ensuite, le joueur se doit de définir lui aussi un code de 4 couleurs dans le but de deviner celui de l’ordinateur. Si le joueur trouve le code dans le bon ordre, il gagne.Par contre, si celui - ci commet une erreur, l’ordinateur se doit de donner des indices.");


            int bonneCouleur = 0;
            int bonEndroit = 0;

            Console.WriteLine("Voici les 8 couleurs disponibles, veuillez en choisir 4. Encodez le chiffre correspondant à la couleur choisie, puis appuyez sur enter et recommencer jusqu'à ce que 4 chiffres soient encodés");

            do
            {
                if (listeUser.Count == 4) //si liste remplie pour que fasse traitement que après transmis infos
                {

                    if (bonneCouleur > 0) Console.WriteLine($"{bonneCouleur} couleur(s) n'est/ne sont pas à sa/leur place");
                    if (bonEndroit == 0 && bonneCouleur == 0) Console.WriteLine("Vous n'avez trouvé aucune couleur.");
                    if (bonEndroit > 0) Console.WriteLine($"{bonEndroit} couleur(s) est/sont au bon endroit"); //indices
                    Console.WriteLine("Choisissez à nouveau 4 couleurs. Encodez le chiffre correspondant à la couleur choisie, puis appuyez sur enter et recommencer jusqu'à ce que 4 chiffres soient encodés");
                    listeUser.Clear(); //vider la collection
                    bonEndroit = 0; //remettre à 0 pour nouveaux indices
                    bonneCouleur = 0;
                    //Console.Clear(); //Clear la console d'affichage 
                }
                int nb = 1;
                foreach (string x in Couleurs.GetNames(typeof(Couleurs)))
                {
                    Console.WriteLine($"{nb} {x}"); //imprime l'énumération (les 8 couleurs)
                    nb++;
                }
                int a = 0;
                while (a <= 3)
                {
                    bool b_x = int.TryParse(Console.ReadLine(), out int x); //utilisateur entre sa couleur avec chiffre correspondant
                    if (x >= 1 && x <= 8)
                    {
                        listeUser.Add((Couleurs)x); //ajouter 4 couleurs dans collection user
                        a++; //n'ajoute i que si entré dans collection
                    }
                    else if (!(b_x)) Console.WriteLine("Ceci n'est pas un chiffre, veuillez recommencer");
                    else Console.WriteLine("Ce chiffre ne correspond à aucune couleur, veuillez recommencer");
                }
                Console.WriteLine("Voici les 4 couleurs que vous avez choisies:");
                for (int i = 0; i <= 3; i++) //parcourir collection
                {
                    Console.WriteLine(listeUser[i]); //afficher les 4 couleurs choisies à l'utilisateur
                }


                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 3; j++) //parcourir toutes combinaisons possibles
                    {
                        if ((listeUser[i] == listeOrdi[j]) && (i != j)) bonneCouleur++; //vérifie si utilise bonne couleur
                    }
                    if (listeUser[i] == listeOrdi[i]) bonEndroit++; //vérifie si élément au bon endroit
                }
            } while (bonEndroit < 4); //tant que pas trouvé les 4 bonnes couleurs
            Console.WriteLine("Vous avez gagné");

        }
    }
}
