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
	public class ServiceVoyage
	{
		public void EnregistrerVoyage()
		{
			var voyage = new Voyage();

			if (voyage.Id == 0)
			{
				CreerVoyage(voyage);
			}
			else
			{
				ModifierVoyage(voyage);
			}
		}
		public void CreerVoyage(Voyage voyage)
		{
			using (var contexte = new Contexte())
			{
				contexte.Voyages.Add(voyage);
				contexte.SaveChanges();
			}
		}

		//TODO
		public void FiltrerVoyage()
		{
			throw new NotImplementedException();
		}


		public IEnumerable<Voyage> ListerVoyage()
		{
			using (var contexte = new Contexte())
			{
				return contexte.Voyages.
					OrderBy(x => x.DateAller).
					 ToList();
			}
		}

		public void ModifierVoyage(Voyage voyage)
		{
			using (var contexte = new Contexte())
			{
				contexte.Voyages.Attach(voyage);
				contexte.Entry(voyage).State = EntityState.Modified;
				contexte.SaveChanges();

			}
		}

		public void SupprimerVoyage(Voyage voyage)
		{
			using (var contexte = new Contexte())
			{
				contexte.Entry(voyage).State = EntityState.Deleted;
				contexte.SaveChanges();
			}
		}

		//TODO
		public void TrierVoyage()
		{
			throw new NotImplementedException();
		}

	}
}
