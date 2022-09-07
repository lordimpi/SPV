using SPV.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Contracts
{
    public interface IPuntoVentaService
    {
        Task<ICollection<PuntoVenta>> ListPuntoVentas(string texto);
        Task<bool> SavePuntoVenta(int opcion, PuntoVenta puntoVenta);
        Task<bool> DeletePuntoVenta(int id);
    }
}
