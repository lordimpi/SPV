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
    public class SubFamiliaRepository : ISubFamiliaRepository
    {

        public async Task<bool> DeleteSubFamilia(int id)
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
                sqlCommand.CommandText = "USP_Eliminar_sf";
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

        public async Task<ICollection<SubFamilia>> ListSubFamilias(string texto)
        {
            List<SubFamilia> subFamilias = new List<SubFamilia>();
            SubFamilia subFamilia = null;
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
                sqlCommand.CommandText = "USP_Listado_sf";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("cTexto", SqlDbType.VarChar).Value = texto;
                //guarda lo que trae la consulta
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                //lee cada columna hasta el final
                while (sqlDataReader.Read())
                {
                    subFamilia = new SubFamilia()
                    {
                        Codigo_sf = Convert.ToInt32(sqlDataReader["codigo_sf"]),
                        Descripcion_sf = sqlDataReader["descripcion_sf"].ToString(),
                        Codigo_fa = Convert.ToInt32(sqlDataReader["codigo_fa"]),
                        Descripcion_fa = sqlDataReader["descripcion_fa"].ToString()
                    };
                    subFamilias.Add(subFamilia);
                }
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return subFamilias;
        }

        public async Task<bool> SaveSubFamilia(int opcion, SubFamilia subFamilia)
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
                sqlCommand.CommandText = "USP_Guardar_sf";
                //typo de comando se llama enumerable de tipo procedimiento almacenado
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("nOpcion", SqlDbType.Int).Value = opcion;
                sqlCommand.Parameters.Add("nCodigo", SqlDbType.Int).Value = subFamilia.Codigo_sf;
                sqlCommand.Parameters.Add("cDescripcion", SqlDbType.VarChar).Value = subFamilia.Descripcion_sf;
                sqlCommand.Parameters.Add("nCodigo_fa", SqlDbType.Int).Value = subFamilia.Codigo_fa;
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
