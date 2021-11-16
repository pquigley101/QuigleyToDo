using System;
using System.Collections.Generic;
using System.Text;

namespace QuigleyToDo.DataAccess.Utilities
{
    public static class FieldHelper
    {
        public static string GetString(object candidato)
        {
            if ((candidato == null) || (candidato is DBNull))
                return string.Empty;
            else
                return candidato.ToString();
        }
        public static DateTime GetDateTime(object obj)
        {
            return GetDateTime(obj, DateTime.MinValue);
        }
        public static Decimal GetDecimal(object obj)
        {
            return GetDecimal(obj, 0);
        }
        public static bool GetBool(object obj)
        {
            return GetBool(obj, false);
        }
        private static DateTime GetDateTime(object obj, DateTime defaultValue)
        {
            if (obj is DateTime)
                return (DateTime)obj;

            if (obj == null || obj is DBNull)
                return defaultValue;

            try
            {
                return Convert.ToDateTime(obj);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        public static DateTime? GetNullableDateTime(object obj)
        {
            if (obj is DateTime)
                return (DateTime)obj;

            if (obj == null || obj is DBNull)
                return null;

            try
            {
                return Convert.ToDateTime(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static int? GetNullableInt(object obj)
        {
            if (obj is int)
                return (int)obj;

            if (obj == null || obj is DBNull)
                return null;

            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static decimal GetDecimal(object obj, decimal defaultValue)
        {
            if (obj is decimal)
                return (decimal)obj;

            if (obj == null || obj is DBNull)
                return defaultValue;

            try
            {
                return Convert.ToDecimal(obj);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        public static decimal? GetNullableDecimal(object obj)
        {
            if (obj is decimal)
                return (decimal)obj;

            if (obj == null || obj is DBNull)
                return null;

            try
            {
                return Convert.ToDecimal(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static bool GetBool(object obj, bool defaultValue)
        {
            if (obj is bool)
                return (bool)obj;

            if (obj == null || obj is DBNull)
                return defaultValue;

            try
            {
                return Convert.ToBoolean(obj);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        public static int GetInt(object obj)
        {
            return GetInt(obj, 0);
        }
        private static int GetInt(object obj, int defaultValue)
        {
            if (obj is int)
                return (int)obj;

            if (obj == null || obj is DBNull)
                return defaultValue;

            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        public static long GetLong(object obj)
        {
            return GetLong(obj, 0);
        }
        private static long GetLong(object obj, long defaultValue)
        {
            if (obj is long)
                return (long)obj;

            if (obj == null || obj is DBNull)
                return defaultValue;

            try
            {
                return (long)obj;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        public static double GetDouble(object obj)
        {
            return GetDouble(obj, 0);
        }
        private static double GetDouble(object obj, double defaultValue)
        {
            if (obj is double)
                return (double)obj;

            if (obj == null || obj is DBNull)
                return defaultValue;

            try
            {
                return (double)obj;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}
