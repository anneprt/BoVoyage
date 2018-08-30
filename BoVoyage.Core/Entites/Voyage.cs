using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace BoVoyage.Core.Entites
{
    public class Voyage
    {
        public int Id { get; set; }

        public int IdAgenceVoyage { get; set; }
        [ForeignKey("IdAgenceVoyage")]
        public virtual AgenceVoyage AgenceVoyage { get; set; }

        public int IdDestination { get; set; }
        [ForeignKey("IdDestination")]
        public virtual Destination Destination { get; set; }

        public DateTime DateAller { get; set; }
        public DateTime DateRetour { get; set; }
        public int PlacesDisponibles { get; set; }
        public decimal PrixParPersonne { get; set; }

        public static void Reserver() { }
    }
}
