using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Entites
{
    [Table("DossiersReservations")]
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

        public int? IdAssurance { get; set; }
        [ForeignKey("IdAssurance")]
        public virtual Assurance Assurance { get; set; }


        public int NumeroUnique { get; set; }
        [Required]
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixParPersonne { get; set; }
        public decimal PrixTotal { get; set; }
       
  
        public void ChangerPrix(double pourcentageReduction)
        {
            decimal reduction = 40/100;
            this.PrixParPersonne = this.PrixParPersonne - this.PrixParPersonne * reduction ;

        }

        public void PrixT() {

            this.PrixTotal = ((Voyage.PrixParPersonne * Participant.NombreParticipant) * (10 / 100));

        }


        public EtatDossierReservation Etat { get; set; }
        public RaisonAnnulationDossier Raison { get; set; }


        public static void Annuler(RaisonAnnulationDossier Raison) { }

        public static void ValiderSolvabilite() { }

        public void Accepter() {
            Etat = EtatDossierReservation.Acceptee;
        }

        public void  PrixTTC() { }

        // Calcul du prix total 

           var p = Voyage





        int id_voyage = OutilsConsole.SaisirEntierObligatoire("Tapez l'identifiant du voyage:\n", "Champs requis!");
    double tarif;
    foreach(Voyage v in voyage_site)
        {
     if(v.Id == id_voyage)
        tarif = double.Parse(OutilsConsole.SaisirChaineObligatoire("Tapez la pourcentage de reduction du voyage:\n", "Champs requis!"));
        v.ChangerPrix(tarif);

            

    }
}
