using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaliczenie_ld_308.Controller;

namespace zaliczenie_ld_308
{
    class ServiceController
    {
        public MSA msa;
        public ServiceController()
        {
            if(this.msa == null)
            {
                this.msa = new MSA();
            }
        }
    }
}
