﻿using BoVoyage.Core.Data;
using BoVoyage.Core.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Services
{
    public class ServiceDossierReservation
    {
        private readonly ServiceVoyage serviceVoyage = new ServiceVoyage();
        private readonly ServiceAssurance serviceAssurance = new ServiceAssurance();

        public DossierReservation TrouverDossierReservation(int id)
        {
            using (var contexte = new Contexte())
            {
                return contexte.DossiersReservations.Find(id);
            }
        }

        public void EnregistrerReservation(DossierReservation dossierReservation)
        {
            if (dossierReservation.Id == 0)
            {
                CreerDossierReservation(dossierReservation);
            }
            else
            {
                ModifierDossierReservation(dossierReservation);
            }
        }
        public void CreerDossierReservation(DossierReservation dossierReservation)
        {
            using (var contexte = new Contexte())
            {
                contexte.DossiersReservations.Add(dossierReservation);
                contexte.SaveChanges();
            }
        }

        public IEnumerable<DossierReservation> FiltrerDossierReservation(string columnFiltre, object valeurFiltre)
        {
            using (var contexte = new Contexte())
            {
                switch (columnFiltre)
                {
                    case "NumeroUnique": return contexte.DossiersReservations.Where(x => x.NumeroUnique == int.Parse(valeurFiltre.ToString())).ToList();
                    case "Client": return contexte.DossiersReservations.Where(x => x.Client.Nom.ToUpper().StartsWith(valeurFiltre.ToString().ToUpper())).ToList();
                    default: throw new Exception("Le filtrage se fait uniquement par numéro unique ou par client. Veuillez recommencer");
                }
            }
        }
        public IEnumerable<DossierReservation> ListerDossierReservation()
        {
            using (var contexte = new Contexte())
            {
                return contexte.DossiersReservations.Include (x=>x.Client).OrderBy(x => x.NumeroUnique).ToList();
            }
        }

        public void ModifierDossierReservation(DossierReservation dossierReservation)
        {
            using (var contexte = new Contexte())
            {
                contexte.DossiersReservations.Attach(dossierReservation);
                contexte.Entry(dossierReservation).State = EntityState.Modified;
                contexte.SaveChanges();

            }
        }


        public void SupprimerDossierReservation(int id)
        {
            using (var contexte = new Contexte())
            {
                var dossierReservation = contexte.DossiersReservations.Find(id);
                contexte.Entry(dossierReservation).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }

        public decimal CalculerPrixTotal(List<Participant> listeParticipant, int idVoyage, int? idAssurance)
        {
            decimal prixTotal = 0;
            Voyage voyage = serviceVoyage.TrouverVoyage(idVoyage);

            Assurance assurance = null;
            if (idAssurance > 0)
            {
                assurance = serviceAssurance.TrouverAssurance(idAssurance);
                prixTotal = prixTotal + assurance.Montant;
            }
            foreach (Participant participant in listeParticipant)
            {
                prixTotal = prixTotal + (voyage.CalculMarge() * Convert.ToDecimal(participant.Reduction));
            }

            return prixTotal;
        }


    }
}
