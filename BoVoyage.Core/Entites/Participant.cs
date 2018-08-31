using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.Entites
{
	
	public class Participant : Personne
    {
        public int NumeroUnique { get; set; }
        public float? Reduction { get; set; }
		

		
    }
}
