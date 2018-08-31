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
    public class ModuleGestionDestination : ModuleBase<Application>
    {
        private readonly ServiceDestination service = new ServiceDestination();

        public ModuleGestionDestination(Application application, string nomModule) 
            : base(application, nomModule)
        {

        }
        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Lister les destinations")
            {
                FonctionAExecuter = this.Lister
            });

			menu.AjouterElement(new ElementMenu("2", "Créer une destination")
			{
				FonctionAExecuter = this.AfficherMessageFonctionnalite
			});

			menu.AjouterElement(new ElementMenu("3", "Supprimer une destination")
			{
				FonctionAExecuter = this.AfficherMessageFonctionnalite
			});

			menu.AjouterElement(new ElementMenu("4", "Modifier une destination")
			{
				FonctionAExecuter = this.AfficherMessageFonctionnalite
			});

			menu.AjouterElement(new ElementMenu("5", "Filtrer les destinations")
			{
				FonctionAExecuter = this.AfficherMessageFonctionnalite
			});

			menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void Lister()
        {
            ConsoleHelper.AfficherEntete("Liste des destinations");
            var liste = service.ListerDestination();
            ConsoleHelper.AfficherListe(liste, ElementsAffichage.strategieAffichageDestination);
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
