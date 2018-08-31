using BoVoyage.Core.Entites;
using BoVoyage.Core.Services;
using BoVoyage.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage
{
    public class ModuleGestionDossierReservation : ModuleBase<Application>
    {
        private readonly ServiceDossierReservation service = new ServiceDossierReservation();
        private readonly ServiceVoyage serviceVoyage = new ServiceVoyage();
        private readonly ServiceClient serviceClient = new ServiceClient();
        private readonly ServiceParticipant serviceParticipant = new ServiceParticipant();
        private readonly ServiceAssurance serviceAssurance = new ServiceAssurance();

    

        public ModuleGestionDossierReservation(Application application, string nomModule) 
            : base(application, nomModule)
        {

        }
        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Lister les dossiers de réservations")
            {
                FonctionAExecuter = this.Lister
            });
            menu.AjouterElement(new ElementMenu("2", "Créer un dossier de réservation")
            {
                FonctionAExecuter = this.Creer
            });

			menu.AjouterElement(new ElementMenu("3", "Supprimer un dossier de réservation")
			{
				FonctionAExecuter = this.AfficherMessageFonctionnalite
			});

			menu.AjouterElement(new ElementMenu("4", "Modifier un dossier de réservation")
			{
				FonctionAExecuter = this.AfficherMessageFonctionnalite
			});
			menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void Lister()
        {
            ConsoleHelper.AfficherEntete("Liste des réservations");
            var liste = service.ListerDossierReservation();
            ConsoleHelper.AfficherListe(liste, ElementsAffichage.strategieAffichageDossierReservation);
        }

        private void Creer()
        {
            ConsoleHelper.AfficherEntete("Créer un dossier de réservation");
            ConsoleHelper.AfficherListe(serviceVoyage.ListerVoyage(), ElementsAffichage.strategieAffichageVoyage);
            var idVoyage = ConsoleSaisie.SaisirEntierObligatoire("Identifiant du voyage ?");
            ConsoleHelper.AfficherListe(serviceClient.ListerClient(), ElementsAffichage.strategieAffichageClient);
            var idClient = ConsoleSaisie.SaisirEntierObligatoire("Identifiant du client ?");
            ConsoleHelper.AfficherListe(serviceParticipant.ListerParticipant(), ElementsAffichage.strategieAffichageParticipant);
            var idParticipant = ConsoleSaisie.SaisirEntierObligatoire("Nombre de participants?");
            ConsoleHelper.AfficherListe(serviceAssurance.ListerAssurance(), ElementsAffichage.strategieAffichageAssurance);
            var idAssurance = ConsoleSaisie.SaisirEntierOptionnel("Assurance o/n?");
            var numeroUnique = ConsoleSaisie.SaisirEntierObligatoire("Numéro unique ?");
            var numeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numéro carte bancaire ?");
            
            //Recuperer voyage par rapport à l'Id==>TO DO calcul prix avec reduction etc
            var voyage = serviceVoyage.TrouverVoyage(idVoyage);
           

                    DossierReservation dossierReservation = new DossierReservation
            {
                NumeroUnique = numeroUnique,
                NumeroCarteBancaire = numeroCarteBancaire,
                IdClient = idClient,
                IdAssurance = idAssurance,
                IdParticipant = idParticipant,
                IdVoyage = idVoyage,
                PrixParPersonne = voyage.PrixParPersonne,
                
                Etat = EtatDossierReservation.EnAttente
            };
            dossierReservation.CalculerPrixTotal();
            service.EnregistrerReservation(dossierReservation);
            
            
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
