using SPV.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Contracts
{
    public interface IMarcaService
    {
        Task<ICollection<Marca>> ListMarcas(string texto);
        Task<bool> SaveMarca(int opcion, Marca marca);
        Task<bool> DeleteMarca(int id);
    }
}
