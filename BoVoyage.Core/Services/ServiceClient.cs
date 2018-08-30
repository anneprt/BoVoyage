using BoVoyage.Core.Data;
using BoVoyage.Core.Entites;
using BoVoyage.Core.Exceptions;
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
        public Client TrouverClient(int id)
        {
            using (var contexte = new Contexte())
            {
                return contexte.Clients.Find(id);
            }
        }

		public void EnregistrerClient(Client client)
		{
			if (client.Id == 0)
			{
				CreerClient(client);
			}
			else
			{
				ModifierClient(client);
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

		public IEnumerable<Client>FiltrerClient(string columnFiltre, object valeurFiltre)
		{
            using (var contexte = new Contexte())
            {
                switch (columnFiltre)
                {
                    case "Nom": return contexte.Clients.Where(x => x.Nom.ToUpper().StartsWith(valeurFiltre.ToString().ToUpper())).ToList();
                    case "Prenom": return contexte.Clients.Where(x => x.Prenom.ToUpper().StartsWith(valeurFiltre.ToString().ToUpper())).ToList();
                    default: throw new BusinessException("Le filtrage se fait uniquement par nom ou par prénom. Veuillez recommencer");
                }
            }
            
        }


		public IEnumerable<Client> ListerClient()
		{
			using (var contexte = new Contexte())
			{
                var liste = contexte.Clients.OrderBy(x => x.Nom).ToList();

                if (liste.Count < 1)
                {
                    throw new BusinessException("Il n'y a aucun client dans la base de données de Bo Voyage");
                }

                return liste;
			}
		}

		public void ModifierClient(Client client)
		{
			using (var contexte = new Contexte())
			{
				contexte.Clients.Attach(client);
				contexte.Entry(client).State = EntityState.Modified;
				contexte.SaveChanges();

			}
		}

		public void SupprimerClient(int id)
		{
            if (id < 1)
            {
                throw new BusinessException("L'identifiant pour la suppression du client est requis");
            }

			using (var contexte = new Contexte())
			{
                var client = contexte.Clients.Find(id);

                if (client == null)
                {
                    throw new BusinessException($"Aucun client avec l'identifiant {id}");
                }

				contexte.Entry(client).State = EntityState.Deleted;
				contexte.SaveChanges();
			}
		}


	}
}
