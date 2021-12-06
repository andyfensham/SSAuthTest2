using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using SSAuthTest2.ServiceModel;
using SSAuthTest2.ServiceModel.Types;
using System.Collections.Generic;
using System.Linq;

namespace SSAuthTest2.ServiceInterface
{
    public class MyServices : Service
    {

        public IDbConnectionFactory ConnectionFactory { get; set; }
        public object Any(Hello request)
        {
            var session = base.GetSession();

            using (var db = ConnectionFactory.OpenDbConnection())
            {
                var result = db.Select<MyTable>();

                var resultdynamic = db.Select<dynamic>("select Id, FirstName from MyTable");

                var dapperresult = db.Query("select Id, FirstName from MyTable", null);

                var dappertyped = db.Query<MyTable>("select Id, FirstName from MyTable", null);

                var dapperdict = Utils.DapperDynamicToIDictionaryList(dapperresult);

                return new { ormlite = result, ormlitedynamic = resultdynamic, dappertypedresult = dappertyped, dapperraw = dapperresult, dapperdictionary = dapperdict};
            }
            
            //    return new HelloResponse { Result = $"Hello, {request.Name}!User Auth {session.UserAuthId}" };
        }
    }

    public class MySecureService : Service
    {
        [Authenticate]
        public object Any(SecureHello request)
        {
            var session = base.GetSession();

            return new HelloResponse { Result = $"Hello, {request.Name}!User Auth {session.UserAuthId}" };
        }
    }

    public class Utils
    {
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
    }
    
}

