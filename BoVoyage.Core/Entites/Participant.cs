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

        public double Reduction
        {

            get
            {
                if (age < 12)
                    return 0.6d;


                else
                    return 0d;
            }
        }
    }
}
