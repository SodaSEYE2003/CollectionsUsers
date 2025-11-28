using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;

namespace UsageCollections
{
    //2.Lire
    //   les données à partir du clavier.Pour chaque étudiant saisir ses 2
    //   notes.Ranger ces données dans une SortedList,
    // la clé est le NO.
    //     NO { get; set; }
    //    Nom { get; set; }
    //    PréNom { get; set; }
    //    NoteCC { get; set; }
    //    NoteDevoir { get; set; }
class Program
    {
        static void Main(string[] args)
        {
            SortedList lstEtudiant = new SortedList();
            Console.WriteLine("Combien d'étudiants voulez-vous saisir ?");
            int nbreEtudiants = int.Parse(Console.ReadLine());


            //===============================Lecture des données=============================
            for(int i = 1; i <=nbreEtudiants; i++)
            {
                Console.Write($"\n ---Etudiant{i}");

                Etudiant etu = new Etudiant();

                Console.Write("Numéro d'ordre NO : ");
                etu.NO = Console.ReadLine();

                Console.Write("Prénom: ");
                etu.PreNom = Console.ReadLine();

                Console.Write("Nom: ");
                etu.Nom = Console.ReadLine();

                Console.Write("Note de Contrôle Continu : ");
                etu.NoteCC = double.Parse(Console.ReadLine());

                Console.Write("Note de Devoir : ");
                etu.NoteDevoir = double.Parse(Console.ReadLine());

                lstEtudiant.Add(etu.NO, etu);
            }

            // Calcul moyenne de la classe
            double somme = 0;
            foreach (DictionaryEntry item in lstEtudiant)
            {
                Etudiant e = (Etudiant)item.Value;
                somme += e.Moyenne;
            }
            double moyenneClasse = somme / lstEtudiant.Count;

            // ======= AFFICHAGE DES ÉTUDIANTS SAISIS ========
            Console.WriteLine("\n===== LISTE DES ÉTUDIANTS ======");

            foreach (DictionaryEntry item in lstEtudiant)
            {
                Etudiant e = (Etudiant)item.Value;

                Console.WriteLine(
                    $"NO: {e.NO} | Prénom: {e.PreNom} | Nom: {e.Nom} | " +
                    $"CC: {e.NoteCC} | Devoir: {e.NoteDevoir} | Moyenne: {e.Moyenne:F2}"
                );
            }

            Console.WriteLine($"\nMoyenne de la classe : {moyenneClasse:F2}");

            // ====================== PAGINATION ========================
            int lignesParPage = 5;
            Console.Write("\nChoisissez le nombre de lignes par page (5 à 15) : ");
            int choix = int.Parse(Console.ReadLine());

            if (choix >= 5 && choix <= 15)
                lignesParPage = choix;

            int totalPages = (int)Math.Ceiling((double)lstEtudiant.Count / lignesParPage);
            int pageActuelle = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"===== PAGE {pageActuelle}/{totalPages} =====");

                int start = (pageActuelle - 1) * lignesParPage;
                int end = Math.Min(start + lignesParPage, lstEtudiant.Count);

                // Affichage page
                for (int i = start; i < end; i++)
                {
                    string key = lstEtudiant.GetKey(i).ToString();
                    Etudiant e = (Etudiant)lstEtudiant[key];

                    Console.WriteLine($"NO: {e.NO}, Nom: {e.Nom}, Prénom: {e.PreNom}, " +
                                      $"CC: {e.NoteCC}, Devoir: {e.NoteDevoir}, Moyenne: {e.Moyenne:F2}");
                }

                Console.WriteLine("\nMoyenne de la classe : " + moyenneClasse.ToString("F2"));

                Console.WriteLine("\nOptions :");
                Console.WriteLine("N - Page suivante");
                Console.WriteLine("P - Page précédente");
                Console.WriteLine("S - Stop");

                string option = Console.ReadLine().ToUpper();

                if (option == "N" && pageActuelle < totalPages)
                    pageActuelle++;
                else if (option == "P" && pageActuelle > 1)
                    pageActuelle++;
                else if (option == "S")
                    break;
            }

            Console.WriteLine("\nProgramme terminé !");
        }
    }
}

