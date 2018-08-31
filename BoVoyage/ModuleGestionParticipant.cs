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
    public class ModuleGestionParticipant : ModuleBase<Application>
    {
        private readonly ServiceParticipant service = new ServiceParticipant();

        public ModuleGestionParticipant(Application application, string nomModule) 
            : base(application, nomModule)
        {

        }
        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Lister les participants")
            {
                FonctionAExecuter = this.Lister

            });

            menu.AjouterElement(new ElementMenu("2", "Créer un participant")
            {
                FonctionAExecuter = this.CreerNouveauParticipant

            });

            menu.AjouterElement(new ElementMenu("3", "Supprimer un participant")
            {
                FonctionAExecuter = this.SupprimerParticipant

            });

            menu.AjouterElement(new ElementMenu("4", "Modifier le nom d'un participant")
            {
                FonctionAExecuter = this.ModifierParticipant

            });

            menu.AjouterElement(new ElementMenu("5", "Filtrer les participants")
            {
                FonctionAExecuter = this.FiltrerParticipant

            });

            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void Lister()
        {
            ConsoleHelper.AfficherEntete("Liste des participants");
            this.AfficherListe();
        }

        private void CreerNouveauParticipant()
        {
            ConsoleHelper.AfficherEntete("Nouveau participant");

            var participant = new Participant
            {
                NumeroUnique = ConsoleSaisie.SaisirEntierObligatoire("Numero unique ?"),
                Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilite ?"),
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom ?"),
                Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse ?"),
                Telephone= ConsoleSaisie.SaisirChaineObligatoire("Téléphone ?"),
                DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de naissance ?")
            };

            this.service.CreerParticipant(participant);
        }

        private void ModifierParticipant()
        {
            ConsoleHelper.AfficherEntete("Modifier le nom d'un participant");
            AfficherListe();
            var id = ConsoleSaisie.SaisirEntierObligatoire("Identifiant du participant ?");
            var nom = ConsoleSaisie.SaisirChaineObligatoire("Nouveau nom du participant ?");
            Participant participant = service.TrouverParticipant(id);
            participant.Nom = nom;
            service.ModifierParticipant(participant);
        }

        private void SupprimerParticipant()
        {
            ConsoleHelper.AfficherEntete("Supprimer des participants");
            AfficherListe();
            var id = ConsoleSaisie.SaisirEntierObligatoire("Identifiant ?");
            try
            {
                service.SupprimerParticipant(id);
            } catch (BusinessException erreur)
            {
                ConsoleHelper.AfficherMessageErreur(erreur.Message);
            }
        }

        private void FiltrerParticipant()
        {
            ConsoleHelper.AfficherEntete("Filtre des participants");
            var filtreNom = ConsoleSaisie.SaisirChaineOptionnelle("Filtre sur le nom ?");
            ConsoleHelper.AfficherListe(this.service.FiltrerParticipant("Nom", filtreNom), ElementsAffichage.strategieAffichageParticipant);
        }

        private void AfficherListe()
        {
            var liste = service.ListerParticipant();
            ConsoleHelper.AfficherListe(liste, ElementsAffichage.strategieAffichageParticipant);
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
