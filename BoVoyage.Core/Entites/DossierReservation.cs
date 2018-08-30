using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Entites
{
    public class DossierReservation
    {
        public int Id { get; set; }

        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }

        public int IdParticipant { get; set; }
        [ForeignKey("IdParticipant")]
        public virtual Participant Participant { get; set; }

        public int IdVoyage { get; set; }
        [ForeignKey("IdVoyage")]
        public virtual Voyage Voyage { get; set; }

        public int IdAssurance { get; set; }
        [ForeignKey("IdAssurance")]
        public virtual Assurance Assurance { get; set; }


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
