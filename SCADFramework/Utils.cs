using System;
using System.Collections.Generic;
using HandlebarsDotNet;
using ServiceStack.Caching;
using System.Linq;
using ServiceStack.OrmLite;
using digitaluapi.ServiceModel.Types;
using ServiceStack.OrmLite.PostgreSQL;
using ServiceStack.OrmLite.PostgreSQL.Converters;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.OrmLite.Dapper;
using ServiceStack.Configuration;
using ServiceStack;
using ServiceStack.Data;
using System.Data;
using Npgsql;

namespace SCADFramework
{

    public class Utils
    {
        private static readonly IAppSettings Settings = HostContext.AppSettings;
        private static IDictionary<string, TypeMapper.PGSQLDataTypes> PGTypesMap => TypeMapper.PGGetSQLTypeDict();
        public ICacheClient? CacheClient { get; set; }
        //public static string RunTemplate(int TemplateId, string TemplateText, dynamic templateData)
        //{

        //    var CachedTemplate = CacheClient.Get<TemplateCacheItem>(TemplateId.ToString());
        //    if (CachedTemplate is null)
        //    {
        //        var template = Handlebars.Compile(TemplateText);
        //        CacheClient.Set<TemplateCacheItem>(TemplateId.ToString(), new TemplateCacheItem() { Template = template });
        //        return template(templateData);
        //    }
        //    else
        //    {
        //        return CachedTemplate.Template(templateData);
        //    }

        //}

        public class TemplateCacheItem
        {
            public HandlebarsTemplate<object,object>  Template { get; set; }
        }

        public static List<IDictionary<string, object>> DapperDynamicToIDictionaryList(dynamic d)
        {
            List<IDictionary<string, object>> dl = new List<IDictionary<string, object>>();
            foreach (var item in d)
            {
                var rowdict = (IDictionary<string, object>)item;
                IDictionary<string, object> drecord = new Dictionary<string, object>();
                foreach (KeyValuePair<string, object> kv in rowdict)
                {
                    drecord.Add(kv.Key, kv.Value);
                }
                dl.Add(drecord);
            }
            return dl;
        }

        public static DateTime GetLatestModifiedDate(List<dynamic> dapperData, string fieldName)
        {

            var dictList = DapperDynamicToIDictionaryList(dapperData);
            var allDates = dictList.Select(d => Convert.ToDateTime(d[fieldName]));
            var LastModified = allDates.OrderByDescending(x => x).First();


            return LastModified;
        }

