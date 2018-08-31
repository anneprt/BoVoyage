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

			menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void Lister()
        {
            ConsoleHelper.AfficherEntete("Liste des destinations");
            var liste = service.ListerDestination();
            ConsoleHelper.AfficherListe(liste, ElementsAffichage.strategieAffichageDestination);
        }
	}
}
