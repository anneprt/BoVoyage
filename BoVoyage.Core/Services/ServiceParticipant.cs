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
	public class ServiceParticipant
	{
        public Participant TrouverParticipant(int id)
        {
            using (var contexte = new Contexte())
            {
                return contexte.Participants.Find(id);
            }
        }

        public void EnregistrerParticipant()
		{
			var participant = new Participant();

			if (participant.Id == 0)
			{
				CreerParticipant(participant);
			}
			else
			{
				ModifierParticipant(participant);
			}
		}
		public void CreerParticipant(Participant participant)
		{
			using (var contexte = new Contexte())
			{
				contexte.Participants.Add(participant);
				contexte.SaveChanges();
			}
		}


        public IEnumerable<Participant> FiltrerParticipant(string columnFiltre, object valeurFiltre)
        {
            using (var contexte = new Contexte())
            {
                switch (columnFiltre)
                {
                    case "Nom": return contexte.Participants.Where(x => x.Nom.ToUpper().StartsWith(valeurFiltre.ToString().ToUpper())).ToList();
                    case "Prenom": return contexte.Participants.Where(x => x.Prenom.ToUpper().StartsWith(valeurFiltre.ToString().ToUpper())).ToList();
                    default: throw new Exception("Le filtrage se fait uniquement par nom ou par prénom. Veuillez recommencer");
                }
            }

        }


        public IEnumerable<Participant> ListerParticipant()
		{
			using (var contexte = new Contexte())
			{
				return contexte.Participants.OrderBy(x => x.Nom).ToList();
			}
		}

		public void ModifierParticipant(Participant participant)
		{
			using (var contexte = new Contexte())
			{
				contexte.Participants.Attach(participant);
				contexte.Entry(participant).State = EntityState.Modified;
				contexte.SaveChanges();

			}
		}
		public void SupprimerParticipant(int id)
		{
			using (var contexte = new Contexte())
			{
                var participant = contexte.Destinations.Find(id);
                contexte.Entry(participant).State = EntityState.Deleted;
				contexte.SaveChanges();
			}
		}

		

	}
}
