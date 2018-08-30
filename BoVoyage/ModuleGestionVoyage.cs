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
    public class ModuleGestionVoyage : ModuleBase<Application>
    {
        private readonly ServiceVoyage service = new ServiceVoyage();

        

        public ModuleGestionVoyage(Application application, string nomModule) 
            : base(application, nomModule)
        {

        }
        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Lister les voyages")
            {
                FonctionAExecuter = this.Lister
            });
            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void Lister()
        {
            ConsoleHelper.AfficherEntete("Liste des voyages");
            var liste = service.ListerVoyage();
            ConsoleHelper.AfficherListe(liste, ElementsAffichage.strategieAffichageVoyage);
        }
    }
}
