using BoVoyage.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage
{
    public class Application : ApplicationBase
    {

        public Application()
            : base("Bo Voyage") {}

        public ModuleGestionClient ModuleGestionClient { get; private set; }
        public ModuleGestionVoyage ModuleGestionVoyage { get; private set; }
        public ModuleGestionDossierReservation ModuleGestionDossierReservation { get; private set; }
        public ModuleGestionDossierReservation ModuleGestionDestination { get; private set; }

        protected override void InitialiserModules()
        {
            this.ModuleGestionClient = this.AjouterModule(new ModuleGestionClient(this, "Gestion des clients"));
            this.ModuleGestionVoyage = this.AjouterModule(new ModuleGestionVoyage(this, "Gestion des voyages"));
            this.ModuleGestionDossierReservation = this.AjouterModule(new ModuleGestionDossierReservation(this, "Gestion des dossiers de réservation"));
            this.ModuleGestionDossierReservation = this.AjouterModule(new ModuleGestionDossierReservation(this, "Gestion des destinations"));
        }

       
    }
}
