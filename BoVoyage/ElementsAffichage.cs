using BoVoyage.Core.Entites;
using BoVoyage.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage
{
    public class ElementsAffichage
    {
        public static readonly List<InformationAffichage> strategieAffichageVoyage = new List<InformationAffichage>
            {
                InformationAffichage.Creer<Voyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Voyage>(x=>x.DateAller, "Date Aller", 10),
                InformationAffichage.Creer<Voyage>(x=>x.DateRetour, "Date Retour", 10),
                InformationAffichage.Creer<Voyage>(x=>x.PrixParPersonne, "Prix par personne", 15),
                InformationAffichage.Creer<Voyage>(x=>x.Destination.Pays, "Destination", 15),
                InformationAffichage.Creer<Voyage>(x=>x.PlacesDisponibles, "Places disponibles", 15)


            };

        public static readonly List<InformationAffichage> strategieAffichageClient = new List<InformationAffichage>
            {
                InformationAffichage.Creer<Client>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Client>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<Client>(x=>x.Prenom, "Prénom", 10),
                InformationAffichage.Creer<Client>(x=>x.Email, "Email", 30),
                InformationAffichage.Creer<Client>(x=>x.DateNaissance, "Date de naissance", 10)
            };

        public static readonly List<InformationAffichage> strategieAffichageParticipant = new List<InformationAffichage>
            {
                InformationAffichage.Creer<Participant>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Participant>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<Participant>(x=>x.Prenom, "Prénom", 10),
                InformationAffichage.Creer<Participant>(x=>x.DateNaissance, "Date de naissance", 10)
            };

        public static readonly List<InformationAffichage> strategieAffichageDestination = new List<InformationAffichage>
            {
                InformationAffichage.Creer<Destination>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Destination>(x=>x.Continent, "Continent", 20),
                InformationAffichage.Creer<Destination>(x=>x.Pays, "Pays", 20),
                InformationAffichage.Creer<Destination>(x=>x.Description, "Description", 30)

            };

        public static readonly List<InformationAffichage> strategieAffichageDossierReservation = new List<InformationAffichage>
            {
                InformationAffichage.Creer<DossierReservation>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<DossierReservation>(x=>x.Client.Nom, "Client", 10),
                InformationAffichage.Creer<DossierReservation>(x=>x.PrixParPersonne, "Prix par personne", 15),
                InformationAffichage.Creer<DossierReservation>(x=>x.Voyage.Destination.Pays, "Destination", 15),
                InformationAffichage.Creer<DossierReservation>(x=>x.PrixTotal, "Prix Total", 15),


            };

        public static readonly List<InformationAffichage> strategieAffichageAssurance = new List<InformationAffichage>
            {
                InformationAffichage.Creer<Assurance>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Assurance>(x=>x.Type, "Type", 10),
                InformationAffichage.Creer<Assurance>(x=>x.Montant, "Montant", 10),

            };
    }
}
