using System;
using System.Collections;

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
            lstEtudiant.Add("1", new Etudiant { No = 1,
                Nom = "THIAM ",
                Prénom = "Fatim ",
                NoteCC= 12,
                NoteDevoir = 18,
            });
            Etudiant MALsia = new Etudiant()
            {
                No = 2,
                Nom = "SECK",
                Prénom = "Samba",
                NoteCC = 14,
                NoteDevoir = 16,S
            };
           
            lstEtudiant.Add(MALsia.NO, MALsia);
           

            Etudiant unEtudiant = (Etudiant)lstEtudiant[1];

            if (unEtudiant != null)
            {
                Console.WriteLine($"Matricule:{unEtudiant.NO}, Prénom: {unEtudiant.PréNom}, Nom: {unEtudiant.Nom}, ");

            }

            Console.WriteLine(  "Appuyer sur Entrée pour afficher la liste des étudiants");
            Console.ReadLine();

            foreach (DictionaryEntry etudiant in lstEtudiant)
            {
                Etudiant autreEtudiant = (Etudiant)etudiant.Value;
                Console.WriteLine($"Numéro d'ordre: {autreEtudiant.NO}, " +
                    $"PréNom: {autreEtudiant.PréNom},Nom: {autreEtudiant.Nom}");
            }
            Console.ReadLine();
        }
    }
}
