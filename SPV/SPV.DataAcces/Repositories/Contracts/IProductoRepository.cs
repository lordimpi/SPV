using SPV.DataAcces.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SPV.DataAcces.Repositories.Contracts
{
    public interface IProductoRepository
    {
        Task<ICollection<Producto>> ListProductos(string texto);
        Task<DataTable> PuntosVentaOk(int nOpcion, int nCodigo_pr);
        Task<bool> SaveProducto(int opcion, Producto producto, DataTable dataTable);
        Task<bool> DeleteProducto(int id);
        Task<byte[]> GetImage(int nCodigo_pr);
        Task<byte[]> GetImgProdPred();
    }
}
