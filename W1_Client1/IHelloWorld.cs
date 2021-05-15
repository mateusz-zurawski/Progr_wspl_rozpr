using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace W7_HelloServer
{
    [ServiceContract]
    interface IHelloWorld
    {
        [OperationContract]
        string Hello();
    }

}
