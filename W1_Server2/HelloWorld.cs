using System;
using System.Collections.Generic;
using System.Text;

namespace W1_Server2
{
    class HelloWorld : IHelloWorld
    {
        public string Hello()
        {
            return "Hello World!";
        }
    }

}