        public static IEnumerable<dynamic> GetData(object d, string cachekey, string sql, System.Data.CommandType ct, string ConnectionName, string ConnectionString, int DBTechnologiesId)
        {

            string connString = "";
            
            if (ConnectionName is not null)
            {
                connString = Settings.GetString($"ConnectionStrings:{ConnectionName}");
            }
            else
            {
                connString = ConnectionString;
            }
            

           
            OrmLiteConnectionFactory factory;
            OrmLiteConnection cnn;
            switch (DBTechnologiesId)
            {
                case 1:
                    factory = new OrmLiteConnectionFactory(connString, SqlServerDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                case 2:
                    factory = new OrmLiteConnectionFactory(connString, SqliteDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                case 3:
                    factory = new OrmLiteConnectionFactory(connString, PostgreSqlDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                default:
                    factory = new OrmLiteConnectionFactory(connString, PostgreSqlDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;

            }


            using (var db = factory.OpenDbConnection())
            {
                var result = db.Query(sql, d, null, true, null, ct).ToList();
                
                return result;
            }

        }

        public static IEnumerable<dynamic> ExecuteData(object d, string cachekey, string sql, System.Data.CommandType ct, string ConnectionName, string ConnectionString, int DBTechnologiesId)
        {

            string connString = "";

            if (ConnectionName is not null)
            {
                connString = Settings.GetString($"ConnectionStrings:{ConnectionName}");
            }
            else
            {
                connString = ConnectionString;
            }



            OrmLiteConnectionFactory factory;
            OrmLiteConnection cnn;
            switch (DBTechnologiesId)
            {
                case 1:
                    factory = new OrmLiteConnectionFactory(connString, SqlServerDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                case 2:
                    factory = new OrmLiteConnectionFactory(connString, SqliteDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                case 3:
                    factory = new OrmLiteConnectionFactory(connString, PostgreSqlDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                default:
                    factory = new OrmLiteConnectionFactory(connString, PostgreSqlDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;

            }


            using (var db = factory.OpenDbConnection())
            {
                var result = db.Query(sql, d, null, true, null, ct).ToList();

                return result;
            }

        }

        public static dynamic InsertData(object d, string cachekey, string sql, System.Data.CommandType ct, string ConnectionName, string ConnectionString, int DBTechnologiesId)
        {

            string connString = "";

            if (ConnectionName is not null)
            {
                connString = Settings.GetString($"ConnectionStrings:{ConnectionName}");
            }
            else
            {
                connString = ConnectionString;
            }



            OrmLiteConnectionFactory factory;
            OrmLiteConnection cnn;
            switch (DBTechnologiesId)
            {
                case 1:
                    factory = new OrmLiteConnectionFactory(connString, SqlServerDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                case 2:
                    factory = new OrmLiteConnectionFactory(connString, SqliteDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                case 3:
                    factory = new OrmLiteConnectionFactory(connString, PostgreSqlDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                default:
                    factory = new OrmLiteConnectionFactory(connString, PostgreSqlDialect.Provider);
                    cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;

            }


            using (var db = factory.OpenDbConnection())
            {
                //var result = db.Execute(sql, d, null, null,ct);
                var result = db.Query(sql, d, null, true, null, ct).SingleOrDefault();
                return result;
            }

        }



        public static List<dynamic> RunMetaQuery(int QueriesId, DynamicParameters p)
        {
            DynamicParameters pQuery = new DynamicParameters();
            string querySQL = @"select q.*, c.connection_string,ct.description as command_type from metaimport.meta_queries q 
                    left outer join meta.connections c on c.id = q.connections_id 
                    left outer join meta.command_types ct on q.command_types_id = ct.id where q.id = @Id;";
            pQuery.Add("Id", QueriesId);
            var query = GetData(pQuery, null,querySQL,System.Data.CommandType.Text,"SCADMetaConnection",null,3).ToList();

            List<dynamic> results = new List<dynamic>();
            if (query.Count() == 1)
            {
                Int32 CommandTypesId = (Int32)query.First().command_types_id;


                results = GetData(p, null, query.First().command_text, (query.First().CommandTypesId == 1) ? CommandType.StoredProcedure : CommandType.Text, null, query.First().connection_string, query.First().db_technologies_id);
                
            }
            return results;

        }



        public static ServiceStack.Data.IDbConnectionFactory GetConnectionFactory(string ConnectionName, int DBTechnologiesId)
        {

            string ConnectionString = Settings.GetString($"ConnectionStrings:{ConnectionName}");


            ServiceStack.Data.IDbConnectionFactory factory;
           // OrmLiteConnection cnn;
            switch (DBTechnologiesId)
            {
                case 1:
                    factory = new OrmLiteConnectionFactory(ConnectionString, SqlServerDialect.Provider);
                    //cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                case 2:
                    factory = new OrmLiteConnectionFactory(ConnectionString, SqliteDialect.Provider);
                    //cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                case 3:
                    factory = new OrmLiteConnectionFactory(ConnectionString, PostgreSqlDialect.Provider);
                    //cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;
                default:
                    factory = new OrmLiteConnectionFactory(ConnectionString, PostgreSqlDialect.Provider);
                    //cnn = (OrmLiteConnection)factory.CreateDbConnection();
                    break;

            }

            
            return factory;

        }

        public static string GetTemplate(int DbTechnologyOperationsId, dynamic templateData, int TemplateProvidersId = 1, int DbTechnologyId = 3)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("DbTechnologyId", DbTechnologyId);
            p.Add("DbTechnologyOperationsId", DbTechnologyOperationsId);

            var results = RunMetaQuery(17, p);

            string template = "";
            if (results.Count() != 0)
            {
                 template =  results.First().template_text;
            }
            
            return template;

        }

        public static NpgsqlParameter GetPGParameter(string paramName, string typeName, bool isNullable, object value)
        {
            return new NpgsqlParameter(paramName, PGTypesMap[typeName].PgDBType,0,null,ParameterDirection.Input,isNullable,0,0, DataRowVersion.Current, value);
        }

        public static DynamicParameters GetDynamicParameters(int QueriesId, int TablesId, Dictionary<string,object> ParameterList, Dictionary<string,object>? FilterList,int PageNumber, int PageSize, Int32 UserAuthId)
        {
            DynamicParameters qParam = new DynamicParameters( );
            qParam.Add("QueriesId", QueriesId);
            qParam.Add("TablesId", TablesId);
            var query = RunMetaQuery(18, qParam);
            var qparams = RunMetaQuery(19, qParam);
            var columns = RunMetaQuery(14, qParam);
            Dictionary<string, Column> coldict = new Dictionary<string, Column>();
            foreach (var col in columns)
            {
                bool isNullable = col.is_nullable == "YES" ? true : false;
                coldict.Add(col.column_name, new Column { ColumnName = col.column_name, DefaultValue = col.defaultvalue, DataType = col.data_type, IsIdentity = col.identity, IsPrimary = col.primary_key, AllowNulls = isNullable });
            }

            DynamicParameters p = new DynamicParameters();
            if (qparams.Count() >= 0)
            {
                foreach (var param in qparams)
                {
                    object Value = null;
                    var paramName = (string)param.name;
                    var paramType = (int)param.parameter_types_id;
                    var allowNulls = (bool)param.allow_nulls;
                    var paramDataType = (string)param.data_type;
                    var constantValue = (string)param.constant_value;


                    switch (paramType)
                    {
                        case 1:
                            Value = TypeConverter.GetConvertedItemPG(paramDataType, constantValue);
                            break;
                        case 2:
                            Value = UserAuthId;
                            break;
                        case 3:
                            Value = PageNumber;
                            break;
                        case 4:
                            Value = PageSize;
                            break;
                        case 5:
                            Value = Guid.NewGuid();
                            break;
                        case 6:
                            Value = DateTime.Now;
                            break;
                        case 7:
                            Value = DateTime.UtcNow;//put datetime here
                            break;
                        case 8:
                            //put datetime with timezone here
                            if (ParameterList.ContainsKey(paramName))
                            {
                                Value = TypeConverter.GetConvertedItemPG(paramDataType,ParameterList[paramName]);
                            } else
                            {
                                if (allowNulls)
                                {
                                    Value = null;
                                }
                                else
                                {
                                    throw new NoNullAllowedException(paramName + " in Parameterlist can not be null");
                                }
                            }
                            break;
                            
                    }

                    p.Add(param.parameter_name, Value, PGTypesMap[(string)param.data_type].DbType, ParameterDirection.Input);

                }
            }
            else
            {
               
                foreach (var col in columns)
                {
                    object colValue = null;
                    var columnName = (string)col.column_name;
                    var colInfo = coldict[columnName];
                    if (ParameterList.ContainsKey(columnName))
                    {
                        colValue = TypeConverter.GetConvertedItemPG(colInfo.DataType, ParameterList[columnName]);
                    }
                    else
                    {
                        if (!colInfo.AllowNulls)
                        {
                            if (colInfo.DefaultValue is not null)
                            {
                                colValue = TypeConverter.GetConvertedItemPG(colInfo.DataType, ParameterList[columnName]);
                            }
                            else
                            {
                                throw new NoNullAllowedException(columnName + " in ParameterList can not be null");
                            }
                            
                        }
                        else
                        {
                            colValue = null;
                        }
                    }
                    p.Add(columnName, colValue, PGTypesMap[colInfo.DataType].DbType, ParameterDirection.Input);
                }
            }
            return p;

        }
        
    }
}
