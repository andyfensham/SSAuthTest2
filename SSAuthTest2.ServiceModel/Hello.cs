using ServiceStack;

namespace SSAuthTest2.ServiceModel
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    [Route("/secure/hello")]
    [Route("/secure hello/{Name}")]
    public class SecureHello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }

}

