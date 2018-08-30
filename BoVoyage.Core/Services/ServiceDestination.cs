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
	public class ServiceDestination
	{
		public void EnregistrerDestination()
		{
			var destination = new Destination();

			if (destination.Id == 0)
			{
				CreerDestination(destination);
			}
			else
			{
				ModifierDestination(destination);
			}
		}
		public void CreerDestination(Destination destination)
		{
			using (var contexte = new Contexte())
			{
				contexte.Destinations.Add(destination);
				contexte.SaveChanges();
			}
		}

		//TODO
		public void FiltrerDestination()
		{
			throw new NotImplementedException();
		}


		public IEnumerable<Destination> ListerDestination()
		{
			using (var contexte = new Contexte())
			{
				return contexte.Destinations.OrderBy(x => x.Continent).ToList();
			}
		}

		public void ModifierDestination(Destination destination)
		{
			using (var contexte = new Contexte())
			{
				contexte.Destinations.Attach(destination);
				contexte.Entry(destination).State = EntityState.Modified;
				contexte.SaveChanges();

			}
		}


		public void SupprimerClient(Client client)
		{
			using (var contexte = new Contexte())
			{
				contexte.Entry(client).State = EntityState.Deleted;
				contexte.SaveChanges();
			}
		}

		//TODO
		public void TrierClient()
		{
			throw new NotImplementedException();
		}

	}
}
