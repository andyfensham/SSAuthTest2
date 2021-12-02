using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;

namespace SCADFramework
{
    public class TypeMapper
    {
        public static IDictionary<string, SQLDataTypes> GetSQLTypeDict()
        {
            IDictionary<string, SQLDataTypes> dict = new Dictionary<string, SQLDataTypes>();

            dict.Add("bigint", new SQLDataTypes() { Type = typeof(long), DbType = DbType.Int64, SqlDbType = SqlDbType.BigInt });
            dict.Add("binary", value: new SQLDataTypes() { Type = typeof(byte[]), DbType = DbType.Binary, SqlDbType = SqlDbType.VarBinary });
            dict.Add("bit", new SQLDataTypes() { Type = typeof(bool), DbType = DbType.Boolean, SqlDbType = SqlDbType.Bit });
            dict.Add("char", value: new SQLDataTypes() { Type = typeof(char), DbType = DbType.String, SqlDbType = SqlDbType.Char });
            dict.Add("date", value: new SQLDataTypes() { Type = typeof(DateTime), DbType = DbType.Date, SqlDbType = SqlDbType.Date });
            dict.Add("datetime", new SQLDataTypes() { Type = typeof(DateTime), DbType = DbType.DateTime, SqlDbType = SqlDbType.DateTime });
            dict.Add("datetime2", new SQLDataTypes() { Type = typeof(DateTime), DbType = DbType.DateTime2, SqlDbType = SqlDbType.DateTime2 });
            dict.Add("datetimeoffset", new SQLDataTypes() { Type = typeof(DateTimeOffset), DbType = DbType.DateTimeOffset, SqlDbType = SqlDbType.DateTimeOffset });
            dict.Add("decimal", new SQLDataTypes() { Type = typeof(decimal), DbType = DbType.Decimal, SqlDbType = SqlDbType.Decimal });
            dict.Add("float", new SQLDataTypes() { Type = typeof(double), DbType = DbType.Double, SqlDbType = SqlDbType.Float });
            dict.Add("image", new SQLDataTypes() { Type = typeof(byte), DbType = DbType.Binary, SqlDbType = SqlDbType.Image });
            dict.Add("int", new SQLDataTypes() { Type = typeof(int), DbType = DbType.Int32, SqlDbType = SqlDbType.Int });
            dict.Add("money", new SQLDataTypes() { Type = typeof(decimal), DbType = DbType.Decimal, SqlDbType = SqlDbType.Money });
            dict.Add("nchar", new SQLDataTypes() { Type = typeof(string), DbType = DbType.AnsiStringFixedLength, SqlDbType = SqlDbType.NChar });
            dict.Add("ntext", new SQLDataTypes() { Type = typeof(string), DbType = DbType.String, SqlDbType = SqlDbType.NText });
            dict.Add("numeric", new SQLDataTypes() { Type = typeof(decimal), DbType = DbType.Decimal, SqlDbType = SqlDbType.Decimal });
            dict.Add("nvarchar", new SQLDataTypes() { Type = typeof(string), DbType = DbType.String, SqlDbType = SqlDbType.NVarChar });
            dict.Add("real", new SQLDataTypes() { Type = typeof(float), DbType = DbType.Single, SqlDbType = SqlDbType.Real });
            dict.Add("smalldatetime", new SQLDataTypes() { Type = typeof(DateTime), DbType = DbType.DateTime, SqlDbType = SqlDbType.SmallDateTime });
            dict.Add("smallint", new SQLDataTypes() { Type = typeof(short), DbType = DbType.Int16, SqlDbType = SqlDbType.SmallInt });
            dict.Add("smallmoney", new SQLDataTypes() { Type = typeof(decimal), DbType = DbType.Decimal, SqlDbType = SqlDbType.SmallMoney });
            dict.Add("sql_variant", new SQLDataTypes() { Type = typeof(object), DbType = DbType.Object, SqlDbType = SqlDbType.Variant });
            dict.Add("text", new SQLDataTypes() { Type = typeof(string), DbType = DbType.String, SqlDbType = SqlDbType.Text });
            dict.Add("time", new SQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.Time, SqlDbType = SqlDbType.Time });
            dict.Add("timestamp", new SQLDataTypes() { Type = typeof(byte), DbType = DbType.Binary, SqlDbType = SqlDbType.Timestamp });
            dict.Add("tinyint", new SQLDataTypes() { Type = typeof(byte), DbType = DbType.Byte, SqlDbType = SqlDbType.TinyInt });
            dict.Add("uniqueidentifier", new SQLDataTypes() { Type = typeof(Guid), DbType = DbType.Guid, SqlDbType = SqlDbType.UniqueIdentifier });
            dict.Add("varbinary", new SQLDataTypes() { Type = typeof(byte[]), DbType = DbType.Binary, SqlDbType = SqlDbType.VarBinary });
            dict.Add("varchar", new SQLDataTypes() { Type = typeof(string), DbType = DbType.String, SqlDbType = SqlDbType.VarChar });
            dict.Add("xml", new SQLDataTypes() { Type = Type.GetType("System.Xml"), DbType = DbType.Xml, SqlDbType = SqlDbType.Xml });

            return dict;
        }

