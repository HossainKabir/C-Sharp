using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsolePOS
{
    class Program
    {
        static void Main(string[] args)
        {
            var allFunction=new AllFunctionality();
            //allFunction.RunSystem();
            allFunction.RunSystemWithAdmin();

            

            /*var prac=new Practice();
            prac.Method();*/
        }
    }
}
