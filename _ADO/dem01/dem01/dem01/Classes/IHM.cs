﻿internal static class IHM
{
    private static void AfficherMenu()
    {
        Console.WriteLine("1 - Ajouter étudiant");
        Console.WriteLine("2 - Afficher tous les étudiants");
        Console.WriteLine("3 - Afficher les étudiants d'une classe");
        Console.WriteLine("4 - Supprimer un étudiant");
        Console.WriteLine("5 - Mettre à jour un étudiant");
        Console.WriteLine("0 - Quitter");
    }

    private static void AfficherEtudiants()
    {
    }

    private static void AfficherEtudiantsClasse()
    {
    }

    private static void AjouterEtudiant()
    {
    }

    private static void SupprimerEtudiant()
    {
    }

    private static void EditEtudiant()
    {
    }

    public static void Start()
    {
        while (true)
        {
            AfficherMenu();
            string choix = Console.ReadLine()!;

            switch (choix)
            {
                case "1":
                    AjouterEtudiant();
                    break;
                case "2":
                    AfficherEtudiants();
                    break;
                case "3":
                    AfficherEtudiantsClasse();
                    break;
                case "4":
                    SupprimerEtudiant();
                    break;
                case "5":
                    EditEtudiant();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Erreur de saisie");
                    break;
            }
        }
    }
}