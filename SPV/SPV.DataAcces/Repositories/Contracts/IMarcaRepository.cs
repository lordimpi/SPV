using SPV.DataAcces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.DataAcces.Repositories.Contracts
{
    public interface IMarcaRepository
    {
        Task<ICollection<Marca>> ListMarcas(string texto);
        Task<bool> SaveMarca(int opcion, Marca marca);
        Task<bool> DeleteMarca(int id);
    }
}
