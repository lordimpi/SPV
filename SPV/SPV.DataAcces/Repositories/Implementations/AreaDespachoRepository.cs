using SPV.DataAcces.Entities;
using SPV.DataAcces.Repositories.Contracts;
using SPV.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SPV.DataAcces.Repositories.Implementations
{
    public class AreaDespachoRepository : IAreaDespachoRepository
    {
        public async Task<bool> DeleteAreaDespacho(int id)
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
                sqlCommand.CommandText = "USP_Eliminar_ad";
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

        public async Task<ICollection<AreaDespacho>> ListAreasDespacho(string texto)
        {
            List<AreaDespacho> areasDespachos = new List<AreaDespacho>();
            AreaDespacho areaDespacho = null;
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
                sqlCommand.CommandText = "USP_Listado_ad";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("cTexto", SqlDbType.VarChar).Value = texto;
                //guarda lo que trae la consulta
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                //lee cada columna hasta el final
                while (sqlDataReader.Read())
                {
                    areaDespacho = new AreaDespacho()
                    {
                        Codigo_ad = Convert.ToInt32(sqlDataReader["codigo_ad"]),
                        Descripcion_ad = sqlDataReader["descripcion_ad"].ToString(),
                        Impresora = sqlDataReader["impresora"].ToString()
                    };
                    areasDespachos.Add(areaDespacho);
                }
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return areasDespachos;
        }

        public async Task<bool> SaveAreaDespacho(int opcion, AreaDespacho areaDespacho)
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
                sqlCommand.CommandText = "USP_Guardar_ma";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("nOpcion", SqlDbType.Int).Value = opcion;
                sqlCommand.Parameters.Add("nCodigo", SqlDbType.Int).Value = areaDespacho.Codigo_ad;
                sqlCommand.Parameters.Add("cDescripcion", SqlDbType.VarChar).Value = areaDespacho.Descripcion_ad;
                sqlCommand.Parameters.Add("cImpresora", SqlDbType.VarChar).Value = areaDespacho.Impresora;
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
