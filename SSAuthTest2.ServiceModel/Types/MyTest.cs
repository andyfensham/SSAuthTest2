using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSAuthTest2.ServiceModel.Types
{
    public class MyTable
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
