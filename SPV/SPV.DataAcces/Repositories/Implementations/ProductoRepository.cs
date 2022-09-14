using SPV.DataAcces.Entities;
using SPV.DataAcces.Repositories.Contracts;
using SPV.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SPV.DataAcces.Repositories.Implementations
{
    public class ProductoRepository : IProductoRepository
    {
        public async Task<bool> DeleteProducto(int id)
        {
            bool result = false;
            SqlConnection sqlConnection = Conexion.GetInstancia().CreateConnection();
            SqlCommand sqlCommand = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlTransaction = sqlConnection.BeginTransaction();
                sqlCommand.CommandText = "USP_Eliminar_pr";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("nCodigo", SqlDbType.Int).Value = id;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlTransaction.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Rollback();
                }
                throw new Exception($"Se produjo un error al borrar el registro: {ex.Message}");
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return result;
        }

        public async Task<byte[]> GetImage(int nCodigo_pr)
        {
            byte[] imagen = null;
            //se usa para crear eliminar
            SqlConnection sqlConnection = Conexion.GetInstancia().CreateConnection();
            SqlCommand sqlCommand = null;
            // leer datos de lo que trae la consulta y se guardan
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                //manda lo que se ejecuta
                sqlCommand.CommandText = "USP_Mostrar_img";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("nCodigo_pr", SqlDbType.Int).Value = nCodigo_pr;
                //guarda lo que trae la consulta
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                //lee cada columna hasta el final
                while (sqlDataReader.Read())
                {
                    imagen = new Byte[0];
                    imagen = (byte[])sqlDataReader["imagen"];
                }
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return imagen;
        }

        public async Task<byte[]> GetImgProdPred()
        {
            byte[] imagen = null;
            //se usa para crear eliminar
            SqlConnection sqlConnection = Conexion.GetInstancia().CreateConnection();
            SqlCommand sqlCommand = null;
            // leer datos de lo que trae la consulta y se guardan
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                //manda lo que se ejecuta
                sqlCommand.CommandText = "Mostrar_img_prod_pred";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //guarda lo que trae la consulta
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                //lee cada columna hasta el final
                while (sqlDataReader.Read())
                {
                    imagen = new Byte[0];
                    imagen = (byte[])sqlDataReader["producto"];
                }
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return imagen;
        }

        public async Task<ICollection<Producto>> ListProductos(string texto)
        {
            List<Producto> productos = new List<Producto>();
            Producto producto = null;
            //se usa para crear eliminar
            SqlConnection sqlConnection = Conexion.GetInstancia().CreateConnection();
            SqlCommand sqlCommand = null;
            // leer datos de lo que trae la consulta y se guardan
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                //manda lo que se ejecuta
                sqlCommand.CommandText = "USP_Listado_pr";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("cTexto", SqlDbType.VarChar).Value = texto;
                //guarda lo que trae la consulta
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                //lee cada columna hasta el final
                while (sqlDataReader.Read())
                {
                    producto = new Producto()
                    {
                        Codigo_pr = Convert.ToInt32(sqlDataReader["codigo_pr"]),
                        Descripcion_pr = sqlDataReader["descripcion_pr"].ToString(),
                        Descripcion_ma = sqlDataReader["descripcion_ma"].ToString(),
                        Descripcion_um = sqlDataReader["descripcion_um"].ToString(),
                        Descripcion_sf = sqlDataReader["descripcion_sf"].ToString(),
                        Precio_unitario = Convert.ToDecimal(sqlDataReader["precio_unitario"]),
                        Descripcion_ad = sqlDataReader["descripcion_ad"].ToString(),
                        Observacion = sqlDataReader["observacion"].ToString(),
                        Codigo_ma = Convert.ToInt32(sqlDataReader["codigo_ma"]),
                        Codigo_um = Convert.ToInt32(sqlDataReader["codigo_um"]),
                        Codigo_sf = Convert.ToInt32(sqlDataReader["codigo_sf"]),
                        Codigo_ad = Convert.ToInt32(sqlDataReader["codigo_ad"])
                    };
                    productos.Add(producto);
                }
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return productos;
        }

        public async Task<DataTable> PuntosVentaOk(int nOpcion, int nCodigo_pr)
        {
            DataTable puntoVentas = new DataTable();
            //se usa para crear eliminar
            SqlConnection sqlConnection = Conexion.GetInstancia().CreateConnection();
            SqlCommand sqlCommand = null;
            // leer datos de lo que trae la consulta y se guardan
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                //manda lo que se ejecuta
                sqlCommand.CommandText = "USP_Puntos_Ventas_OK";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("nOpcion", SqlDbType.Int).Value = nOpcion;
                sqlCommand.Parameters.Add("nCodigo_pr", SqlDbType.Int).Value = nCodigo_pr;
                //guarda lo que trae la consulta
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                puntoVentas.Load(sqlDataReader);
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return puntoVentas;
        }

        public async Task<bool> SaveProducto(int opcion, Producto producto, DataTable dataTable)
        {
            SqlConnection sqlConnection = Conexion.GetInstancia().CreateConnection();
            SqlCommand sqlCommand = null;
            SqlTransaction sqlTransaction = null;
            bool result = false;
            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlTransaction = sqlConnection.BeginTransaction();
                sqlCommand.CommandText = "USP_Guardar_pr";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("nOpcion", SqlDbType.Int).Value = opcion;
                sqlCommand.Parameters.Add("nCodigo", SqlDbType.Int).Value = producto.Codigo_pr;
                sqlCommand.Parameters.Add("cDescripcion_pr", SqlDbType.VarChar).Value = producto.Descripcion_pr;
                sqlCommand.Parameters.Add("nCodigo_ma", SqlDbType.Int).Value = producto.Codigo_ma;
                sqlCommand.Parameters.Add("nCodigo_um", SqlDbType.Int).Value = producto.Codigo_um;
                sqlCommand.Parameters.Add("nCodigo_sf", SqlDbType.Int).Value = producto.Codigo_sf;
                sqlCommand.Parameters.Add("nPrecio_unitario", SqlDbType.Decimal).Value = producto.Precio_unitario;
                sqlCommand.Parameters.Add("nCodigo_ad", SqlDbType.Int).Value = producto.Codigo_ad;
                sqlCommand.Parameters.Add("cObservacion", SqlDbType.VarChar).Value = producto.Observacion;
                sqlCommand.Parameters.Add("oImagen", SqlDbType.Image).Value = producto.Imagen;
                sqlCommand.Parameters.Add("Ty_01", SqlDbType.Structured).Value = dataTable;
                //guarda lo que trae la consulta
                await sqlCommand.ExecuteNonQueryAsync();
                sqlTransaction.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Rollback();
                }
                throw new Exception($"Se produjo un error al Crear el registro: {ex.Message}");
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return result;
        }
    }
}
