using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFC.Demo.DataAccess
{
    public static class DataExtensions
    {
        public static string GetStringValue(this SqlDataReader dataReader, string fieldName)
        {
            var fieldIndex = dataReader.GetOrdinal(fieldName);
            if (fieldIndex > -1 && !dataReader.IsDBNull(fieldIndex))
            {
                return dataReader.GetString(fieldIndex);
            }
            return null;
        }

        public static TipoCuentaEnum GetTipoCuentaValue(this SqlDataReader dataReader, string fieldName)
        {
            var fieldIndex = dataReader.GetOrdinal(fieldName);
            if (fieldIndex > -1 && !dataReader.IsDBNull(fieldIndex))
            {
                var value = dataReader.GetInt16(fieldIndex);
                return (TipoCuentaEnum)value;
            }
            return 0;
        }

        public static int GetIntValue(this SqlDataReader dataReader, string fieldName)
        {
            var fieldIndex = dataReader.GetOrdinal(fieldName);
            if (fieldIndex > -1 && !dataReader.IsDBNull(fieldIndex))
            {
                return dataReader.GetInt32(fieldIndex);
            }
            return 0;
        }

        public static decimal GetDecimalValue(this SqlDataReader dataReader, string fieldName)
        {
            var fieldIndex = dataReader.GetOrdinal(fieldName);
            if (fieldIndex > -1 && !dataReader.IsDBNull(fieldIndex))
            {
                return dataReader.GetDecimal(fieldIndex);
            }
            return 0M;
        }

        public static DateTime GetDateTimeValue(this SqlDataReader dataReader, string fieldName)
        {
            var fieldIndex = dataReader.GetOrdinal(fieldName);
            if (fieldIndex > -1 && !dataReader.IsDBNull(fieldIndex))
            {
                var value = dataReader.GetDateTime(fieldIndex);
                if (value > DateTime.Now.AddYears(-100))
                {
                    return value;
                }
            }
            return new DateTime(2000, 1, 1);
        }

        public static bool GetBooleanValue(this SqlDataReader dataReader, string fieldName)
        {
            var fieldIndex = dataReader.GetOrdinal(fieldName);
            if (fieldIndex > -1 && !dataReader.IsDBNull(fieldIndex))
            {
                return dataReader.GetBoolean(fieldIndex);
            }
            return false;
        }
    }
}
