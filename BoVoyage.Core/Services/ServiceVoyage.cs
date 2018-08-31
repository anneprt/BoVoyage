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
        public Voyage TrouverVoyage(int id)
        {
            using (var contexte = new Contexte())
            {
                return contexte.Voyages.Find(id);
            }
        }

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


        public IEnumerable<Voyage> FiltrerVoyage(string columnFiltre, object valeurFiltre)
        {
            using (var contexte = new Contexte())
            {
                switch (columnFiltre)
                {
                    case "destination": return contexte.Voyages.Where(x => x.Destination.Pays.ToUpper().StartsWith(valeurFiltre.ToString().ToUpper())).ToList();
                    default: throw new Exception("Le filtrage se fait uniquement par destination. Veuillez recommencer");
                }
            }
        }

        public IEnumerable<Voyage> ListerVoyage()
		{
			using (var contexte = new Contexte())
			{
				return contexte.Voyages.
					Include(x=> x.Destination).
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

		public void SupprimerVoyage(int id)
		{
			using (var contexte = new Contexte())
			{
                var voyage = contexte.Voyages.Find(id);
                contexte.Entry(voyage).State = EntityState.Deleted;
				contexte.SaveChanges();
			}
		}

		
	}
}
