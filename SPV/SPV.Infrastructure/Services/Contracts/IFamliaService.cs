using SPV.DataAcces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Contracts
{
    public interface IFamliaService
    {
        Task<ICollection<Familia>> ListFamilias(string texto);
        Task<bool> SaveFamilia(int opcion, Familia familia);
        Task<bool> DeleteFamilia(int id);
    }
}
