using SPV.DataAcces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.DataAcces.Repositories.Contracts
{
    public interface IUnidadesMedidaRepository
    {
        Task<ICollection<UnidadesMedida>> ListUnidadesMedida(string texto);
        Task<bool> SaveUnidadMedida(int opcion, UnidadesMedida unidadesMedida);
        Task<bool> DeleteUnidadMedida(int id);
    }
}
