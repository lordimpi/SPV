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
    public class UnidadesMedidaRepository : IUnidadesMedidaRepository
    {
        public async Task<bool> DeleteUnidadMedida(int id)
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
                sqlCommand.CommandText = "USP_Eliminar_um";
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

        public async Task<ICollection<UnidadesMedida>> ListUnidadesMedida(string texto)
        {
            List<UnidadesMedida> unidadesMedidas = new List<UnidadesMedida>();
            UnidadesMedida unidadesMedida = null;
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
                sqlCommand.CommandText = "USP_Listado_um";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("cTexto", SqlDbType.VarChar).Value = texto;
                //guarda lo que trae la consulta
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                //lee cada columna hasta el final
                while (sqlDataReader.Read())
                {
                    unidadesMedida = new UnidadesMedida()
                    {
                        Codigo_um = Convert.ToInt32(sqlDataReader["codigo_um"]),
                        Descripcion_um = sqlDataReader["descripcion_um"].ToString(),
                    };
                    unidadesMedidas.Add(unidadesMedida);
                }
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return unidadesMedidas;
        }

        public async Task<bool> SaveUnidadMedida(int opcion, UnidadesMedida unidadesMedida)
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
                sqlCommand.CommandText = "USP_Guardar_um";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("nOpcion", SqlDbType.Int).Value = opcion;
                sqlCommand.Parameters.Add("nCodigo", SqlDbType.Int).Value = unidadesMedida.Codigo_um;
                sqlCommand.Parameters.Add("cDescripcion", SqlDbType.VarChar).Value = unidadesMedida.Descripcion_um;
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