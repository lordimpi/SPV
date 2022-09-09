using SPV.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Contracts
{
    public interface IUnidadesMedidaService
    {
        Task<ICollection<UnidadesMedida>> ListUnidadesMedida(string texto);
        Task<bool> SaveUnidadMedida(int opcion, UnidadesMedida unidadesMedida);
        Task<bool> DeleteUnidadMedida(int id);
    }
}
