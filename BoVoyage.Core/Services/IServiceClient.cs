using BoVoyage.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Services
{
	public interface IServiceClient
	{
		IEnumerable<Client> Lister();

		void CreerClient(Client client);

		void SupprimerClient(Client client);

		void ModifierClient(Client client);

	}
}
