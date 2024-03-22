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
    public static class CuentaBancariaManager
    {
        public static ResultModel<CuentaBancariaEntity> GetCuentaBancariaById(int id)
        {
            ResultModel<CuentaBancariaEntity> result = new ResultModel<CuentaBancariaEntity>();
            using (var connection = ConnectionFactory.CreateConnection())
            {
                connection.Open();

                var data = CuentaBancariaDao.GetById(id, connection);

                if (data != null)
                {
                    result.Result = data;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Cuenta Bancaria no encontrada!";
                }

                connection.Close();
            }

            return result;
        }

        public static ResultModel<List<CuentaBancariaEntity>> GetAllCuentaBancarias(int personaId)
        {
            ResultModel<List<CuentaBancariaEntity>> result = new ResultModel<List<CuentaBancariaEntity>>();
            using (var connection = ConnectionFactory.CreateConnection())
            {
                connection.Open();

                var data = CuentaBancariaDao.GetAllByPersonaId(personaId, connection);

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

        public static ResultModel CrearCuentaBancaria(CuentaBancariaUpdateModel request)
        {
            ResultModel result = new ResultModel();
            using (var connection = ConnectionFactory.CreateConnection())
            {
                connection.Open();
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    CuentaBancariaDao.Create(request, connection, transaction);
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

        public static ResultModel ActualizarCuentaBancaria(int id, CuentaBancariaUpdateModel request)
        {
            ResultModel result = new ResultModel();
            using (var connection = ConnectionFactory.CreateConnection())
            {
                connection.Open();
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    CuentaBancariaDao.Update(id, request, connection, transaction);
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

        public static ResultModel EliminarCuentaBancaria(int id)
        {
            ResultModel result = new ResultModel();
            using (var connection = ConnectionFactory.CreateConnection())
            {
                connection.Open();
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    CuentaBancariaDao.Delete(id, connection, transaction);
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