        public static IDictionary<string, PGSQLDataTypes> PGGetSQLTypeDict()
        {
            IDictionary<string, PGSQLDataTypes> dict = new Dictionary<string, PGSQLDataTypes>();

            dict.Add("boolean", new PGSQLDataTypes() { Type = typeof(bool), DbType = DbType.Boolean, PgDBType = NpgsqlDbType.Boolean });
            dict.Add("smallint", new PGSQLDataTypes() { Type = typeof(short), DbType = DbType.Int16, PgDBType = NpgsqlDbType.Smallint });
            dict.Add("integer", new PGSQLDataTypes() { Type = typeof(int), DbType = DbType.Int32, PgDBType = NpgsqlDbType.Integer });
            dict.Add("bigint", new PGSQLDataTypes() { Type = typeof(long), DbType = DbType.Int64, PgDBType = NpgsqlDbType.Bigint });
            dict.Add("real", new PGSQLDataTypes() { Type = typeof(float), DbType = DbType.Single, PgDBType = NpgsqlDbType.Real });
            dict.Add("double precision", new PGSQLDataTypes() { Type = typeof(double), DbType = DbType.Double, PgDBType = NpgsqlDbType.Double });
            dict.Add("numeric", new PGSQLDataTypes() { Type = typeof(decimal), DbType = DbType.Decimal, PgDBType = NpgsqlDbType.Numeric });
            dict.Add("money", new PGSQLDataTypes() { Type = typeof(decimal), DbType = DbType.Currency, PgDBType = NpgsqlDbType.Money });
            dict.Add("text", new PGSQLDataTypes() { Type = typeof(string), DbType = DbType.String, PgDBType = NpgsqlDbType.Text });
            dict.Add("character varying", new PGSQLDataTypes() { Type = typeof(string), DbType = DbType.String, PgDBType = NpgsqlDbType.Varchar });
            dict.Add("character", new PGSQLDataTypes() { Type = typeof(string), DbType = DbType.String, PgDBType = NpgsqlDbType.Char });
            dict.Add("citext", new PGSQLDataTypes() { Type = typeof(string), DbType = DbType.String, PgDBType = NpgsqlDbType.Citext });
            dict.Add("json", new PGSQLDataTypes() { Type = typeof(string), DbType = DbType.String, PgDBType = NpgsqlDbType.Json });
            dict.Add("jsonb", new PGSQLDataTypes() { Type = typeof(string), DbType = DbType.String, PgDBType = NpgsqlDbType.Jsonb });
            dict.Add("xml", new PGSQLDataTypes() { Type = typeof(string), DbType = DbType.String, PgDBType = NpgsqlDbType.Xml });
            dict.Add("uuid", new PGSQLDataTypes() { Type = typeof(Guid), DbType = DbType.String, PgDBType = NpgsqlDbType.Uuid });
            dict.Add("bytea", new PGSQLDataTypes() { Type = typeof(byte[]), DbType = DbType.Binary, PgDBType = NpgsqlDbType.Bytea });
            dict.Add("timestamp without time zone", new PGSQLDataTypes() { Type = typeof(DateTime), DbType = DbType.DateTime2, PgDBType = NpgsqlDbType.Timestamp });
            dict.Add("timestamp with time zone", new PGSQLDataTypes() { Type = typeof(DateTime), DbType = DbType.DateTime2, PgDBType = NpgsqlDbType.Timestamp });
            dict.Add("date", new PGSQLDataTypes() { Type = typeof(DateTime), DbType = DbType.Date, PgDBType = NpgsqlDbType.Date });
            dict.Add("time without time zone", new PGSQLDataTypes() { Type = typeof(DateTimeOffset), DbType = DbType.Time, PgDBType = NpgsqlDbType.Time });
            dict.Add("time with time zone", new PGSQLDataTypes() { Type = typeof(DateTimeOffset), DbType = DbType.String, PgDBType = NpgsqlDbType.TimeTz });
            dict.Add("interval", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Interval });
            dict.Add("cidr", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Cidr });
            dict.Add("inet", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Inet });
            dict.Add("macaddr", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.MacAddr });
            dict.Add("tsquery", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.TsQuery });
            dict.Add("tsvector", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.TsVector });
            dict.Add("bit", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Bit });
            dict.Add("bit varying", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Varbit });
            dict.Add("point", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Point });
            dict.Add("lseg", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.LSeg });
            dict.Add("path", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Path });
            dict.Add("polygon", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Polygon });
            dict.Add("line", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Line });
            dict.Add("circle", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Circle });
            dict.Add("box", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Box });
            dict.Add("hstore", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Hstore });
            dict.Add("oid", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Oid });
            dict.Add("xid", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Xid });
            dict.Add("cid", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Cid });
            dict.Add("oidvector", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Oidvector });
            dict.Add("name", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Name });
            dict.Add("range types", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Range });
            dict.Add("array types", new PGSQLDataTypes() { Type = typeof(TimeSpan), DbType = DbType.String, PgDBType = NpgsqlDbType.Array });
            

            return dict;
        }
        public class SQLDataTypes
        {
            public string SQLTypeName { get; set; }
            public string DotNetTypeName { get; set; }
            public string SqlDBTypeName { get; set; }
            public string SqlDataRaderSQLTypeName { get; set; }
            public string DBTypeName { get; set; }
            public string SQLDataRaederDBTypeName { get; set; }
            public Type Type { get; set; }
            public DbType DbType { get; set; }
            public SqlDbType SqlDbType { get; set; }

            
        }


        public class PGSQLDataTypes
        {
            public string SQLTypeName { get; set; }
            public Type Type { get; set; }
            public DbType DbType { get; set; }
         
            public NpgsqlDbType PgDBType { get; set; }
        }
    }
}
