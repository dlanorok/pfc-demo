using PFC.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PFC.Demo.Domain.Models.Request;

namespace PFC.Demo.DataAccess
{
    public static class CuentaBancariaDao
    {
        /// <summary>
        /// Obtener el registro de una Cuenta Bancaria por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static  CuentaBancariaEntity GetById(int id, SqlConnection connection, SqlTransaction transaction = default)
        {
            var CuentaBancaria = new CuentaBancariaEntity
            {
                Id = id
            };

            SqlCommand mCommand = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                mCommand.Connection = connection;
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.CommandText = "CuentaBancaria_GetById";

                if (transaction!=null) mCommand.Transaction = transaction;
                #region << Agrego los parametros >>

                mCommand.Parameters.AddWithValue("@Id", CuentaBancaria.Id);

                #endregion

                if (connection.State != ConnectionState.Open) connection.Open();

                reader = mCommand.ExecuteReader();

                if (!reader.HasRows) return null;

                if (reader.Read())
                {        
                    #region << Cargo el objeto de Negocios >>

                    CuentaBancaria.Id = reader.GetIntValue("Id");
                    
                    CuentaBancaria.PersonaId = reader.GetIntValue("PersonaId");
                    CuentaBancaria.NumeroCuenta = reader.GetStringValue("NumeroCuenta");
                    CuentaBancaria.Tipo = reader.GetTipoCuentaValue("Tipo");
                    CuentaBancaria.Balance = reader.GetDecimalValue("Balance");
                    CuentaBancaria.Comentarios = reader.GetStringValue("Comentarios");

                    #endregion
                }

                return CuentaBancaria;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                if (reader != null) reader.Close();
                mCommand.Dispose();
            }
        }

        /// <summary>
        /// Obtener el registro de todas las CuentaBancarias
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static List<CuentaBancariaEntity> GetAllByPersonaId(int personaId, SqlConnection connection, SqlTransaction transaction = default)
        {
            var result = new List<CuentaBancariaEntity>();
            var mCommand = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                mCommand.Connection = connection;
                mCommand.CommandType = CommandType.StoredProcedure;
                
                mCommand.CommandText = "CuentaBancaria_GetAllByPersonaId";

                if (transaction != null) mCommand.Transaction = transaction;
                #region << Agrego los parametros >>

                mCommand.Parameters.AddWithValue("@PersonaId", personaId);

                # endregion 
                
                if (connection.State != ConnectionState.Open) connection.Open();

                reader = mCommand.ExecuteReader();

                if (!reader.HasRows) return result;

                while (reader.Read())
                {
                    #region << Cargo el objeto de Negocios >>

                    var CuentaBancaria = new CuentaBancariaEntity
                    {
                        Id = reader.GetIntValue("Id"),

                        PersonaId = reader.GetIntValue("PersonaId"),
                        NumeroCuenta = reader.GetStringValue("NumeroCuenta"),
                        Tipo = reader.GetTipoCuentaValue("Tipo"),
                        Balance = reader.GetDecimalValue("Balance"),
                        Comentarios = reader.GetStringValue("Comentarios")
                    };

                    #endregion

                    result.Add(CuentaBancaria);
                }

                return result;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                if (reader != null) reader.Close();
                mCommand.Dispose();
            }
        }

        /// <summary>
        /// Crear registro de CuentaBancarias
        /// </summary>
        /// <param name="CuentaBancaria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public static void Create(CuentaBancariaUpdateModel CuentaBancaria, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand mCommand = new SqlCommand();
            try
            {
                mCommand.Connection = connection;
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.Transaction = transaction; ;
                mCommand.CommandText = "CuentaBancaria_Create";

                #region << Agrego los parametros >>

                mCommand.Parameters.AddWithValue("@PersonaId", CuentaBancaria.PersonaId);
                mCommand.Parameters.AddWithValue("@NumeroCuenta", CuentaBancaria.NumeroCuenta);
                mCommand.Parameters.AddWithValue("@Tipo", (short)CuentaBancaria.Tipo);
                mCommand.Parameters.AddWithValue("@Balance", CuentaBancaria.Balance);
                mCommand.Parameters.AddWithValue("@Comentarios", CuentaBancaria.Comentarios); 
               
                #endregion

                if (connection.State != ConnectionState.Open) connection.Open();
                mCommand.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                mCommand.Dispose();
            }
        }

        /// <summary>
        /// Actualizar registro de CuentaBancarias 
        /// </summary>
        /// <param name="CuentaBancaria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public static void Update(int id, CuentaBancariaUpdateModel CuentaBancaria, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand mCommand = new SqlCommand();
            try
            {
                mCommand.Connection = connection;
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.Transaction = transaction; ;
                mCommand.CommandText = "CuentaBancaria_Update";

                #region << Agrego los parametros >>

                mCommand.Parameters.AddWithValue("@Id", id);
                mCommand.Parameters.AddWithValue("@PersonaId", CuentaBancaria.PersonaId);
                mCommand.Parameters.AddWithValue("@NumeroCuenta", CuentaBancaria.NumeroCuenta);
                mCommand.Parameters.AddWithValue("@Tipo", (short)CuentaBancaria.Tipo);
                mCommand.Parameters.AddWithValue("@Balance", CuentaBancaria.Balance);
                mCommand.Parameters.AddWithValue("@Comentarios", CuentaBancaria.Comentarios);


                #endregion

                // Abrimos la conexion para ejecutar el comando
                if (connection.State != ConnectionState.Open) connection.Open();
                mCommand.ExecuteNonQuery();


            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                mCommand.Dispose();
            }
        }

        /// <summary>
        /// Eliminar registro de CuentaBancaria
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public static void Delete(int id, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand mCommand = new SqlCommand();
            try
            {
                mCommand.Connection = connection;
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.Transaction = transaction; ;
                mCommand.CommandText = "CuentaBancaria_Delete";
                mCommand.Parameters.AddWithValue("@Id", id);

                // Abrimos la conexion para ejecutar el comando
                if (connection.State != ConnectionState.Open) connection.Open();
                mCommand.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                mCommand.Dispose();
            }
        }

    }



}



