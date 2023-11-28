using AV2Rafael.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV2Rafael.Service
{
    public class ServiceCategoria
    {
        public RepositoryCategoria oRepositoryCategoria { get; set; }

        public ServiceCategoria()
        {
            oRepositoryCategoria = new RepositoryCategoria();
        }
    }
}