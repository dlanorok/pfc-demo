using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using PFC.Demo.DataAccess.Entities;

namespace PFC.Demo.DataAccess
{
    public static class PersonaDao
    {
        /// <summary>
        /// Obtener el registro de una persona por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static PersonaEntity GetById(
            int id,
            SqlConnection connection,
            SqlTransaction transaction = null
        )
        {
            var persona = new PersonaEntity
            {
                Id = id
            };

            SqlCommand mCommand = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                mCommand.Connection  = connection;
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.CommandText = "Persona_GetById";

                if (transaction != null) mCommand.Transaction = transaction;

                #region << Agrego los parametros >>

                mCommand.Parameters.AddWithValue("@Id", persona.Id);

                #endregion

                if (connection.State != ConnectionState.Open) connection.Open();

                reader = mCommand.ExecuteReader();

                if (!reader.HasRows) return null;

                if (reader.Read())
                {
                    #region << Cargo el objeto de Negocios >>

                    persona.Id              = reader.GetIntValue("Id");
                    persona.Identificacion  = reader.GetStringValue("Identificacion");
                    persona.Nombre          = reader.GetStringValue("Nombre");
                    persona.Apellidos       = reader.GetStringValue("Apellidos");
                    persona.FechaNacimiento = reader.GetDateTimeValue("FechaNacimiento");
                    persona.Direccion       = reader.GetStringValue("Direccion");
                    persona.Referencia      = reader.GetStringValue("Referencia");
                    persona.Ciudad          = reader.GetStringValue("Ciudad");
                    persona.Provincia       = reader.GetStringValue("Provincia");
                    persona.Pais            = reader.GetStringValue("Pais");
                    persona.CodigoPostal    = reader.GetStringValue("CodigoPostal");

                    #endregion
                }

                return persona;
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
        /// Obtener el registro de todas las personas
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static List<PersonaEntity> GetAll(
            SqlConnection connection,
            SqlTransaction transaction = default
        )
        {
            var result = new List<PersonaEntity>();
            var mCommand = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                mCommand.Connection  = connection;
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.CommandText = "Persona_GetAll";

                if (transaction != null) mCommand.Transaction = transaction;

                if (connection.State != ConnectionState.Open) connection.Open();

                reader = mCommand.ExecuteReader();

                if (!reader.HasRows) return result;

                while (reader.Read())
                {
                    #region << Cargo el objeto de Negocios >>

                    var persona = new PersonaEntity
                    {
                        Id              = reader.GetIntValue("Id"),
                        Identificacion  = reader.GetStringValue("Identificacion"),
                        Nombre          = reader.GetStringValue("Nombre"),
                        Apellidos       = reader.GetStringValue("Apellidos"),
                        FechaNacimiento = reader.GetDateTimeValue("FechaNacimiento"),
                        Direccion       = reader.GetStringValue("Direccion"),
                        Referencia      = reader.GetStringValue("Referencia"),
                        Ciudad          = reader.GetStringValue("Ciudad"),
                        Provincia       = reader.GetStringValue("Provincia"),
                        Pais            = reader.GetStringValue("Pais"),
                        CodigoPostal    = reader.GetStringValue("CodigoPostal")
                    };

                    #endregion

                    result.Add(persona);
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
        /// Crear registro de personas
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public static void Create(
            PersonaUpdateEntity persona,
            SqlConnection connection,
            SqlTransaction transaction
        )
        {
            SqlCommand mCommand = new SqlCommand();
            try
            {
                mCommand.Connection  = connection;
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.Transaction = transaction;
                ;
                mCommand.CommandText = "Persona_Create";

                #region << Agrego los parametros >>

                mCommand.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                mCommand.Parameters.AddWithValue("@Nombre", persona.Nombre);
                mCommand.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                mCommand.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                mCommand.Parameters.AddWithValue("@Direccion", persona.Direccion);
                mCommand.Parameters.AddWithValue("@Referencia", persona.Referencia);
                mCommand.Parameters.AddWithValue("@Ciudad", persona.Ciudad);
                mCommand.Parameters.AddWithValue("@Provincia", persona.Provincia);
                mCommand.Parameters.AddWithValue("@Pais", persona.Pais);

                if (!String.IsNullOrEmpty(persona.CodigoPostal))
                {
                    mCommand.Parameters.AddWithValue("@CodigoPostal", persona.CodigoPostal.ToUpper());
                }
                else
                {
                    mCommand.Parameters.AddWithValue("@CodigoPostal", DBNull.Value);
                }

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
        /// Actualizar registro de personas 
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public static void Update(
            int id,
            PersonaUpdateEntity persona,
            SqlConnection connection,
            SqlTransaction transaction
        )
        {
            SqlCommand mCommand = new SqlCommand();
            try
            {
                mCommand.Connection  = connection;
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.Transaction = transaction;
                mCommand.CommandText = "Persona_Update";

                #region << Agrego los parametros >>

                mCommand.Parameters.AddWithValue("@Id", id);
                mCommand.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                mCommand.Parameters.AddWithValue("@Nombre", persona.Nombre);
                mCommand.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                mCommand.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                mCommand.Parameters.AddWithValue("@Direccion", persona.Direccion);
                mCommand.Parameters.AddWithValue("@Referencia", persona.Referencia);
                mCommand.Parameters.AddWithValue("@Ciudad", persona.Ciudad);
                mCommand.Parameters.AddWithValue("@Provincia", persona.Provincia);
                mCommand.Parameters.AddWithValue("@Pais", persona.Pais);

                if (!String.IsNullOrEmpty(persona.CodigoPostal))
                {
                    mCommand.Parameters.AddWithValue("@CodigoPostal", persona.CodigoPostal.ToUpper());
                }
                else
                {
                    mCommand.Parameters.AddWithValue("@CodigoPostal", DBNull.Value);
                }

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
        /// Eliminar registro de persona
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public static void Delete(
            int id,
            SqlConnection connection,
            SqlTransaction transaction
        )
        {
            SqlCommand mCommand = new SqlCommand();
            try
            {
                mCommand.Connection  = connection;
                mCommand.CommandType = CommandType.StoredProcedure;
                mCommand.Transaction = transaction;
                mCommand.CommandText = "Persona_Delete";
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