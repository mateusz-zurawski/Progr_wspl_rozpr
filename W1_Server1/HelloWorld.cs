using System;
using System.Collections.Generic;
using System.Text;

namespace W7_HelloServer
{
    class HelloWorld : IHelloWorld
    {
        public string Hello()
        {
            return "Hello World!";
        }
    }

}
