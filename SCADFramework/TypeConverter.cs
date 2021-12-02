using System;
using System.Collections.Generic;
using System.Globalization;

namespace SCADFramework
{
    public class TypeConverter
    {
        private static IDictionary<string, TypeMapper.SQLDataTypes> TypesMap => TypeMapper.GetSQLTypeDict();
        private static IDictionary<string, TypeMapper.PGSQLDataTypes> PGTypesMap => TypeMapper.PGGetSQLTypeDict();
        public static ConvertedItem GetConvertedItem(string typeName, object currentValue, IFormatProvider formatProvider = null)
        {
            if (currentValue == null)
            {
                return new ConvertedItem(null);
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentUICulture;
            }

            switch (typeName)
            {
                case "uniqueidentifier":
                    return new ConvertedItem(new Guid(currentValue.ToString()));
                case "money":
                case "decimal":
                case "real":
                case "smallmoney":
                case "bigint":
                case "smallint":
                case "tinyint":
                case "integer":
                case "numeric":
                case "char":
                case "smalldatetime":
                case "datetime":
                case "datetime2":
                case "date":
                    return new ConvertedItem(RunTypeConversion(currentValue, typeName, TypesMap[typeName].Type, formatProvider));
                case "bit":
                    try
                    {
                        return new ConvertedItem(RunTypeConversion(currentValue, typeName, TypesMap[typeName].Type,
                            formatProvider));
                    }
                    catch (Exception)
                    {
                        var intValue = RunTypeConversion(currentValue, typeName, typeof(int), formatProvider);
                        return new ConvertedItem(RunTypeConversion(intValue, typeName, TypesMap[typeName].Type,
                            formatProvider));
                    }
                case "null":
                    return new ConvertedItem(null);
                case "varbinary":
                    return new ConvertedItem(currentValue);
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                    return new ConvertedItem(currentValue.ToString());
                case "time":
                    return new ConvertedItem(TimeSpan.Parse(currentValue.ToString(), formatProvider));
                case "datetimeoffset":
                    return new ConvertedItem(DateTimeOffset.Parse(currentValue.ToString(), formatProvider));
                default:
                    return new ConvertedItem(currentValue);

            }
        }


        public static Object GetConvertedItemPG(string typeName, object currentValue, IFormatProvider formatProvider = null)
        {
            if (currentValue == null)
            {
                return null;
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentUICulture;
            }

            switch (typeName)
            {
               case "boolean":
                    try
                        {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                        }
                        catch (Exception)
                        {
                            var intValue = RunTypeConversion(currentValue, typeName, typeof(int), formatProvider);
                        return intValue;
                        }
                case "smallint":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                case "integer":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "bigint":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "real":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "double precision":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "numeric":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "money":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "text":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "character varying":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "character":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "citext":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "json":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "jsonb":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "xml":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "uuid":
                    return new Guid(currentValue.ToString());
                case "bytea":
                    return new ConvertedItem(currentValue);
                case "timestamp without time zone":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "timestamp with time zone":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "date":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "time without time zone":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "time with time zone":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "interval":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "cidr":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "inet":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "macaddr":
                    try
                    {
                        return RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case "tsquery":  return new ConvertedItem(currentValue);
                case "tsvector":  return new ConvertedItem(currentValue);
                case "bit":
                    try
                    {
                        return new ConvertedItem(RunTypeConversion(currentValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider));
                    }
                    catch (Exception)
                    {
                        var intValue = RunTypeConversion(currentValue, typeName, typeof(int), formatProvider);
                        return new ConvertedItem(RunTypeConversion(intValue, typeName, PGTypesMap[typeName].Type,
                            formatProvider));
                    }
                case "bit varying":  return new ConvertedItem(currentValue);
                case "point":  return new ConvertedItem(currentValue);
                case "lseg":  return new ConvertedItem(currentValue);
                case "path":  return new ConvertedItem(currentValue);
                case "polygon":  return new ConvertedItem(currentValue);
                case "line":  return new ConvertedItem(currentValue);
                case "circle":  return new ConvertedItem(currentValue);
                case "box":  return new ConvertedItem(currentValue);
                case "hstore":  return new ConvertedItem(currentValue);
                case "oid":  return new ConvertedItem(currentValue);
                case "xid":  return new ConvertedItem(currentValue);
                case "cid":  return new ConvertedItem(currentValue);
                case "oidvector":  return new ConvertedItem(currentValue);
                case "name":  return new ConvertedItem(currentValue);
                case "composite types":  return new ConvertedItem(currentValue);
                case "range types":  return new ConvertedItem(currentValue);
                case "enum types":  return new ConvertedItem(currentValue);
                case "array types":  return new ConvertedItem(currentValue);
                case "null":
                    return new ConvertedItem(null);
                case "time":
                    return new ConvertedItem(TimeSpan.Parse(currentValue.ToString(), formatProvider));
                case "datetimeoffset":
                    return new ConvertedItem(DateTimeOffset.Parse(currentValue.ToString(), formatProvider));
                default:
                    return new ConvertedItem(currentValue);

            }
        }
        private static object RunTypeConversion(object value, string typeName, Type type, IFormatProvider formatProvider)
        {
            try
            {
                return Convert.ChangeType(value, type, formatProvider);
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to convert {value} to {typeName}. {e.Message}");
            }
        }

        public class ConvertedItem
        {
            public ConvertedItem(object value)
            {
                Value = value;
            }

            public ConvertedItem()
            {

            }

            public object Value { get; set; }
        }
    }
}
