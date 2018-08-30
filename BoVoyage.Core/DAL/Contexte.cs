using BoVoyage.Core.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Data
{
	public class Contexte :DbContext
	{
		public DbSet<AgenceVoyage> AgencesVoyages { get; set; }

		public DbSet<Assurance> Assurances { get; set; }

		public DbSet<Client>Clients { get; set; }

		public DbSet<Destination>Destinations{ get; set; }

		public DbSet<DossierReservation> DossiersReservations { get; set; }

		//public DbSet<EtatDossierReservation> EtatDossierReservation{ get; set; }

		public DbSet<Participant> Participants { get; set; }

		public DbSet<Voyage>Voyages { get; set; }

		

		

		

		


	}
}
