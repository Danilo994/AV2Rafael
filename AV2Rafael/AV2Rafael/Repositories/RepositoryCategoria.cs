using AV2Rafael.Repositories;
using AV2Rafael.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV2Rafael.Repositories
{
    public class RepositoryCategoria : RepositoryBase<Categoria>
    {
        public RepositoryCategoria(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}