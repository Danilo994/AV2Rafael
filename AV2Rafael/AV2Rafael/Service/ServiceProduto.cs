using AV2Rafael.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV2Rafael.Service
{
    public class ServiceProduto
    {
        public RepositoryProduto oRepositoryProduto { get; set; }
        public RepositoryCategoria oRepositoryCategoria { get; set; }

        public ServiceProduto()
        {
            oRepositoryProduto = new RepositoryProduto();
            oRepositoryCategoria = new RepositoryCategoria();
        }
    }
}