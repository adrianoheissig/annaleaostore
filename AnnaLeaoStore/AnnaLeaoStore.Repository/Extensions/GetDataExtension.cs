using System.Data;

namespace AnnaLeaoStore.Repository.Extensions
{
    public static class GetDataExtension
    {
        public static T? GetValue<T>(this DataRow row, string columnName) where T : struct
        {
            if (row.IsNull(columnName))
                return null;

            return row[columnName] as T?;
        }

        public static string GetText(this DataRow row, string columnName)
        {
            if (row.IsNull(columnName))
                return string.Empty;

            return row[columnName] as string ?? string.Empty;
        }

        public static bool GetBool(this DataRow row, string columnName)
        {
            if (row.IsNull(columnName))
                return false;

            //return row[columnName] as string ?? string.Empty;

            return row[columnName].ToString().ToUpper()  == "TRUE" ? true : false ;
        }
    }
}