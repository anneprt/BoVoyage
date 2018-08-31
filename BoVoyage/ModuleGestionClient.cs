using BoVoyage.Core.Entites;
using BoVoyage.Core.Exceptions;
using BoVoyage.Core.Services;
using BoVoyage.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage
{
    public class ModuleGestionClient : ModuleBase<Application>
    {
        private readonly ServiceClient service = new ServiceClient();

        public ModuleGestionClient(Application application, string nomModule) 
            : base(application, nomModule)
        {

        }
        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Lister les clients")
            {
                FonctionAExecuter = this.Lister

            });

            menu.AjouterElement(new ElementMenu("2", "Créer un client")
            {
                FonctionAExecuter = this.CreerNouveauClient

            });

            menu.AjouterElement(new ElementMenu("3", "Supprimer un client")
            {
                FonctionAExecuter = this.SupprimerClient

            });

            menu.AjouterElement(new ElementMenu("4", "Modifier un client")
            {
                FonctionAExecuter = this.AfficherMessageFonctionnalite

            });

            menu.AjouterElement(new ElementMenu("5", "Filtrer les clients")
            {
                FonctionAExecuter = this.FiltrerClient

            });

            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void Lister()
        {
            ConsoleHelper.AfficherEntete("Liste des clients");
            this.AfficherListe();
        }

        private void CreerNouveauClient()
        {
            ConsoleHelper.AfficherEntete("Nouveau client");

            var client = new Client
            {
                Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilite ?"),
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom ?"),
                Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse ?"),
                Telephone= ConsoleSaisie.SaisirChaineObligatoire("Téléphone ?"),
                Email = ConsoleSaisie.SaisirChaineOptionnelle("Email ?"),
                DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de naissance ?")
            };

            this.service.CreerClient(client);
        }

        private void SupprimerClient()
        {
            ConsoleHelper.AfficherEntete("Supprimer des clients");
            AfficherListe();
            var id = ConsoleSaisie.SaisirEntierObligatoire("Identifiant ?");
            try
            {
                service.SupprimerClient(id);
            } catch (BusinessException erreur)
            {
                ConsoleHelper.AfficherMessageErreur(erreur.Message);
            }


        }

        private void FiltrerClient()
        {
            ConsoleHelper.AfficherEntete("Filtre des clients");
            var filtreNom = ConsoleSaisie.SaisirChaineOptionnelle("Filtre sur le nom ?");
            ConsoleHelper.AfficherListe(this.service.FiltrerClient("Nom", filtreNom), ElementsAffichage.strategieAffichageClient);
        }

        private void AfficherListe()
        {
            var liste = service.ListerClient();
            ConsoleHelper.AfficherListe(liste, ElementsAffichage.strategieAffichageClient);
        }

		private void AfficherMessageFonctionnalite()
		{
			ConsoleColor couleur = ConsoleColor.Red;
			Console.ForegroundColor = couleur;
			Console.WriteLine("Cette fonctionnalité n'est pas implémentée dans la version actuelle de l'application");
			Console.ResetColor();

		}

	}
}
