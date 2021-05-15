using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace W1_Server2
{
    [ServiceContract]
    interface IHelloWorld
    {
        [OperationContract]
        string Hello();
    }

}
