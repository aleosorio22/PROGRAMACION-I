using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace segundo_parcial_progra_I
{
    public class TiendaAutosInd
    {
        private AutoIndexer[] disponibles;

        public TiendaAutosInd()
        {
            disponibles = new AutoIndexer[5];

            disponibles[0] = new AutoIndexer("toyota", 100000);
            disponibles[1] = new AutoIndexer("Prado", 3910);
            disponibles[2] = new AutoIndexer("Nissan", 319031);
            disponibles[3] = new AutoIndexer("Mazda", 3193);
            disponibles[4] = new AutoIndexer("Honda", 831913);

        }

        public AutoIndexer this[int indice]
        {
            get { return disponibles[indice]; }
            set { disponibles[indice] = value; }
           
        }
    }
}
