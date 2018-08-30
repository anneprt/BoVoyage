using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Entites
{
    public class DossierReservation
    {
        public int Id { get; set; }
        public int NumeroUnique { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public double PrixParPersonne { get; set; }
        public double PrixTotal { get; set; }
        public EtatDossierReservation Etat { get; set; }
        public RaisonAnnulationDossier Raison { get; set; }
       

        public static void Annuler()  { }
        public static void ValiderSolvabilite() { }
        public static void Accepter() { }


    }
}
