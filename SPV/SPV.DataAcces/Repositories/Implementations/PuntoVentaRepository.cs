using SPV.DataAccess.Entities;
using SPV.DataAccess.Repositories.Contracts;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPV.DataAccess.Repositories.Implementations
{
    public class PuntoVentaRepository : IPuntoVentaRepository
    {
        public async Task<bool> SavePuntoVenta(int opcion, PuntoVenta puntoVenta)
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
                sqlCommand.CommandText = "USP_Guardar_pv";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("nOpcion", SqlDbType.Int).Value = opcion;
                sqlCommand.Parameters.Add("nCodigo", SqlDbType.Int).Value = puntoVenta.Codigo_pv;
                sqlCommand.Parameters.Add("cDescripcion", SqlDbType.VarChar).Value = puntoVenta.Descripcion_pv;
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
                throw new Exception($"Se produjo un error al Crear el punto de venta: {ex.Message}");
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return result;
        }

        public async Task<bool> DeletePuntoVenta(int id)
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
                sqlCommand.CommandText = "USP_Eliminar_pv";
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
                throw new Exception($"Se produjo un error al borrar el punto de venta: {ex.Message}");
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return result;
        }

        public async Task<ICollection<PuntoVenta>> ListPuntoVentas(string texto)
        {
            List<PuntoVenta> puntoVentas = new List<PuntoVenta>();
            PuntoVenta puntoVenta = null;
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
                sqlCommand.CommandText = "USP_Listado_pv";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("cTexto", SqlDbType.VarChar).Value = texto;
                //guarda lo que trae la consulta
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                //lee cada columna hasta el final
                while (sqlDataReader.Read())
                {
                    puntoVenta = new PuntoVenta()
                    {
                        Codigo_pv = Convert.ToInt32(sqlDataReader["codigo_pv"]),
                        Descripcion_pv = sqlDataReader["descripcion_pv"].ToString(),
                    };
                    puntoVentas.Add(puntoVenta);
                }
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return puntoVentas;
        }
    }
}
