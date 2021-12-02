using ServiceStack.Caching;
using ServiceStack.OrmLite.Dapper;
using System.Collections.Generic;
using System.Data;

namespace SCADFramework
{
    public class MetaQueries
    {
        public IDbConnection? db { get; set; }
        public ICacheClient? CacheClient { get; set; }
        public IDbConnection? Db { get; set; }
        public static IEnumerable<dynamic> GetData(int QueriesId,IDbConnection cnn, CommandType commandType)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("id", QueriesId);
            var sql = "select * from metaimport.queries where id = @id";
            var result = cnn.Query(sql, p, null, true, null, commandType);
            return result;
            //var output = CsvSerializer.SerializeToCsv(result);


        }
    }
    
}
