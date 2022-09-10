using SPV.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Contracts
{
    public interface ISubFamiliaService
    {
        Task<ICollection<Familia>> ListFamilias(string texto);
        Task<ICollection<SubFamilia>> ListSubFamilias(string texto);
        Task<bool> SaveSubFamilia(int opcion, SubFamilia subFamilia);
        Task<bool> DeleteSubFamilia(int id);
    }
}
