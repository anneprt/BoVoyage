using BoVoyage.Core.Data;
using BoVoyage.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Services
{
    public class ServiceAssurance
    {
        public Assurance TrouverAssurance(int id)
        {
            using (var contexte = new Contexte())
            {
                return contexte.Assurances.Find(id);
            }
        }

        public IEnumerable<Assurance> ListerAssurance()
        {
            using (var contexte = new Contexte())
            {
                return contexte.Assurances.OrderBy(x => x.Id).ToList();
            }
        }
    }
}
