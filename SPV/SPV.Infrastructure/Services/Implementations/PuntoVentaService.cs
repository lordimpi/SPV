using SPV.DataAccess.Entities;
using SPV.DataAccess.Repositories.Contracts;
using SPV.Infrastructure.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.Infrastructure.Services.Implementations
{
    public class PuntoVentaService : IPuntoVentaService
    {
        private readonly IPuntoVentaRepository _repository;

        public PuntoVentaService(IPuntoVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeletePuntoVenta(int id)
        {
            return await _repository.DeletePuntoVenta(id);
        }

        public async Task<ICollection<PuntoVenta>> List(string texto)
        {
            return await _repository.List(texto);
        }

        public async Task<bool> SavePuntoVenta(int opcion, PuntoVenta puntoVenta)
        {
            return await _repository.SavePuntoVenta(opcion, puntoVenta);
        }
    }
}
