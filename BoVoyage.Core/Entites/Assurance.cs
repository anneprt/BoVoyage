using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Entites
{
    public class Assurance
    {
        public double Montant { get; set; }
        public TypeAssurance Annulation { get; set; }
    }
}
