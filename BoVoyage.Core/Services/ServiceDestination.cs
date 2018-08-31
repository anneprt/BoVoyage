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
        public Destination TrouverDestination(int id)
        {
            using (var contexte = new Contexte())
            {
                return contexte.Destinations.Find(id);
            }
        }

        public void EnregistrerDestination(Destination destination)
		{

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

		public IEnumerable<Destination> FiltrerDestination(string columnFiltre, object valeurFiltre)
		{
            using (var contexte = new Contexte())
            {
                switch (columnFiltre)
                {
                    case "Continent": return contexte.Destinations.Where(x => x.Continent.StartsWith(valeurFiltre.ToString())).ToList();
                    case "Pays": return contexte.Destinations.Where(x => x.Pays.StartsWith(valeurFiltre.ToString())).ToList();
                    default: throw new Exception("Le filtrage se fait uniquement par continent ou par pays. Veuillez recommencer");
                }
            }
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


		public void SupprimerDestination(int id)
		{
			using (var contexte = new Contexte())
			{
                var destination= contexte.Destinations.Find(id);
                contexte.Entry(destination).State = EntityState.Deleted;
				contexte.SaveChanges();
			}
		}


	}
}
