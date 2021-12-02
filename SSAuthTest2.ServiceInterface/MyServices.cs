using ServiceStack;
using SSAuthTest2.ServiceModel;

namespace SSAuthTest2.ServiceInterface
{
    public class MyServices : Service
    {
        [Authenticate]
        public object Any(Hello request)
        {
            var session = base.GetSession();
            
            return new HelloResponse { Result = $"Hello, {request.Name}!User Auth {session.UserAuthId}" };
        }
    }
}

