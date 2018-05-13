using System;
using System.Data.SqlClient;

namespace AnnaLeaoStore.Repository.Extensions
{
    public static class SqlParameterCollectionExtensions
    {
        public static SqlParameter AddWithValue(this SqlParameterCollection target, string parameterName, object value, object nullValue)
        {
            if (value == null)
            {
                return target.AddWithValue(parameterName, nullValue ?? DBNull.Value);
            }
            return target.AddWithValue(parameterName, value);
        }
    }
}
