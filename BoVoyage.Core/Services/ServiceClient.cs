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
		public void SupprimerClient(Client client)
		{
			using (var contexte = new Contexte())
			{
				contexte.Entry(client).State = EntityState.Deleted;
				contexte.SaveChanges();
			}
		}
	}
}
