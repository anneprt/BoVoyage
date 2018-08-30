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
	public class ServiceClient 
	{
		public void Enregistrer()
		{
			var client = new Client();

			if (client.Id == 0)
			{
				CreerClient(client);
			}
			else
			{
				Modifier(client);
			}
		}
		public void CreerClient(Client client)
		{
			using (var contexte = new Contexte())
			{
				contexte.Clients.Add(client);
				contexte.SaveChanges();
			}
		}

		//TODO
		public void Filtrer()
		{
			throw new NotImplementedException();
		}


		public IEnumerable<Client> ListerClient()
		{
			using (var contexte = new Contexte())
			{
				return contexte.Clients.OrderBy(x => x.Nom).ToList();
			}
		}

		public void Modifier(Client client)
		{
			using (var contexte = new Contexte())
			{
				contexte.Clients.Attach(client);
				contexte.Entry(client).State = EntityState.Modified;
				contexte.SaveChanges();

			}
		}


		public void Supprimer(Client client)
		{
			using (var contexte = new Contexte())
			{
				contexte.Entry(client).State = EntityState.Deleted;
				contexte.SaveChanges();
			}
		}

		//TODO
		public void Trier()
		{
			throw new NotImplementedException();
		}

	}
}
