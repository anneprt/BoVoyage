using BoVoyage.Core.Data;
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
		public void EnregistrerReservation()
		{
			var dossierReservation = new DossierReservation();

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

		//TODO
		public void FiltrerDossierReservation()
		{
			throw new NotImplementedException();
		}


		public IEnumerable<DossierReservation> ListerDossierReservation()
		{
			using (var contexte = new Contexte())
			{
				return contexte.DossiersReservations.OrderBy(x => x.NumeroUnique).ToList();
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


		public void SupprimerDossierReservation(DossierReservation dossierReservation)
		{
			using (var contexte = new Contexte())
			{
				contexte.Entry(dossierReservation).State = EntityState.Deleted;
				contexte.SaveChanges();
			}
		}

		//TODO
		public void TrierDossierReservation()
		{
			throw new NotImplementedException();
		}

	}
}
