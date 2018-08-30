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

		//TODO
		public void FiltrerParticipantt()
		{
			throw new NotImplementedException();
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
		public void SupprimerParticipant(Client participant)
		{
			using (var contexte = new Contexte())
			{
				contexte.Entry(participant).State = EntityState.Deleted;
				contexte.SaveChanges();
			}
		}

		//TODO
		public void TrierParticipants()
		{
			throw new NotImplementedException();
		}

	}
}
