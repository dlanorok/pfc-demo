using PFC.Demo.Domain.Models;
using PFC.Demo.DataAccess;
using PFC.Demo.Domain.Models;
using PFC.Demo.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFC.Demo.BusinessLogic
{
    public static class PersonaManager
    {
        public static ResultModel<PersonaViewModel> GetPersonaById(int id)
        {
            ResultModel<PersonaViewModel> result = new ResultModel<PersonaViewModel>();
            using (var connection = ConnectionFactory.CreateConnection())
            {
                connection.Open();

                var data = PersonaDao.GetById(id, connection);

                if (data != null)
                {
                    var cuentasBancarias = CuentaBancariaDao.GetAllByPersonaId(id, connection);
                    data.CuentasBancarias = cuentasBancarias;
                    
                    result.Result = data;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Persona no encontrada!";
                }

                connection.Close();
            }

            return result;
        }

        public static ResultModel<List<PersonaEntity>> GetAllPersonas()
        {
            ResultModel<List<PersonaEntity>> result = new ResultModel<List<PersonaEntity>>();
            using (var connection = ConnectionFactory.CreateConnection())
            {
                connection.Open();

                var data = PersonaDao.GetAll(connection);

                if (data != null)
                {
                    result.Result = data;
                }
                else
                {
                    result.Success = false;
                    result.Message = "No se encontraron registros!";
                }

                connection.Close();
            }

            return result;
        }

        public static ResultModel CrearPersona(PersonaUpdateModel request)
        {
            ResultModel result = new ResultModel();
            using (var connection = ConnectionFactory.CreateConnection())
            {
                connection.Open();
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    PersonaDao.Create(request, connection, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    if(connection != null)
                    {
                        connection.Close();
                    }
                }
            }

            return result;
        }

        public static ResultModel ActualizarPersona(int id, PersonaUpdateModel request)
        {
            ResultModel result = new ResultModel();
            using (var connection = ConnectionFactory.CreateConnection())
            {
                connection.Open();
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    PersonaDao.Update(id, request, connection, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }

            return result;
        }

        public static ResultModel EliminarPersona(int id)
        {
            ResultModel result = new ResultModel();
            using (var connection = ConnectionFactory.CreateConnection())
            {
                connection.Open();
                SqlTransaction transaction = null;
                try
                {
                    var cuentasBancarias = CuentaBancariaDao.GetAllByPersonaId(id, connection, transaction);
                    if (cuentasBancarias.Count > 0)
                    {
                        throw new Exception("El registro no se puede eliminar porque tiene cuentas activas.");
                    }
                    
                    transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    PersonaDao.Delete(id, connection, transaction);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }

            return result;
        }
    }
}
